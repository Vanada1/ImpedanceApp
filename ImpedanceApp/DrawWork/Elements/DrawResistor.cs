using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public class DrawResistor : DrawElement
	{
		/// <summary>
		/// Size <see cref="Resistor"/> Element 
		/// </summary>
		public override Size Size { get; set; } = new Size(40, 20);

		/// <summary>
		/// <see cref="DrawResistor"/> constructor 
		/// </summary>
		/// <param name="segment"><see cref="Resistor"/></param>
		public DrawResistor(ISegment segment) : base(segment) { }

		/// <summary>
		/// Draw <see cref="Resistor"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			var rectangle = new Rectangle(SegmentStartPoint.X + Range,
				SegmentStartPoint.Y - Range, Size.Width, Size.Height);
			graphics.DrawRectangle(pen, rectangle);
		}

		/// <summary>
		/// Get <see cref="Resistor"/> size
		/// </summary>
		/// <returns><see cref="Resistor"/> size</returns>
		public override Size GetSegmentSize()
		{
			return new Size(Size.Width + Range, Size.Height);
		}
	}
}