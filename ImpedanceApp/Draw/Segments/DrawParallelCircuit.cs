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
			CalculateCoordinates();
			Size = GetSegmentSize();
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
			foreach (var node in Nodes)
			{
				var segmentNode = node as DrawableSegment;
				if (Nodes.Count == 1)
				{
					segmentNode.SegmentStartPoint = SegmentStartPoint;
					segmentNode.SegmentEndPoint = SegmentEndPoint;
					return;
				}

				var middleLine = (SegmentEndPoint.X - SegmentStartPoint.X - Size.Width) / 2;
				var x = SegmentStartPoint.X + middleLine;
				var y = 0;
				if (Index == 0)
				{
					y = segmentNode.SegmentStartPoint.Y - segmentNode.Size.Height / 2;
				}
				else
				{
					var prevSegment = segmentNode.PrevNode as DrawableSegment;
					y = prevSegment.SegmentStartPoint.Y + segmentNode.Size.Height;
				}

				segmentNode.SegmentStartPoint = new Point(x, y);

				if (segmentNode.Nodes.Count != 0)
				{
					segmentNode.CalculateCoordinates();
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

			return new Size(width, height);
		}

		private int GetMaxWidth()
		{
			var maxHeight = (Nodes[0] as DrawableSegment).Size.Width;

			foreach (var node in Nodes)
			{
				var segmentNode = node as DrawableSegment;
				if (segmentNode.Size.Width > maxHeight)
				{
					maxHeight = segmentNode.Size.Width;
				}
			}

			return maxHeight;
		}
	}
}