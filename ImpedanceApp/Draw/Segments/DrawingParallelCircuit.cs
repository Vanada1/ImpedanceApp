using System;
using System.Drawing;
using Impedance;
using ImpedanceApp.Draw.Elements;

namespace ImpedanceApp.Draw.Segments
{
	/// <summary>
	/// Draw <see cref="ParallelCircuit"/> class
	/// </summary>
	[SegmentTypeValidation]
	public class DrawingParallelCircuit:DrawableSegmentBase
	{
		/// <summary>
		/// Draw <see cref="ParallelCircuit"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void Draw(Graphics graphics, Pen pen)
		{
			foreach (DrawableSegmentBase node in Nodes)
			{
				DrawConnect(new Point(ConnectToLeft.X, node.ConnectToLeft.Y), 
					node.ConnectToLeft, graphics, pen);

				node.Draw(graphics, pen);

				DrawConnect(node.ConnectToRight, new Point(ConnectToRight.X, node.ConnectToRight.Y),
						graphics, pen);
			}

			if (Nodes.Count <= 1) return;

			var startX = ConnectToLeft.X;
			var topY = ((DrawableSegmentBase) Nodes[0]).ConnectToLeft.Y;
			var bottomY = ((DrawableSegmentBase) Nodes[Nodes.Count - 1]).ConnectToLeft.Y;
			DrawConnect(new Point(startX, topY),
				new Point(startX, bottomY), graphics, pen);

			var endX = ConnectToRight.X;
			topY = ((DrawableSegmentBase) Nodes[0]).ConnectToRight.Y;
			bottomY = ((DrawableSegmentBase) Nodes[Nodes.Count - 1]).ConnectToRight.Y;
			DrawConnect(new Point(endX, topY),
				new Point(endX, bottomY), graphics, pen);
		}

		/// <summary>
		/// Calculate all points for SubSegments of <see cref="ParallelCircuit"/>
		/// </summary>
		public override void CalculatePoints()
		{
			if (Index == 0)
			{
				var parent = Parent as DrawableSegmentBase;
				if (parent is CircuitDrawer)
				{
					ConnectToLeft = new Point(parent.StartPoint.X + Range, parent.StartPoint.Y);
				}
			}

			foreach (DrawableSegmentBase node in Nodes)
			{
				if(node == null) continue;

				if (!(node is DrawingElementBase) && node.Nodes.Count == 0)
				{
					node.Remove();
					continue;
				}

				if (Nodes.Count == 1)
				{
					var parent = node.Parent as DrawableSegmentBase;
					node.ConnectToLeft = new Point(StartPoint.X, parent.ConnectToLeft.Y);
				}
				else
				{
					var x = StartPoint.X + Size.Width / 2 - node.Size.Width / 2;

					var y = StartPoint.Y;
					if (node.Index != 0 && node.PrevNode is DrawableSegmentBase prevSegment)
					{
						y = prevSegment.StartPoint.Y + prevSegment.Size.Height + Range * 2;
					}

					node.StartPoint = new Point(x, y);
				}

				if (node.Nodes.Count != 0)
				{
					node.CalculatePoints();
				}
			}
		}

		/// <summary>
		/// Calculate <see cref="ParallelCircuit"/> size
		/// </summary>
		/// <returns><see cref="ParallelCircuit"/> size</returns>
		public override Size CalculateSegmentSize()
		{
			if (Nodes.Count == 0) return new Size(0, 0);

			var width = FindMaxWidth() + Range;
			var height = 0;
			foreach (DrawableSegmentBase node in Nodes)
			{
				height += node.CalculateSegmentSize().Height;
			}

			height += ((DrawableSegmentBase) Nodes[Nodes.Count - 1]).Size.Height / 2;

			Size = new Size(width, height);

			return Size;
		}

		/// <summary>
		/// Find max Width between all SubSegments
		/// </summary>
		/// <returns>SubSegments max Width </returns>
		private int FindMaxWidth()
		{
			if (Nodes.Count == 0) return 0;

			var sizeWidth = ((DrawableSegmentBase) Nodes[0]).CalculateSegmentSize().Width;

			foreach (DrawableSegmentBase node in Nodes)
			{
				if (node.CalculateSegmentSize().Width > sizeWidth)
				{
					sizeWidth = node.CalculateSegmentSize().Width;
				}
			}

			return sizeWidth;
		}
	}
}