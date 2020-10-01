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
		}

		/// <summary>
		/// Create segments tree
		/// </summary>
        private void FillElementsTreeView()
        {
	        ElementsTreeView.Nodes.Clear();
	        try
	        {
		        TreeNode segmentTreeNode = new TreeNode 
		        {
			        Name = _project.CurrentCircuit.Name,
			        Text = _project.CurrentCircuit.Name
		        };
		        FillTreeNode(segmentTreeNode, _project.CurrentCircuit);
		        ElementsTreeView.Nodes.Add(segmentTreeNode);
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
        private void FillTreeNode(TreeNode treeNode, ISegment segment)
        {
	        try
	        {
		        foreach (var subSegment in segment.SubSegments)
		        {
			        if (subSegment is IElement element)
			        {
				        TreeNode segmentTreeNode = new TreeNode
				        {
					        Name = element.Name,
							Text = element.ToString()
				        };
				        treeNode.Nodes.Add(segmentTreeNode);
			        }
			        else
			        {
				        TreeNode segmentTreeNode = new TreeNode
				        {
					        Name = subSegment.Name,
					        Text = subSegment.Name
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
			EventLabel.Text = "";

			foreach (Circuit example in _project.AllExamples)
			{
				example.SegmentChanged += OnCircuitCollectionChanged;
			}
			CircuitsListBox.DataSource = null;
			CircuitsListBox.DataSource = _project.AllExamples;
			CircuitsListBox.DisplayMember = "Name";
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
			var node = ElementsTreeView.SelectedNode;
			if (node != null)
			{
				ISegment foundSegment = _project.FindSegment(node.Name);
				ISegment oldSegment = foundSegment.Clone() as ISegment;
                AddEditElementForm editForm = new AddEditElementForm
                {
                    Segment = foundSegment,
                    NameSegments = _project.NameSegments
                };
                editForm.NameSegments.Remove(foundSegment.Name);
				editForm.ShowDialog();
				if (editForm.DialogResult != DialogResult.OK)
				{
					foundSegment = oldSegment;
				}

				ElementsTreeView.SelectedNode.Name =
					foundSegment.Name;
				if (foundSegment is IElement foundElement)
				{
					ElementsTreeView.SelectedNode.Text =
						foundSegment.ToString();
				}
				else
				{
					ElementsTreeView.SelectedNode.Text =
						foundSegment.Name;
				}

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
			var selectedNode = ElementsTreeView.SelectedNode;
			if (selectedNode != null)
			{
				var addForm = new AddEditElementForm
				{
					NameSegments = _project.NameSegments
				};
				addForm.ShowDialog();
				if (addForm.DialogResult == DialogResult.OK)
				{
					var segment = _project.FindSegment(
						selectedNode.Name);
					string text = addForm.Segment.Name;
					if (segment is IElement)
					{
						selectedNode = selectedNode.Parent;
						segment = _project.FindSegment(
							selectedNode.Name);
					}

					if (addForm.Segment is IElement)
					{
						text = addForm.Segment.ToString();
					}

					segment.SubSegments.Add(addForm.Segment);
					selectedNode.Nodes.Add(new TreeNode
					{
						Name = addForm.Segment.Name,
						Text = text
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
			var node = ElementsTreeView.SelectedNode;
			if (node != null)
			{
				var remove = MessageBox.Show("Remove?", "Remove?",
					MessageBoxButtons.YesNo);
				if (remove == DialogResult.Yes)
				{
					ISegment foundElement = _project.FindSegment(
						node.Name);
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

		private void CircuitsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var index = CircuitsListBox.SelectedIndex;
			if (index >= 0)
			{
				_project.CurrentCircuit = _project.AllExamples[index];
				FillElementsTreeView();
				UpdateListBoxes();
				FillElementsTreeView();
			}
			else
			{
				MessageBox.Show(nameof(Circuit) + " was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			_project.CurrentCircuit = _project.AllExamples[0];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FirstExample;
			UpdateListBoxes();
		}

		private void ElementsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			_selectedNode = ElementsTreeView.SelectedNode;
		}
	}
}
