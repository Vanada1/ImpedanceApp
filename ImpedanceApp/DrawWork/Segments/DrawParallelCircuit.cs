using System.Drawing;
using Impedance;

namespace ImpedanceApp.Segments
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
		/// <see cref="DrawParallelCircuit"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="ParallelCircuit"/></param>
		DrawParallelCircuit(ISegment segment)
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