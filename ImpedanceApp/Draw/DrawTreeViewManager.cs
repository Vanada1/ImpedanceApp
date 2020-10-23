using System.Windows.Forms;
using Impedance;
using System;
using System.Drawing;

namespace ImpedanceApp
{
	public static class DrawTreeViewManager
	{
		public static DrawCircuit DrawCircuit { get; set; }

		/// <summary>
		/// Create segments tree
		/// </summary>
		public static void FillDrawTreeView(Circuit circuit)
		{
			try
			{
				DrawCircuit = new DrawCircuit(circuit);
				FillTreeNode(DrawCircuit, circuit);
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
		private static void FillTreeNode(DrawableSegment treeNode, ISegment segment)
		{
			try
			{
				foreach (var subSegment in segment.SubSegments)
				{
					var segmentTreeNode = GetDrawSegment(subSegment);

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

		/// <summary>
		/// Create draw segment
		/// </summary>
		/// <param name="segment">segment for check</param>
		/// <returns>Draw Segment</returns>
		private static DrawableSegment GetDrawSegment(ISegment segment)
		{
			DrawableSegment drawableSegment;

			switch (segment)
			{
				case Resistor _:
				{
					drawableSegment = new DrawResistor(segment);
					break;
				}

				case Inductor _:
				{
					drawableSegment = new DrawInductor(segment);
					break;
				}

				case Capacitor _:
				{
					drawableSegment = new DrawCapacitor(segment);
					break;
				}

				case ParallelCircuit _:
				{
					drawableSegment = new DrawParallelCircuit(segment);
					break;
				}

				case SerialCircuit _:
				{
					drawableSegment = new DrawSerialCircuit(segment);
					break;
				}

				case Circuit _:
				{
					drawableSegment = new DrawCircuit(segment);
					break;
				}

				default:
				{
					throw new ArgumentException("Unknown Segment");
				}
			}

			return drawableSegment;
		}
	}
}