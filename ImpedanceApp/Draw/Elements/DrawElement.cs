using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
    //TODO: название не отражает, что это базовый абстрактный класс
	/// <summary>
	/// Base class for all elements
	/// </summary>
	public abstract class DrawElement : DrawableSegment
	{
		/// <summary>
		/// Font for Name Element
		/// </summary>
		private static readonly Font Font = new Font(FontFamily.GenericSerif, 11);

		/// <summary>
		/// For spelling a name
		/// </summary>
		private readonly Brush _brush = new SolidBrush(Color.Black);

		/// <summary>
		/// Size Inductor Element
		/// </summary>
		public override Size Size { get; set; }

		/// <summary>
		/// Name height
		/// </summary>
		private const int StringHeight = 16;

		/// <summary>
		/// Base constructor for all elements
		/// </summary>
		/// <param name="segment"><see cref="Element"/></param>
		protected DrawElement(ISegment segment)
		{
			Segment = segment;
		}

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public abstract override void Draw(Graphics graphics, Pen pen);

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public override void CalculatePoints()
		{
			if (!(Parent is DrawableSegment parent))
			{
				throw new ArgumentException("Parent is not " + nameof(DrawableSegment));
			}

			if (Index == 0)
			{
				StartPoint = new Point(parent.StartPoint.X,
					parent.StartPoint.Y);
			}
			else
			{
				var prevNode = PrevNode as DrawableSegment;
				StartPoint = new Point(prevNode.ConnectToRight.X,
					prevNode.StartPoint.Y);
			}

		}

		/// <summary>
		/// Draw element name
		/// </summary>
		/// <param name="graphics"></param>
		protected void DrawName(Graphics graphics)
		{
			var elementContour = new Rectangle(StartPoint.X, StartPoint.Y - Size.Height,
				Size.Width, StringHeight);
			var format = new StringFormat
			{
				Alignment = StringAlignment.Center,
			};

			graphics.DrawString(Segment.Name, Font, _brush, elementContour, format);
		}

		/// <summary>
		/// Get <see cref="Capacitor"/> size
		/// </summary>
		/// <returns><see cref="Capacitor"/> size</returns>
		public override Size CalculateSegmentSize()
		{
			return Size;
		}
	}
}