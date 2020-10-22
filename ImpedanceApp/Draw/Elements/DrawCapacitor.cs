﻿using System.Drawing;
using Impedance;

namespace ImpedanceApp
{
	public class DrawCapacitor : DrawElement
	{
		/// <summary>
		/// Distance between capacitor plates
		/// </summary>
		private const int DistancePlates = 6;

		/// <summary>
		/// Connect line
		/// </summary>
		private const int ConnectLine = DistancePlates * 2;

		/// <summary>
		/// Length of plates
		/// </summary>
		private const int LengthPlates = 10;

		/// <summary>
		/// Size Inductor Element
		/// </summary>
		public override Size Size { get; set; } = new Size(2 * ConnectLine + DistancePlates, LengthPlates * 2);

		/// <summary>
		/// <see cref="DrawInductor"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="Capacitor"/></param>
		public DrawCapacitor(ISegment segment) : base(segment) { }

		/// <summary>
		/// Draw <see cref="Capacitor"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			var x1 = SegmentStartPoint.X + Range;
			var y = SegmentStartPoint.Y;
			var x2 = x1 + ConnectLine;
			graphics.DrawLine(pen, x1, y, x2, y);
			graphics.DrawLine(pen, x2, y - LengthPlates, x2, y + LengthPlates);
			x2 += DistancePlates;
			graphics.DrawLine(pen, x2, y - LengthPlates, x2, y + LengthPlates);
			graphics.DrawLine(pen, x2, y, x2 + ConnectLine, y);
		}

		/// <summary>
		/// Get <see cref="Capacitor"/> size
		/// </summary>
		/// <returns><see cref="Capacitor"/> size</returns>
		public override Size GetSegmentSize()
		{
			return new Size(Size.Width + Range, Size.Height);
		}
	}
}