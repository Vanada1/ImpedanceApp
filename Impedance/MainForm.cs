using Impedance;
using ImpedanceApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ImpedanceForms
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Old <see cref="CircuitsListBox"/> index
		/// </summary>
		private int _previousCircuitListBoxIndex = -1;

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
			if (e is ElementEventArgs elementEventArgs)
			{
				EventLabel.Text = elementEventArgs.Message;
			}
		}

		/// <summary>
		/// Update circuit combo box
		/// </summary>
		private void UpdateCircuitComboBox()
		{
			CircuitsComboBox.DataSource = null;
			CircuitsComboBox.DataSource = _project.AllExamples;
			CircuitsComboBox.DisplayMember = "Name";
		}

		private void UpdateImpedancesDataGridView()
		{
			ImpedancesDataGridView.Rows.Clear();
			for (int i = 0; i < _project.Frequencies.Count; i++)
			{
				string[] newRow = {_project.Frequencies[i].ToString(), _project.ResultsString[i]};
				ImpedancesDataGridView.Rows.Add(newRow);
			}
		}

		/// <summary>
		/// Update all list boxes
		/// </summary>
		private void UpdateListBoxes()
		{
			_project.Results = _project.CurrentCircuit.CalculateZ(_project.Frequencies);
			_project.ResultsString = StringValidator.CreatingStringImpedances(_project.Results);
			_project.FindAllElements(_project.CurrentCircuit);
			ElementsTreeView.ExpandAll();
			UpdateImpedancesDataGridView();
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
			catch (ArgumentException e)
			{
				MessageBox.Show(e.Message, @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Add sub-segments in the tree
		/// </summary>
		/// <param name="treeNode">node where will add</param>
		/// <param name="segment">segment where will add</param>
		private static void FillTreeNode(TreeNode treeNode, ISegment segment)
		{
			try
			{
				foreach (var subSegment in segment.SubSegments)
				{
					if (subSegment is Element element)
					{
						var segmentTreeNode = new SegmentTreeNode
						{
							Name = element.Name,
							Text = element.ToString(),
							Segment = element
						};
						treeNode.Nodes.Add(segmentTreeNode);
					}
					else
					{
						var segmentTreeNode = new SegmentTreeNode
						{
							Name = subSegment.Name,
							Text = subSegment.ToString(),
							Segment = subSegment
						};
						treeNode.Nodes.Add(segmentTreeNode);
						FillTreeNode(segmentTreeNode, subSegment);
					}
				}
			}
			catch (ArgumentException e)
			{
				MessageBox.Show(e.Message, @"Error",
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
			UpdateCircuitComboBox();
			EventLabel.Text = "";

			foreach (var example in _project.AllExamples)
			{
				example.SegmentChanged += OnCircuitCollectionChanged;
			}

			var typeSegments = StringValidator.GetSegmentEnum(null);
			TypeComboBox.DataSource = typeSegments;
		}

		private void AddFrequenciesButton_Click(object sender, EventArgs e)
		{
			if (!double.TryParse(FrequencyTextBox.Text, out var frequency))
			{
				MessageBox.Show(@"Incorrect frequency value. Enter the number.", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			_project.Frequencies.Add(frequency);
			FrequencyTextBox.Text = "";
			UpdateListBoxes();
		}

		//private void RemoveFrequenciesButton_Click(object sender, EventArgs e)
		//{
		//	var index = FrequenciesListBox.SelectedIndex;
		//	if (index == -1)
		//	{

		//		MessageBox.Show(@"Frequency was not selected", @"Error",
		//			MessageBoxButtons.OK, MessageBoxIcon.Error);
		//		return;
		//	}

		//	var dialogResult = MessageBox.Show(@"Remove the frequency?", @"Remove?",
		//		MessageBoxButtons.YesNo);
		//	if (dialogResult == DialogResult.Yes)
		//	{
		//		_project.Frequencies.RemoveAt(index);
		//	}
		//	UpdateListBoxes();
		//}

		private void EditElementButton_Click(object sender, EventArgs e)
		{
			if (!(ElementsTreeView.SelectedNode is SegmentTreeNode node))
			{
				MessageBox.Show(nameof(Element) + @"was not selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (TypeComboBox.SelectedIndex == 0)
			{
				MessageBox.Show(@"Choose the segment",
					@"Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if (NameTextBox.Text.Length == 0 && (node.Segment is Element))
			{
				MessageBox.Show(@"Enter Name", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (ValueTextBox.Text.Length == 0 && (node.Segment is Element))
			{
				MessageBox.Show(@"Enter Value", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!SegmentType.TryParse(TypeComboBox.Text, out SegmentType segmentType))
			{
				MessageBox.Show(@"Incorrect segment", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!double.TryParse(ValueTextBox.Text, out var value))
			{
				MessageBox.Show(@"Incorrect value. Enter the number ", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var subSegment = node.Segment.SubSegments;
			var name = NameTextBox.Text;
			var newSegment = CircuitValidator.CreateNewSegment(segmentType, name, value, subSegment);
			_project.CurrentCircuit.ReplaceSegment(node.Segment,
				newSegment);
			node.Name = newSegment.Name;
			node.Text = newSegment.ToString();
			node.Segment = newSegment;
			ElementsTreeView.SelectedNode = null;
			ElementsTreeView.SelectedNode = node;
			UpdateListBoxes();
		}

		private void AddElementButton_Click(object sender, EventArgs e)
		{
			var selectedNode = ElementsTreeView.SelectedNode as SegmentTreeNode;
			if (selectedNode == null)
			{
				MessageBox.Show(nameof(Element) + @"was not selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var addForm = new ElementForm();
			addForm.ShowDialog();
			if (addForm.DialogResult == DialogResult.OK)
			{
				var text = addForm.Segment.Name;
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

		private void RemoveElementButton_Click(object sender, EventArgs e)
		{
			if (!(ElementsTreeView.SelectedNode is SegmentTreeNode node))
			{
				MessageBox.Show(nameof(Element) + @"was not selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
		
			var dialogResult = MessageBox.Show(@"Remove the element?", @"Remove?",
				MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				var foundElement = node.Segment;
				var parentNode = node.Parent;
				if (parentNode == null)
				{
					MessageBox.Show(@"Cannot remove main root",
						@"Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					return;
				}

				parentNode.Nodes.Remove(node);
				_project.CurrentCircuit.RemoveSegment(
					foundElement);
				

				UpdateListBoxes();
			}
		}

		private void CircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var index = CircuitsComboBox.SelectedIndex;
			if (index == -1) return;

			_project.CurrentCircuit = _project.AllExamples[index];
			UpdateListBoxes();
			if (index != _previousCircuitListBoxIndex)
			{
				FillElementsTreeView();
			}

			_previousCircuitListBoxIndex = index;
		}

		private void AddCircuit_Click(object sender, EventArgs e)
		{
			var addForm = new CircuitForm();
			addForm.ShowDialog();
			if (addForm.DialogResult == DialogResult.OK)
			{
				addForm.Circuit.SegmentChanged += OnCircuitCollectionChanged;
				_project.AllExamples.Add(addForm.Circuit);
				UpdateCircuitComboBox();
				CircuitsComboBox.SelectedIndex = _project.AllExamples.Count - 1;
			}
			UpdateListBoxes();
		}

		private void EditCircuit_Click(object sender, EventArgs e)
		{
			var index = CircuitsComboBox.SelectedIndex;
			if (index == -1)
			{
				MessageBox.Show(@"Circuit was not selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var editForm = new CircuitForm
			{
				Circuit = _project.AllExamples[index].Clone()
					as Circuit
			};
			editForm.ShowDialog();
			if (editForm.DialogResult == DialogResult.OK)
			{
				_project.AllExamples[index].Name = editForm.Circuit.Name;
			}
			UpdateListBoxes();
			UpdateCircuitComboBox();
			
		}

		private void RemoveCircuit_Click(object sender, EventArgs e)
		{
			var index = CircuitsComboBox.SelectedIndex;
			if (index == -1)
			{
				MessageBox.Show(@"Circuit was not selected",
					@"Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}
			
			var dialogResult = MessageBox.Show(@"Remove the circuit?",
				@"Remove?", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				_project.AllExamples[index].SegmentChanged -= OnCircuitCollectionChanged;
				_project.AllExamples.RemoveAt(index);
				UpdateCircuitComboBox();
			}
			UpdateListBoxes();
			
		}

		private void ElementsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (!(ElementsTreeView.SelectedNode is SegmentTreeNode node))
			{
				NameTextBox.Text = "";
				ValueTextBox.Text = "";
				TypeComboBox.Text = "";
				return;
			}

			switch (node.Segment)
			{
				case Circuit _:
				{
					NameTextBox.Enabled = false;
					ValueTextBox.Enabled = false;
					break;
				}
				case Element element:
				{
					NameTextBox.Text = node.Name;
					ValueTextBox.Text = element.Value.ToString(CultureInfo.CurrentCulture);
					NameTextBox.Enabled = true;
					ValueTextBox.Enabled = true;
					break;
				}
				default:
				{
					NameTextBox.Enabled = false;
					ValueTextBox.Enabled = false;
					break;
				}
			}
			TypeComboBox.DataSource = StringValidator.GetSegmentEnum(node.Segment);
			TypeComboBox.Text = node.Segment.SegmentType.ToString();
		}

		private void AddParallelSegmentButton_Click(object sender, EventArgs e)
		{
			if (!(ElementsTreeView.SelectedNode is SegmentTreeNode node))
			{
				MessageBox.Show(nameof(Element) + @"was not selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (node.Segment is Element element)
			{
				var collection = new SegmentObservableCollection
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

		private void AddSerialSegmentButton_Click(object sender, EventArgs e)
		{
			if (!(ElementsTreeView.SelectedNode is SegmentTreeNode node))
			{
				MessageBox.Show(nameof(Element) + @"was not selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

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
			var targetPoint = ElementsTreeView.PointToClient(new Point(e.X, e.Y));
			var targetNode = ElementsTreeView.GetNodeAt(targetPoint) as SegmentTreeNode;

			if (!(e.Data.GetData(typeof(SegmentTreeNode)) is SegmentTreeNode draggedNode))
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
				return;
			}
			
			var parentNode = targetNode;

			if (!draggedNode.Equals(targetNode))
			{
				var canDrop = true;

				while (canDrop && (parentNode != null))
				{
					canDrop = !object.ReferenceEquals(draggedNode, parentNode);
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
						FillElementsTreeView();
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
			
			ElementsTreeView.SelectedNode = draggedNode;
		}

		private void AddSegment_Click(object sender, EventArgs e)
		{
			if (!(ElementsTreeView.SelectedNode is SegmentTreeNode node))
			{
				MessageBox.Show(nameof(Element) + @"was not selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var segmentForm = new SegmentForm();
			segmentForm.ShowDialog();
			if(segmentForm.DialogResult != DialogResult.OK) return;

			if (node.Segment is Element element)
			{
				segmentForm.Segment.SubSegments.Add(element);
				_project.CurrentCircuit.ReplaceSegment(node.Segment,
					segmentForm.Segment);
			}
			else
			{
				node.Segment.SubSegments.Add(segmentForm.Segment);
			}

			UpdateListBoxes();
			FillElementsTreeView();
		}

		private void ImpedancesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
