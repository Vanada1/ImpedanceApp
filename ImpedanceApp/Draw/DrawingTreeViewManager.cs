using System.Windows.Forms;
using Impedance;
using System;
using System.Drawing;
using ImpedanceApp.Draw.Elements;
using ImpedanceApp.Draw.Segments;

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
			//TODO: как-то не полиморфно. Хорошо бы сделать получение инфы об рисуемом элементе через рефлексию,
			//где инфа хранится в атрибутах отрисовщика...
            //TODO: но может попробовать сделать хотя бы словарь <Type, Type>,...
            //где каждому элементу будет соответствовать свой отрисовщик,...
            //а здесь будет просто вызываться метод активатора для создания объектов?
			switch (segment)
			{
				case Resistor _:
				{
					drawableSegmentBase = new DrawingResistor(segment);
					break;
				}

				case Inductor _:
				{
					drawableSegmentBase = new DrawingInductor(segment);
					break;
				}

				case Capacitor _:
				{
					drawableSegmentBase = new DrawingCapacitor(segment);
					break;
				}

				case ParallelCircuit _:
				{
					drawableSegmentBase = new DrawingParallelCircuit(segment);
					break;
				}

				case SerialCircuit _:
				{
					drawableSegmentBase = new DrawingSerialCircuit(segment);
					break;
				}

				case Circuit _:
				{
					drawableSegmentBase = new CircuitDrawer(segment);
					break;
				}

				default:
				{
					throw new ArgumentException("Unknown Segment");
				}
			}

			return drawableSegmentBase;
		}
	}
}