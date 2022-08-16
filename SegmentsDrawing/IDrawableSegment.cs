﻿using System.Windows;
using System.Windows.Media;

namespace SegmentsDrawing
{
	/// <summary>
	/// Draw segments interface
	/// </summary>
	public interface IDrawableSegment
	{
		/// <summary>
		/// Set and return <see cref="StartPoint"/>
		/// </summary>
		Point StartPoint { get; set; }

		/// <summary>
		/// Set and return connect position to the element of left side
		/// </summary>
		Point ConnectToLeft { get; set; }

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		Point ConnectToRight { get; set; }

		/// <summary>
		/// Set and return segment size
		/// </summary>
		Size Size { get; set; }

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		void Draw(DrawingContext graphics, Pen pen);

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		void CalculatePoints();

		/// <summary>
		/// Get Segment size
		/// </summary>
		/// <returns>Segment size</returns>
		Size CalculateSegmentSize();
	}
}