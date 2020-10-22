using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public interface IDrawableSegment
	{
		/// <summary>
		/// Set and return <see cref="SegmentStartPoint"/>
		/// </summary>
		Point SegmentStartPoint { get; set; }

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		Point SegmentEndPoint { get; set; }

		/// <summary>
		/// Set and return segment size
		/// </summary>
		Size Size { get; set; }

		/// <summary>
		/// Set and return Serial segments count
		/// </summary>
		int SerialCircuitsCount { get; }

		/// <summary>
		/// Set and return Parallel segments count
		/// </summary>
		int ParallelCircuitsCount { get; }

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		ISegment Segment { get; set; }

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		void DrawSegment(Graphics graphics, Pen pen);

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		void CalculateCoordinates();

		/// <summary>
		/// Get Segment size
		/// </summary>
		/// <returns>Segment size</returns>
		Size GetSegmentSize();
	}
}