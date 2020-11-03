using System;
using System.Drawing;
using Impedance;

namespace ImpedanceApp.Draw.Elements
{
	/// <summary>
	/// Draw <see cref="Inductor"/> class
	/// </summary>
	[SegmentTypeValidation(typeof(Inductor))]
	public class DrawingInductor:DrawingElementBase
	{
		/// <summary>
		/// Circle radius
		/// </summary>
		private const int CircleRadius = 10;

		/// <summary>
		/// Circle diameter 
		/// </summary>
		private const int CircleDiameter = CircleRadius * 2;

		/// <summary>
		/// Circle count in <see cref="Inductor"/>
		/// </summary>
		private const int CircleCount = 3;

		/// <summary>
		/// Start angle
		/// </summary>
		private const int StartAngle = 180;

		/// <summary>
		/// End angle
		/// </summary>
		private const int SweepAngle = 180;

		/// <summary>
		/// <see cref="DrawingInductor"/> constructor
		/// </summary>
		public DrawingInductor()
		{
			Size = new Size(CircleCount * CircleRadius, CircleDiameter);
		}
			
		/// <summary>
		/// Draw <see cref="Inductor"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void Draw(Graphics graphics, Pen pen)
		{
			DrawName(graphics);
			var x = StartPoint.X;
			var y = StartPoint.Y + CircleRadius / 2;

			for (int i = 0; i < CircleCount; i++)
			{
				graphics.DrawArc(pen,x,y, CircleRadius, CircleRadius, StartAngle, SweepAngle);
				x += CircleRadius;
			}

			var parent = Parent as DrawableSegmentBase;
			if (Index == 0)
			{
				DrawConnect(new Point(parent.StartPoint.X, ConnectToLeft.Y),
					ConnectToLeft, graphics, pen);
			}
		}
	}
}