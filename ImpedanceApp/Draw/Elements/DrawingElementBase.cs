using System;
using System.Drawing;
using Impedance;

namespace ImpedanceApp.Draw.Elements
{
    //TODO: название не отражает, что это базовый абстрактный класс (Done)
	/// <summary>
	/// Base class for all elements
	/// </summary>
	public abstract class DrawingElementBase : DrawableSegmentBase
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
		/// Name height
		/// </summary>
		private const int StringHeight = 16;

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public abstract override void Draw(Graphics graphics, Pen pen);

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public override void CalculatePoints()
		{
			if (!(Parent is DrawableSegmentBase parent))
			{
				throw new ArgumentException("Parent is not " + nameof(DrawableSegmentBase));
			}

			if (Index == 0)
			{
				StartPoint = new Point(parent.StartPoint.X,
					parent.StartPoint.Y);
			}
			else
			{
				var prevNode = PrevNode as DrawableSegmentBase;
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

			graphics.DrawString(Name, Font, _brush, elementContour, format);
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