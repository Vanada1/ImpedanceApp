using System.Drawing;
using Impedance;

namespace ImpedanceApp
{
	public class DrawInductor:DrawElement
	{
		/// <summary>
		/// Circle radius
		/// </summary>
		private const int CircleRadius = 10;

		/// <summary>
		/// Start angle
		/// </summary>
		private const int StartAngle = 0;

		/// <summary>
		/// End angle
		/// </summary>
		private const int EndAngle = 180;

		/// <summary>
		/// Size Inductor Element
		/// </summary>
		public override Size Size { get; set; } = new Size(3 * CircleRadius, 2 * CircleRadius);

		/// <summary>
		/// <see cref="DrawInductor"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="Inductor"/></param>
		public DrawInductor(ISegment segment) : base(segment) { }

		/// <summary>
		/// Draw <see cref="Inductor"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void Draw(Graphics graphics, Pen pen)
		{
			var x = StartPoint.X;
			var y = StartPoint.Y + CircleRadius / 2;

			for (int i = 0; i < 3; i++)
			{
				graphics.DrawArc(pen,x,y, CircleRadius, CircleRadius, StartAngle, EndAngle);
				x += CircleRadius;
			}

			var parent = Parent as DrawableSegment;
			if (Index == 0)
			{
				DrawConnect(new Point(parent.StartPoint.X, ConnectToLeft.Y),
					ConnectToLeft, graphics, pen);
			}
		}

		/// <summary>
		/// Get <see cref="Inductor"/> size
		/// </summary>
		/// <returns><see cref="Inductor"/> size</returns>
		public override Size GetSegmentSize()
		{
			return Size;
		}
	}
}