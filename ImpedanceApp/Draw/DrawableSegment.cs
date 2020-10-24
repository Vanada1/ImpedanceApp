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
		protected const int Range = 20;

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
		public abstract Size Size { get; set; }

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		public ISegment Segment { get; set; }

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public abstract void DrawSegment(Graphics graphics, Pen pen);

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public abstract void CalculateCoordinates();

		/// <summary>
		/// Get segment size
		/// </summary>
		/// <returns>Segment size</returns>
		public abstract Size GetSegmentSize();

		/// <summary>
		/// Draw connection
		/// </summary>
		/// <param name="startPoint">Start Point</param>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		protected static void DrawConnect(Point startPoint, Graphics graphics, Pen pen)
		{
			var x = startPoint.X;
			var y = startPoint.Y;
			graphics.DrawLine(pen, x, y, x + Range, y);
		}

		/// <summary>
		/// Method for drawing connection line
		/// </summary>
		/// <param name="startPoint"></param>
		/// <param name="endPoint"></param>
		/// /// <param name="graphics"></param>
		/// <param name="pen"></param>
		protected static void DrawConnect(Point startPoint, Point endPoint, Graphics graphics, Pen pen)
		{
			graphics.DrawLine(pen, startPoint, endPoint);
		}
	}
}