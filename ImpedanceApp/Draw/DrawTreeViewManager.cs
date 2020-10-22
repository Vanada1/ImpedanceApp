using System.Windows.Forms;
using Impedance;
using System;

namespace ImpedanceApp
{
	public static class DrawTreeViewManager
	{
		public static TreeView ElementsTreeView { get; set; }

		/// <summary>
		/// Create segments tree
		/// </summary>
		public static void FillElementsTreeView(Circuit circuit)
		{
			ElementsTreeView.Nodes.Clear();
			try
			{
				SegmentTreeNode segmentTreeNode = new SegmentTreeNode
				{
					Name = circuit.Name,
					Text = circuit.Name,
					Segment = circuit
				};

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
					var segmentTreeNode = new SegmentTreeNode
					{
						Name = subSegment.Name,
						Text = subSegment.ToString(),
						Segment = subSegment
					};

					treeNode.Nodes.Add(segmentTreeNode);
					if (!(subSegment is Element element))
					{
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