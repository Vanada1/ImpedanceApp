using System.Drawing;
using Impedance;

namespace ImpedanceApp.Segments
{
	public class DrawCircuit : DrawableSegment
	{
		private const int StartPosition = 10;

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
		public override int SerialCircuitsCount { get; set; }

		/// <summary>
		/// Set and return Parallel segments count
		/// </summary>
		public override int ParallelCircuitsCount { get; set; }

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
		DrawCircuit(ISegment segment)
		{
			Segment = segment;
			Size = GetSegmentSize();
		}

		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			throw new System.NotImplementedException();
		}

		public override void CalculateCoordinates()
		{
			SegmentStartPoint = new Point(StartPosition, StartPosition * Size.Height / 2);
			var endX = SegmentStartPoint.X + Size.Width;
			SegmentEndPoint = new Point(endX, SegmentStartPoint.Y);
		}

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