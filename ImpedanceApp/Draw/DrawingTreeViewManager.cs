using System.Windows.Forms;
using Impedance;
using System;
using System.Drawing;
using ImpedanceApp.Draw.Elements;
using ImpedanceApp.Draw.Segments;
using System.Reflection;

namespace ImpedanceApp.Draw
{
    /// <summary>
    /// Draw Tree View Manager class
    /// </summary>
    public class DrawingTreeViewManager
    {
	    public CircuitDrawer CircuitDrawer { get; set; }

	    public DrawingTreeViewManager(Circuit circuit)
	    {
		    CircuitDrawer = new CircuitDrawer();
		    FillDrawTreeView(circuit);
	    }

	    /// <summary>
	    /// Create segments tree
	    /// </summary>
	    private void FillDrawTreeView(Circuit circuit)
	    {
		    try
		    {
			    CircuitDrawer = new CircuitDrawer();
			    FillTreeNode(CircuitDrawer, circuit);
			    ClearEmptySegments(CircuitDrawer);

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
	    private static void FillTreeNode(DrawableSegmentBase treeNode, ISegment segment)
	    {
		    try
		    {
			    foreach (var subSegment in segment.SubSegments)
			    {
				    var segmentTreeNode = GetDrawSegment(subSegment);
				    segmentTreeNode.Name = subSegment.Name;
				    treeNode.Nodes.Add(segmentTreeNode);
				    if (!(subSegment is Element))
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

	    /// <summary>
	    /// Create draw segment
	    /// </summary>
	    /// <param name="segment">segment for check</param>
	    /// <returns>Draw Segment</returns>
	    private static DrawableSegmentBase GetDrawSegment(ISegment segment)
	    {
            var segmentType = typeof(DrawableSegmentBase);
			var attributes = segmentType.GetCustomAttributes();

			if (attributes is null)
			{
				throw new ArgumentException("Wrong segment");
			}

			foreach (SegmentTypeValidationAttribute attribute in attributes)
			{
				return attribute.GetDrawingSegmentType(segment);
			}

			return null;
	    }

	    private static void ClearEmptySegments(DrawableSegmentBase root)
	    {
		    if (root.Nodes.Count == 0)
		    {
			    return;
		    }
		    DrawableSegmentBase node = root.Nodes[0] as DrawableSegmentBase;
		    while (node != null)
		    {
			    DrawableSegmentBase nextSegment = node.NextNode as DrawableSegmentBase;
			    if (!(node is DrawingElementBase))
			    {
				    if (node.Nodes.Count != 0)
				    {
					    ClearEmptySegments(node);
				    }
				    if (node.Nodes.Count == 0)
				    {
					    node.Remove();
				    }
			    }
			    node = nextSegment;
		    }
	    }
	}
}