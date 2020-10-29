using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	/// <summary>
	/// Draw <see cref="Resistor"/> class
	/// </summary>
	public class DrawingResistor : DrawingElement
	{
		/// <summary>
		/// Rectangle width
		/// </summary>
		private const int Width = 30;

		/// <summary>
		/// Rectangle height
		/// </summary>
		private const int Height = 15;

        //TODO: здесь, в других классах и в самом интерфейсе - архитектура позволяет, ...
        // например, передать в отрисовщик резистора элемент индуктор. ...
        // Нет защиты по типам данных, что приведет к ошибкам работы. Подумай, как можно обеспечить защиту типов.
		/// <summary>
		/// <see cref="DrawingResistor"/> constructor 
		/// </summary>
		/// <param name="segment"><see cref="Resistor"/></param>
		public DrawingResistor(ISegment segment) : base(segment)
		{
			Size = new Size(Width, Height);
		}

		/// <summary>
		/// Draw <see cref="Resistor"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void Draw(Graphics graphics, Pen pen)
		{
			DrawName(graphics);
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
	}
}