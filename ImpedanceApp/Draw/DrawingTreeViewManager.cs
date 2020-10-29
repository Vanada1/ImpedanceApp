using System.Windows.Forms;
using Impedance;
using System;
using System.Drawing;
using ImpedanceApp.Draw.Elements;
using ImpedanceApp.Draw.Segments;
using System.Reflection;

namespace ImpedanceApp.Draw
{
    //TODO: почему статик? (Done)
    /// <summary>
    /// Draw Tree View Manager class
    /// </summary>
    public class DrawingTreeViewManager
    {
	    public CircuitDrawer CircuitDrawer { get; set; }

	    public DrawingTreeViewManager(Circuit circuit)
	    {
		    CircuitDrawer = new CircuitDrawer(circuit);
		    FillDrawTreeView(circuit);
	    }

	    /// <summary>
	    /// Create segments tree
	    /// </summary>
	    private void FillDrawTreeView(Circuit circuit)
	    {
		    try
		    {
			    CircuitDrawer = new CircuitDrawer(circuit);
			    FillTreeNode(CircuitDrawer, circuit);
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
		    DrawableSegmentBase drawableSegmentBase;
		    //TODO: как-то не полиморфно. Хорошо бы сделать получение инфы об рисуемом элементе через рефлексию, (Done)
		    //где инфа хранится в атрибутах отрисовщика...
		    //TODO: но может попробовать сделать хотя бы словарь <Type, Type>,... (Done)
		    //где каждому элементу будет соответствовать свой отрисовщик,...
		    //а здесь будет просто вызываться метод активатора для создания объектов?

		    var segmentType = GetDrawingSegmentType(segment);
		    var parameters = new[] { typeof(ISegment) };
			var values = new object[] {segment};
			var constructor = segmentType.GetConstructor(parameters);

			if (constructor is null)
			{
				throw new ArgumentException("Wrong segment");
			}

			drawableSegmentBase = (DrawableSegmentBase) constructor.Invoke(values);

			return drawableSegmentBase;
	    }

	    private static Type GetDrawingSegmentType(ISegment segment)
	    {
		    switch (segment)
		    {
			    case Resistor _:
			    {
				    return typeof(DrawingResistor);
			    }

			    case Inductor _:
			    {
				    return typeof(DrawingInductor);
			    }

			    case Capacitor _:
			    {
				    return typeof(DrawingCapacitor);
			    }

			    case ParallelCircuit _:
			    {
				    return typeof(DrawingParallelCircuit);
			    }

			    case SerialCircuit _:
			    {
				    return typeof(DrawingSerialCircuit);
			    }

			    case Circuit _:
			    {
				    return typeof(CircuitDrawer);
			    }

			    default:
			    {
				    throw new ArgumentException("Unknown Segment");
			    }
		    }
	    }
    }
}