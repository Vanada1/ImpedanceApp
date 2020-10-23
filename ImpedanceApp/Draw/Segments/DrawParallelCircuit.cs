using System;
using System.Drawing;
using Impedance;

namespace ImpedanceApp
{
	public class DrawParallelCircuit:DrawableSegment
	{
		/// <summary>
		/// Set and return <see cref="SegmentStartPoint"/>
		/// </summary>
		public override Point SegmentStartPoint { get; set; }

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		public override Point SegmentEndPoint { get; set; }

		/// <summary>
		/// Set and return segment size
		/// </summary>
		public override Size Size { get; set; }

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		public override ISegment Segment { get; set; }


		/// <summary>
		/// <see cref="DrawParallelCircuit"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="ParallelCircuit"/></param>
		public DrawParallelCircuit(ISegment segment)
		{
			Segment = segment;
		}

		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			var startX = SegmentStartPoint.X;
			var endX = SegmentEndPoint.X;

			var leftTopCorner = new Point();
			var leftBottomCorner = new Point();
			var rightTopCorner = new Point();
			var rightBottomCorner = new Point();

			//TODO Дублирование
			foreach (DrawableSegment node in Nodes)
			{
				if (node.Index == 0 )
				{
					leftTopCorner.X = startX;
					leftTopCorner.Y = node.SegmentStartPoint.Y;
					rightTopCorner.X = endX;
					rightTopCorner.Y = node.SegmentStartPoint.Y;
				}

				if (node.Index == Nodes.Count - 1)
				{
					leftBottomCorner.X = startX;
					leftBottomCorner.Y = node.SegmentStartPoint.Y;
					rightBottomCorner.X = endX;
					rightBottomCorner.Y = node.SegmentStartPoint.Y;
				}

				DrawConnect(new Point(startX, node.SegmentStartPoint.Y), node.SegmentStartPoint,
					graphics, pen);
				node.DrawSegment(graphics, pen);
				DrawConnect(node.SegmentStartPoint, new Point(endX, node.SegmentStartPoint.Y),
					graphics, pen);
			}

			if (Nodes.Count > 1)
			{
				DrawConnect(leftTopCorner, leftBottomCorner, graphics, pen);
				DrawConnect(rightTopCorner, rightBottomCorner, graphics, pen);
			}
		}

		public override void CalculateCoordinates()
		{
			if (Index == 0)
			{
				SegmentStartPoint = (Parent as DrawableSegment).SegmentStartPoint;
				SegmentEndPoint = (Parent as DrawableSegment).SegmentEndPoint;
			}
			else
			{
				var prevNode = PrevNode as DrawableSegment;
				SegmentStartPoint = new Point(prevNode.SegmentEndPoint.X + Range, prevNode.SegmentEndPoint.Y);
				SegmentEndPoint = new Point(SegmentStartPoint.X + Size.Width + Range, SegmentStartPoint.Y);
			}

			foreach (DrawableSegment node in Nodes)
			{
				if (Nodes.Count == 1)
				{
					node.SegmentStartPoint = SegmentStartPoint;
					node.SegmentEndPoint = SegmentEndPoint;
					return;
				}

				var middleLine = (SegmentEndPoint.X - SegmentStartPoint.X - Size.Width) / 2;
				var x = SegmentStartPoint.X + middleLine;
				var y = 0;
				if (node.Index == 0)
				{
					y = Math.Abs(SegmentStartPoint.Y - Size.Height / 2);
				}
				else
				{
					if (node.PrevNode is DrawableSegment prevSegment)
					{
						y = prevSegment.SegmentStartPoint.Y + node.Size.Height;
					}
				}

				node.SegmentStartPoint = new Point(x, y);

				if (node.Nodes.Count != 0)
				{
					node.CalculateCoordinates();
				}
			}
		}

		public override Size GetSegmentSize()
		{
			var width = GetMaxWidth();
			var height = 0;
			foreach (var node in Nodes)
			{
				var segmentNode = node as DrawableSegment;
				height += segmentNode.GetSegmentSize().Height;
			}

			Size = new Size(width, height);

			return Size;
		}

		private int GetMaxWidth()
		{
			if (Nodes.Count == 0) return 0;

			var sizeWidth = ((DrawableSegment) Nodes[0]).Size.Width;

			foreach (var node in Nodes)
			{
				if (node is DrawableSegment segmentNode && segmentNode.Size.Width > sizeWidth)
				{
					sizeWidth = segmentNode.Size.Width;
				}
			}

			return sizeWidth;
		}
	}
}