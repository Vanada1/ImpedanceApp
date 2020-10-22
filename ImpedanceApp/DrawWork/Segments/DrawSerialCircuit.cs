using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp.Segments
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
		/// Set and return Serial segments count
		/// </summary>
		public override int SerialCircuitsCount { get; set; } = 0;

		/// <summary>
		/// Set and return Parallel segments count
		/// </summary>
		public override int ParallelCircuitsCount { get; set; } = 0;

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
		DrawSerialCircuit(ISegment segment)
		{
			Segment = segment;
			Size = GetSegmentSize();
		}

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			throw new System.NotImplementedException();
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
				SegmentStartPoint = new Point(parent.SegmentStartPoint.X,
					parent.SegmentStartPoint.Y);
			}
			else
			{
				var prevNode = PrevNode as IDrawableSegment;
				SegmentStartPoint = new Point(prevNode.SegmentEndPoint.X + Range,
					prevNode.SegmentEndPoint.Y);
			}

			if (Index == parent.Nodes.Count - 1)
			{
				SegmentEndPoint = new Point(parent.SegmentEndPoint.X, parent.SegmentEndPoint.Y);
			}
			else
			{
				var connectRightX = SegmentStartPoint.X + SerialCircuitsCount * (ElementWidth + Range) - Range;

				SegmentEndPoint = new Point(connectRightX, SegmentEndPoint.Y);
			}

			if (Nodes.Count != 0)
			{
				(Nodes[0] as DrawableSegment)?.CalculateCoordinates();
			}

			(NextNode as DrawableSegment)?.CalculateCoordinates();
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

			return new Size(width, height);
		}

		private int GetMaxHeight()
		{
			var maxHeight = (Nodes[0] as DrawableSegment).Size.Height;

			foreach (var node in Nodes)
			{
				var segmentNode = node as DrawableSegment;
				if (segmentNode.Size.Height > maxHeight)
				{
					maxHeight = segmentNode.Size.Height;
				}
			}

			return maxHeight;
		}
}
}