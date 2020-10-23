using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public class DrawSerialCircuit : DrawableSegment
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
		/// <see cref="DrawSerialCircuit"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="SerialCircuit"/></param>
		public DrawSerialCircuit(ISegment segment)
		{
			Segment = segment;
		}

		/// <summary>
		/// Draw Serial segment
		/// </summary>
		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			foreach (DrawableSegment node in Nodes)
			{
				DrawConnect(node.Index == 0 ? SegmentStartPoint : ((DrawableSegment) node.PrevNode).SegmentEndPoint,
					node.SegmentStartPoint, graphics, pen);

				node.DrawSegment(graphics, pen);

				if (node.Index == Nodes.Count - 1)
				{
					DrawConnect(node.SegmentEndPoint, SegmentEndPoint, graphics, pen);
				}
			}
		}

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public override void CalculateCoordinates()
		{
			if (!(Parent is DrawableSegment parent))
			{
				throw new ArgumentException("Parent is not " + nameof(DrawableSegment));
			}

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
				if (Index == 0)
				{
					node.SegmentStartPoint = new Point(parent.SegmentStartPoint.X,
						parent.SegmentStartPoint.Y);
				}
				else
				{
					var prevNode = PrevNode as DrawableSegment;
					node.SegmentStartPoint = new Point(prevNode.SegmentEndPoint.X + Range,
						prevNode.SegmentEndPoint.Y);
				}

				if (Index == parent.Nodes.Count - 1)
				{
					node.SegmentEndPoint = new Point(parent.SegmentEndPoint.X, parent.SegmentEndPoint.Y);
				}
				else
				{
					var connectRightX = node.SegmentStartPoint.X + node.Size.Width;

					node.SegmentEndPoint = new Point(connectRightX, SegmentEndPoint.Y);
				}

				if (node.Nodes.Count != 0)
				{
					node.CalculateCoordinates();
				}
			}
		}

		/// <summary>
		/// Get <see cref="SerialCircuit"/> size
		/// </summary>
		/// <returns><see cref="SerialCircuit"/> size</returns>
		public override Size GetSegmentSize()
		{
			var height = GetMaxHeight();
			var width = 0;
			foreach (var node in Nodes)
			{
				var segmentNode = node as DrawableSegment;
				width += segmentNode.GetSegmentSize().Width;
			}

			Size = new Size(width, height);

			return Size;
		}

		private int GetMaxHeight()
		{
			if (Nodes.Count == 0) return 0;

			var sizeHeight = ((DrawableSegment) Nodes[0]).Size.Height;

			foreach (var node in Nodes)
			{
				if (node is DrawableSegment segmentNode && segmentNode.Size.Height > sizeHeight)
				{
					sizeHeight = segmentNode.Size.Height;
				}
			}

			return sizeHeight;
		}
}
}