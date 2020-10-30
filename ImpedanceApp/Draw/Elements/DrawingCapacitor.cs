using System;
using System.Drawing;
using Impedance;

namespace ImpedanceApp.Draw.Elements
{
	/// <summary>
	/// Draw <see cref="Capacitor"/> class
	/// </summary>
	[SegmentTypeValidation]
	public class DrawingCapacitor : DrawingElementBase
	{
		/// <summary>
		/// Distance between capacitor plates
		/// </summary>
		private const int DistancePlates = 9;

		/// <summary>
		/// Connect line
		/// </summary>
		private const int ConnectLine = DistancePlates * 2;

		/// <summary>
		/// Length of plates
		/// </summary>
		private const int LengthPlates = 10;

		/// <summary>
		/// <see cref="DrawingInductor"/> constructor
		/// </summary>
		public DrawingCapacitor()
		{
			Size = new Size(2 * ConnectLine + DistancePlates, LengthPlates * 2);
		}

		/// <summary>
		/// Draw <see cref="Capacitor"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void Draw(Graphics graphics, Pen pen)
		{
			DrawName(graphics);
			var x1 = ConnectToLeft.X;
			var y = ConnectToLeft.Y;
			var x2 = x1 + ConnectLine;
			graphics.DrawLine(pen, x1, y, x2, y);
			graphics.DrawLine(pen, x2, y - LengthPlates, x2, y + LengthPlates);
			x2 += DistancePlates;
			graphics.DrawLine(pen, x2, y - LengthPlates, x2, y + LengthPlates);
			graphics.DrawLine(pen, x2, y, x2 + ConnectLine, y);
			var parent = Parent as DrawableSegmentBase;
			if (Index == 0)
			{
				DrawConnect(new Point(parent.StartPoint.X, ConnectToLeft.Y),
					ConnectToLeft, graphics, pen);
			}
			
		}
	}
}