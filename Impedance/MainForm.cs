using Impedance;
using ImpedanceApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
		/// Searches the list with the same name
		/// </summary>
		/// <param name="nameSegment">Name to search in the list</param>
		/// <returns>True - if found
		/// False - if not found</returns>
		private bool SearchName(string nameSegment)
		{
			foreach (var name in _project.NameSegments)
			{
				if (name == nameSegment)
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Create a new segment for the circuit
		/// </summary>
		/// <param name="name">Name of segment</param>
		/// <param name="value">Value of segment if it is
		/// <see cref="ImpedanceApp.Element"/></param>
		private ISegment CreateNewSegment(string name, double value,
			SegmentObservableCollection subSegments)
		{
			ISegment segment = null;
			if (SegmentType.TryParse(TypeComboBox.Text,
				out ImpedanceApp.SegmentType segmentType))
			{
				switch (segmentType)
				{
					case ImpedanceApp.SegmentType.Capacitor:
						{
							segment = new Capacitor(name, value);
							break;
						}

					case ImpedanceApp.SegmentType.Inductor:
						{
							segment = new Inductor(name, value);

							break;
						}

					case ImpedanceApp.SegmentType.Resistor:
						{
							segment = new Resistor(name, value);
							break;
						}

					case ImpedanceApp.SegmentType.SerialCircuit:
						{
							if (subSegments == null)
							{
								subSegments = new SegmentObservableCollection();
							}
							segment = new SerialCircuit(subSegments);
							break;
						}

					case ImpedanceApp.SegmentType.ParallelCircuit:
						{
							if (subSegments == null)
							{
								subSegments = new SegmentObservableCollection();
							}
							segment = new ParallelCircuit(subSegments);
							break;
						}
				}
			}
			else
			{
				MessageBox.Show("Select the segment", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
			}

			return segment;
		}

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
			//FillElementsTreeView();
		}

		/// <summary>
		/// Create segments tree
		/// </summary>
		private void FillElementsTreeView()
		{
			ElementsTreeView.Nodes.Clear();
			try
			{
				SegmentTreeNode segmentTreeNode = new SegmentTreeNode
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
		private void FillTreeNode(SegmentTreeNode treeNode, ISegment segment)
		{
			try
			{
				foreach (var subSegment in segment.SubSegments)
				{
					if (subSegment is Element element)
					{
						SegmentTreeNode segmentTreeNode = new SegmentTreeNode
						{
							Name = element.Name,
							Text = element.ToString(),
							Segment = element
						};
						treeNode.Nodes.Add(segmentTreeNode);
					}
					else
					{
						string parallel = "Parallel";
						string serial = "Serial";
						SegmentTreeNode segmentTreeNode = new SegmentTreeNode
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

			List<string> typeSegments = new List<string>
			{
				"",
				nameof(ImpedanceApp.SegmentType.Resistor),
				nameof(ImpedanceApp.SegmentType.Capacitor),
				nameof(ImpedanceApp.SegmentType.Inductor),
				nameof(ImpedanceApp.SegmentType.SerialCircuit),
				nameof(ImpedanceApp.SegmentType.ParallelCircuit),
			};
			TypeComboBox.DataSource = typeSegments;
		}

		private void AddFrequenciesButton_Click(object sender, EventArgs e)
		{
			try
			{

				double frequency = double.Parse(FrequencyTextBox.Text);
				_project.Frequencies.Add(frequency);
				FrequencyTextBox.Text = "";
			}
			catch (FormatException exception)
			{
				MessageBox.Show(exception.Message, "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			UpdateListBoxes();
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

		private void EditElementButton_Click(object sender, EventArgs e)
		{
			if (ElementsTreeView.SelectedNode is SegmentTreeNode node)
			{
				_project.NameSegments.Remove(node.Segment.Name);
				if (SearchName(NameTextBox.Text))
				{
					MessageBox.Show("An object already exists with" +
									" the same name",
						"Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
				else if (TypeComboBox.SelectedIndex == 0)
				{
					MessageBox.Show("Choose the segment",
						"Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
				else if (NameTextBox.Text.Length == 0)
				{
					MessageBox.Show("Enter Name", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (ValueTextBox.Text.Length == 0)
				{
					MessageBox.Show("Enter Value", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					try
					{
						string name;
						double value;
						SegmentObservableCollection subSegment = node.Segment.SubSegments;
						if (node.Segment is Element)
						{
							name = NameTextBox.Text;
							value = double.Parse(ValueTextBox.Text);
						}
						else
						{
							name = "";
							value = 0.0;
						}
						var newSegment = CreateNewSegment(name, value, subSegment);
						_project.CurrentCircuit.ReplaceSegment(node.Segment,
							newSegment);
						node.Name = newSegment.Name;
						node.Text = newSegment is Element ? newSegment.ToString() : newSegment.Name;
						node.Segment = newSegment;
						ElementsTreeView.SelectedNode = null;
						ElementsTreeView.SelectedNode = node;
						UpdateListBoxes();
					}
					catch (FormatException exception)
					{
						MessageBox.Show(exception.Message, "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

				}
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddElementButton_Click(object sender, EventArgs e)
		{
			if (ElementsTreeView.SelectedNode is SegmentTreeNode selectedNode)
			{
				var addForm = new AddElementForm
				{
					NameSegments = _project.NameSegments
				};
				addForm.ShowDialog();
				if (addForm.DialogResult == DialogResult.OK)
				{
					string text = addForm.Segment.Name;
					if (selectedNode.Segment is Element)
					{
						selectedNode = selectedNode.Parent as SegmentTreeNode;
					}

					if (addForm.Segment is Element)
					{
						text = addForm.Segment.ToString();
					}

					selectedNode.Segment.SubSegments.Add(addForm.Segment);
					selectedNode.Nodes.Add(new SegmentTreeNode
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
			if (ElementsTreeView.SelectedNode is SegmentTreeNode node)
			{
				var remove = MessageBox.Show("Remove?", "Remove?",
					MessageBoxButtons.YesNo);
				if (remove == DialogResult.Yes)
				{
					ISegment foundElement = node.Segment;
					var parentNode = node.Parent;
					if (parentNode != null)
					{
						parentNode.Nodes.Remove(node);
						_project.CurrentCircuit.RemoveSegment(
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

		private void ElementsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (ElementsTreeView.SelectedNode is SegmentTreeNode node)
			{
				if (node.Segment is Circuit circuit)
				{

					NameTextBox.Enabled = false;
					ValueTextBox.Enabled = false;
					List<string> typeSegments = new List<string>
					{
						nameof(ImpedanceApp.SegmentType.SerialCircuit)
					};
					TypeComboBox.DataSource = typeSegments;
				}
				else if (node.Segment is Element element)
				{
					NameTextBox.Text = node.Name;
					ValueTextBox.Text = element.Value.ToString();
					NameTextBox.Enabled = true;
					ValueTextBox.Enabled = true;
					List<string> typeSegments = new List<string>
					{
						"",
						nameof(ImpedanceApp.SegmentType.Resistor),
						nameof(ImpedanceApp.SegmentType.Capacitor),
						nameof(ImpedanceApp.SegmentType.Inductor)
					};
					TypeComboBox.DataSource = typeSegments;
				}
				else
				{
					NameTextBox.Enabled = false;
					ValueTextBox.Enabled = false;
					List<string> typeSegments = new List<string>
					{
						"",
						nameof(ImpedanceApp.SegmentType.SerialCircuit),
						nameof(ImpedanceApp.SegmentType.ParallelCircuit),
					};
					TypeComboBox.DataSource = typeSegments;
				}
				TypeComboBox.Text = node.Segment.SegmentType.ToString();
			}
			else
			{
				NameTextBox.Text = "";
				ValueTextBox.Text = "";
				TypeComboBox.Text = "";
			}
		}

		private void AddParallelSegmentButton_Click(object sender, EventArgs e)
		{
			if (ElementsTreeView.SelectedNode is SegmentTreeNode node)
			{
				if (node.Segment is Element element)
				{
					SegmentObservableCollection collection = new SegmentObservableCollection
					{
						element
					};
					_project.CurrentCircuit.ReplaceSegment(node.Segment,
						new ParallelCircuit(collection));
				}
				else
				{
					node.Segment.SubSegments.Add(new ParallelCircuit(
						new SegmentObservableCollection()));
				}

				UpdateListBoxes();
				FillElementsTreeView();
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddSerialSegmentButton_Click(object sender, EventArgs e)
		{
			if (ElementsTreeView.SelectedNode is SegmentTreeNode node)
			{
				if (node.Segment is Element element)
				{
					SegmentObservableCollection collection = new SegmentObservableCollection
					{
						element
					};
					_project.CurrentCircuit.ReplaceSegment(node.Segment,
						new SerialCircuit(collection));
				}
				else
				{
					node.Segment.SubSegments.Add(new SerialCircuit(
						new SegmentObservableCollection()));
				}

				UpdateListBoxes();
				FillElementsTreeView();
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ElementsTreeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void ElementsTreeView_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.Move;
		}

		private void ElementsTreeView_DragDrop(object sender, DragEventArgs e)
		{
			Point targetPoint = ElementsTreeView.PointToClient(new Point(e.X, e.Y));
			SegmentTreeNode targetNode = ElementsTreeView.GetNodeAt(targetPoint) as SegmentTreeNode;
			SegmentTreeNode draggedNode = e.Data.GetData(typeof(SegmentTreeNode)) as SegmentTreeNode;

			if (draggedNode == null)
			{
				return;
			}

			if (targetNode == null || targetNode.Segment is Circuit)
			{
				_project.CurrentCircuit.RemoveSegment(draggedNode.Segment);
				draggedNode.Remove();
				ElementsTreeView.Nodes[0].Nodes.Add(draggedNode);
				_project.CurrentCircuit.SubSegments.Add(draggedNode.Segment);
				draggedNode.Expand();
				UpdateListBoxes();
			}
			else
			{
				SegmentTreeNode parentNode = targetNode;

				if (!draggedNode.Equals(targetNode) && targetNode != null)
				{
					bool canDrop = true;

					while (canDrop && (parentNode != null))
					{
						canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
						parentNode = parentNode.Parent as SegmentTreeNode;
					}

					if (canDrop)
					{
						if (targetNode.Segment is Element)
						{
							_project.CurrentCircuit.ReplaceSegment(targetNode.Segment,
								draggedNode.Segment.Clone() as ISegment);
							_project.CurrentCircuit.ReplaceSegment(draggedNode.Segment,
								targetNode.Segment.Clone() as ISegment);
							draggedNode.Parent.Nodes.Add(targetNode);
							targetNode.Parent.Nodes.Add(draggedNode);
							targetNode.Parent.Nodes.Remove(targetNode);
							draggedNode.Parent.Nodes.Remove(draggedNode);
							//FillElementsTreeView();
							UpdateListBoxes();
						}
						else
						{
							_project.CurrentCircuit.RemoveSegment(draggedNode.Segment);
							draggedNode.Remove();
							targetNode.Nodes.Add(draggedNode);
							targetNode.Segment.SubSegments.Add(draggedNode.Segment);
							draggedNode.Expand();
						}
						UpdateListBoxes();
					}
				}
			}
			ElementsTreeView.SelectedNode = draggedNode;
		}
	}
}
