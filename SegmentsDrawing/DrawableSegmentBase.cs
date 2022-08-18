using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Impedance;
using Impedance.Segments;

namespace SegmentsDrawing
{
    /// <summary>
	/// Base class for all Segments of <see cref="Circuit"/>
	/// </summary>
	public abstract class DrawableSegmentBase : TreeViewItem, IDrawableSegment
	{
		/// <summary>
		/// Range between Segments
		/// </summary>
		protected const int Range = 10;

		/// <summary>
		/// Segment point
		/// </summary>
		private Point _startPoint;

		/// <summary>
		/// Connect point to left
		/// </summary>
		private Point _connectToLeft;

		/// <summary>
		/// Connect point to right
		/// </summary>
		private Point _connectToRight;

		/// <summary>
		/// Set and return connect position to the element of left side
		/// </summary>
		public Point ConnectToLeft
		{
			get => _connectToLeft;
			set
			{
				_connectToLeft = value;
				_connectToRight = new Point(value.X + Size.Width, value.Y);
				_startPoint = new Point(value.X, value.Y - Size.Height / 2);
			}
		}

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		public Point ConnectToRight
		{
			get => _connectToRight;
			set
			{
				_connectToRight = value;
				_connectToLeft = new Point(value.X - Size.Width, value.Y);
				_startPoint = new Point(value.X - Size.Width, value.Y - Size.Height / 2);
			}
		}

		/// <summary>
		/// Set and return <see cref="StartPoint"/>
		/// </summary>
		public Point StartPoint 
		{
			get => _startPoint;
			set
			{
				_startPoint = value;
				_connectToLeft = new Point(value.X,
					value.Y + Size.Height / 2);
				_connectToRight = new Point(value.X + Size.Width,
					value.Y + Size.Height / 2);
			}
		}

		/// <summary>
		/// Set and return segment size
		/// </summary>
		public Size Size { get; set; }

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public abstract void Draw(DrawingContext graphics, Pen pen);

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public abstract void CalculatePoints();

		/// <summary>
		/// Get segment size
		/// </summary>
		/// <returns>Segment size</returns>
		public abstract Size CalculateSegmentSize();

		/// <summary>
		/// Method for drawing connection line
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="endPoint"></param>
		/// /// <param name="graphics"></param>
		/// <param name="pen"></param>
		protected void DrawConnect(Point startPoint, Point endPoint, DrawingContext graphics, Pen pen)
		{
			graphics.DrawLine(pen, startPoint, endPoint);
		}
	}
}