using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public abstract class DrawableSegment : TreeNode, IDrawableSegment
	{
		/// <summary>
		/// Range between Segments
		/// </summary>
		protected const int Range = 10;

		/// <summary>
		/// Default element width
		/// </summary>
		protected const int ElementWidth = 50;

		/// <summary>
		/// Default element height
		/// </summary>
		protected const int ElementHeight = 25;

		/// <summary>
		/// Set and return <see cref="SegmentStartPoint"/>
		/// </summary>
		public abstract Point SegmentStartPoint { get; set; }

		/// <summary>
		/// Set and return segment size
		/// </summary>
		public abstract Size Size { get; set; }

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		public abstract Point SegmentEndPoint { get; set; }

		/// <summary>
		/// Set and return Serial segments count
		/// </summary>
		public abstract int SerialCircuitsCount { get; set; }

		/// <summary>
		/// Set and return Parallel segments count
		/// </summary>
		public abstract int ParallelCircuitsCount { get; set; }

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		public abstract ISegment Segment { get; set; }

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public abstract void DrawSegment(Graphics graphics, Pen pen);

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public abstract void CalculateCoordinates();

		public abstract Size GetSegmentSize();
	}
}