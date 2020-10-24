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
		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			var x = StartPoint.X + CircleRadius;
			var y = StartPoint.Y + CircleRadius / 2;

			for (int i = 0; i < 3; i++)
			{
				graphics.DrawArc(pen,x,y, CircleRadius, CircleRadius, StartAngle, EndAngle);
				x += CircleRadius;
			}
		}

		/// <summary>
		/// Get <see cref="Inductor"/> size
		/// </summary>
		/// <returns><see cref="Inductor"/> size</returns>
		public override Size GetSegmentSize()
		{
			return new Size(Size.Width + Range, Size.Height);
		}
	}
}