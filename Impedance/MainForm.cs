using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using ImpedanceApp;
using Impedance;

namespace ImpedanceForms
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Old <see cref="CircuitsListBox"/> index
		/// </summary>
		private int _oldCircuitListBoxIndex = -1;

		/// <summary>
		/// Contains all data in this field
		/// </summary>
		private readonly Project _project = new Project();

        /// <summary>
        /// Event for collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCircuitCollectionChanged(
            object sender, EventArgs e)
        {
            if (e is ElementEventArgs elem)
            {
                EventLabel.Text = elem.Message;
				EventLabel.ForeColor = Color.Brown;
            }
        }

        private void UpdateComboBox()
        {
	        CircuitsComboBox.DataSource = null;
	        CircuitsComboBox.DataSource = _project.AllExamples;
	        CircuitsComboBox.DisplayMember = "Name";
        }

        /// <summary>
		/// Update all list boxes
		/// </summary>
		private void UpdateListBoxes()
        {
	        FrequenciesListBox.DataSource = null;
			FrequenciesListBox.DataSource = _project.Frequencies;

			_project.Results = _project.CurrentCircuit.CalculateZ(
				_project.Frequencies);
			ImpedanceListBox.DataSource = null;
			_project.ResultsString = new List<string>();
			foreach (var result in _project.Results)
			{
				string sign = "+";
				if (result.Imaginary < 0)
				{
					sign = "";
				}
				_project.ResultsString.Add($"{result.Real} {sign} " +
					$"{result.Imaginary}i");
			}
			ImpedanceListBox.DataSource = _project.ResultsString;
			ImpedanceListBox.ClearSelected();
			_project.FindAllElements(_project.CurrentCircuit);
			_project.CreateNameSegments(_project.CurrentCircuit);
			ElementsTreeView.ExpandAll();
		}

		/// <summary>
		/// Create segments tree
		/// </summary>
        private void FillElementsTreeView()
        {
	        ElementsTreeView.Nodes.Clear();
	        try
	        {
		        ISegmentTreeNode segmentTreeNode = new ISegmentTreeNode
				{
			        Name = _project.CurrentCircuit.Name,
			        Text = _project.CurrentCircuit.Name,
					Segment = _project.CurrentCircuit
		        };
		        FillTreeNode(segmentTreeNode, _project.CurrentCircuit);
		        ElementsTreeView.Nodes.Add(segmentTreeNode);
				ElementsTreeView.ExpandAll();
	        }
	        catch (Exception e)
	        {
		        MessageBox.Show(e.Message, "Error",
			        MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }
        }

		/// <summary>
		/// Add sub-segments in the tree
		/// </summary>
		/// <param name="treeNode">node where will add</param>
		/// <param name="segment">segment where will add</param>
        private void FillTreeNode(ISegmentTreeNode treeNode, ISegment segment)
        {
	        try
	        {
		        foreach (var subSegment in segment.SubSegments)
		        {
			        if (subSegment is Element element)
			        {
				        ISegmentTreeNode segmentTreeNode = new ISegmentTreeNode
						{
					        Name = element.Name,
							Text = element.ToString(),
							Segment =  element
				        };
				        treeNode.Nodes.Add(segmentTreeNode);
			        }
			        else
			        {
				        string parallel = "Parallel";
				        string serial = "Serial";
						ISegmentTreeNode segmentTreeNode = new ISegmentTreeNode
						{
							Name = subSegment.Name,
							Text = subSegment is ParallelCircuit ? parallel : serial,
							Segment = subSegment
						};
				        treeNode.Nodes.Add(segmentTreeNode);
				        FillTreeNode(segmentTreeNode, subSegment);
			        }
		        }
	        }
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			UpdateListBoxes();
			UpdateComboBox();
			EventLabel.Text = "";

			foreach (Circuit example in _project.AllExamples)
			{
				example.SegmentChanged += OnCircuitCollectionChanged;
			}
		}

		private void AddFrequenciesButton_Click(object sender, EventArgs e)
		{
			var addForm = new AddEditFrequencyForm();
			addForm.ShowDialog();
			if(addForm.DialogResult == DialogResult.OK)
			{
				_project.Frequencies.Add((double)addForm.Frequency);
			}
			UpdateListBoxes();
		}

		private void EditFrequenciesButton_Click(object sender, EventArgs e)
		{
			var index = FrequenciesListBox.SelectedIndex;
			var editForm = new AddEditFrequencyForm();
			if (index >= 0)
			{
				editForm.Frequency = _project.Frequencies[index];
				editForm.ShowDialog();
				if (editForm.DialogResult == DialogResult.OK)
				{
					_project.Frequencies[index] = (double)editForm.Frequency;
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Frequency was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		private void RemoveFrequenciesButton_Click(object sender, EventArgs e)
		{
			var index = FrequenciesListBox.SelectedIndex;
			if (index >= 0)
			{
				var remove = MessageBox.Show("Remove?", "Remove?",
					MessageBoxButtons.YesNo);
				if (remove == DialogResult.Yes)
				{
					_project.Frequencies.RemoveAt(index);
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Frequency was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void EditElementsButton_Click(object sender, EventArgs e)
		{
			if (ElementsTreeView.SelectedNode is ISegmentTreeNode node)
			{
				ISegment newSegment = null;
				ISegment oldSegment = node.Segment;
                AddEditElementForm editForm = new AddEditElementForm
                {
                    Segment = node.Segment,
                    NameSegments = _project.NameSegments
                };
                editForm.NameSegments.Remove(node.Segment.Name);
				editForm.ShowDialog();
				if (editForm.DialogResult == DialogResult.OK)
				{
					newSegment = _project.CurrentCircuit.ReplaceSegment(editForm.Segment, 
						node.Segment);
				}
				else
				{
					newSegment = oldSegment;
				}

				if (newSegment == null)
				{
					throw new ArgumentNullException(
						"Segment not found");
				}

				node.Name = newSegment.Name;
				node.Text = newSegment is Element ? newSegment.ToString() : newSegment.Name;
				node.Segment = newSegment;

				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddElementButton_Click(object sender, EventArgs e)
		{
			if (ElementsTreeView.SelectedNode is ISegmentTreeNode selectedNode)
			{
				var addForm = new AddEditElementForm
				{
					NameSegments = _project.NameSegments
				};
				addForm.ShowDialog();
				if (addForm.DialogResult == DialogResult.OK)
				{
					string text = addForm.Segment.Name;
					if (selectedNode.Segment is Element)
					{
						selectedNode = selectedNode.Parent as ISegmentTreeNode;
					}

					if (addForm.Segment is Element)
					{
						text = addForm.Segment.ToString();
					}

					selectedNode.Segment.SubSegments.Add(addForm.Segment);
					selectedNode.Nodes.Add(new ISegmentTreeNode
					{
						Name = addForm.Segment.Name,
						Text = text,
						Segment = addForm.Segment
					});
				}

				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void RemoveElementButton_Click(object sender, EventArgs e)
		{
			if (ElementsTreeView.SelectedNode is ISegmentTreeNode node)
			{
				var remove = MessageBox.Show("Remove?", "Remove?",
					MessageBoxButtons.YesNo);
				if (remove == DialogResult.Yes)
				{
					ISegment foundElement = _project.CurrentCircuit.FindSegment(
						node.Segment);
					var parentNode = node.Parent;
					if (parentNode != null)
					{
						parentNode.Nodes.Remove(node);
						_project.CurrentCircuit.RemoveElement(
							foundElement);
					}
					else
					{
						MessageBox.Show("Cannot remove main root",
							"Error", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
					UpdateListBoxes();
				}
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var index = CircuitsComboBox.SelectedIndex;
			if (index >= 0)
			{
				_project.CurrentCircuit = _project.AllExamples[index];
				UpdateListBoxes();
				if (index != _oldCircuitListBoxIndex)
				{
					FillElementsTreeView();
				}

				_oldCircuitListBoxIndex = index;
			}
			else
			{
				//MessageBox.Show(nameof(Circuit) + " was not selected", "Error",
				//	MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddCircuit_Click(object sender, EventArgs e)
		{
			var addForm = new AddEditCircuitForm();
			addForm.ShowDialog();
			if (addForm.DialogResult == DialogResult.OK)
			{
				addForm.Circuit.SegmentChanged += OnCircuitCollectionChanged;
				_project.AllExamples.Add(addForm.Circuit);
				UpdateComboBox();
				CircuitsComboBox.SelectedIndex = _project.AllExamples.Count - 1;
			}
			UpdateListBoxes();
		}

		private void EditCircuit_Click(object sender, EventArgs e)
		{
			var index = CircuitsComboBox.SelectedIndex;
			var editForm = new AddEditCircuitForm();
			if (index >= 0)
			{
				editForm.Circuit = _project.AllExamples[index].Clone() 
					as Circuit;
				editForm.ShowDialog();
				if (editForm.DialogResult == DialogResult.OK)
				{
					_project.AllExamples[index].Name = editForm.Circuit.Name;
				}
				UpdateListBoxes();
				UpdateComboBox();
			}
			else
			{
				MessageBox.Show("Circuit was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void RemoveCircuit_Click(object sender, EventArgs e)
		{
			var index = CircuitsComboBox.SelectedIndex;
			if (index >= 0)
			{
				var remove = MessageBox.Show("Remove?",
					"Remove?", MessageBoxButtons.YesNo);
				if (remove == DialogResult.Yes)
				{
					_project.AllExamples[index].SegmentChanged -= OnCircuitCollectionChanged;
					_project.AllExamples.RemoveAt(index);
					UpdateComboBox();
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Cercuit was not selected",
					"Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}
	}
}
