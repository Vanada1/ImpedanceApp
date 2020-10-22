using System.Windows.Forms;
using Impedance;
using System;

namespace ImpedanceApp
{
	public static class TreeViewManager
	{
		public static TreeView ElementsTreeView { get; set; }

		public static TreeView DrawMainCircuit { get; set; } = new TreeView();

		/// <summary>
		/// Create segments tree
		/// </summary>
		public static void FillElementsTreeView(Circuit circuit)
		{
			ElementsTreeView.Nodes.Clear();
			DrawMainCircuit.Nodes.Clear();
			try
			{
				SegmentTreeNode segmentTreeNode = new SegmentTreeNode
				{
					Name = circuit.Name,
					Text = circuit.Name,
					Segment = circuit
				};

				DrawTreeNode mainCircuit = new DrawTreeNode
				{
					Name = circuit.Name,
					Text = circuit.Name,
					Segment = circuit,
				};

				FillTreeNode(mainCircuit, circuit);
				DrawMainCircuit.Nodes.Add(mainCircuit);
				DrawTreeViewManager.CalculateSegmentsCount(DrawMainCircuit.Nodes[0] as DrawTreeNode);
				FillTreeNode(segmentTreeNode, circuit);
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
						var segmentTreeNode = new DrawTreeNode
						{
							Name = element.Name,
							Text = element.ToString(),
							Segment = element
						};
						treeNode.Nodes.Add(segmentTreeNode);
					}
					else
					{
						var segmentTreeNode = new DrawTreeNode
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
	}
}