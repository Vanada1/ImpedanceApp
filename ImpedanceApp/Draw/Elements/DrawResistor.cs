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
		public override Size Size { get; set; } = new Size(30, 15);

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
		public override void Draw(Graphics graphics, Pen pen)
		{
			var rectangle = new Rectangle(StartPoint.X,
				StartPoint.Y, Size.Width, Size.Height);
			graphics.DrawRectangle(pen, rectangle);

			var parent = Parent as DrawableSegment;
			if (Index == 0)
			{
				DrawConnect(new Point(parent.StartPoint.X, ConnectToLeft.Y),
					ConnectToLeft, graphics, pen);
			}
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