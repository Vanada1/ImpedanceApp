using System;
using System.Drawing;
using Impedance;

namespace ImpedanceApp.Draw.Elements
{
	/// <summary>
	/// Draw <see cref="Resistor"/> class
	/// </summary>
	public class DrawingResistor : DrawingElementBase
	{
		/// <summary>
		/// Rectangle width
		/// </summary>
		private const int Width = 30;

		/// <summary>
		/// Rectangle height
		/// </summary>
		private const int Height = 15;

		/// <summary>
		/// Segment of the class
		/// </summary>
		private ISegment _segment;

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		public override ISegment Segment
		{
			get => _segment;
			set
			{
				if (!(value is Resistor))
				{
					throw new ArgumentException("It's not " + nameof(Resistor));
				}

				_segment = value;
			}
		}

		//TODO: здесь, в других классах и в самом интерфейсе - архитектура позволяет, ...(Done)
		// например, передать в отрисовщик резистора элемент индуктор. ...(Done)
		// Нет защиты по типам данных, что приведет к ошибкам работы. Подумай, как можно обеспечить защиту типов. (Done)
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

			var parent = Parent as DrawableSegmentBase;
			if (Index == 0)
			{
				DrawConnect(new Point(parent.StartPoint.X, ConnectToLeft.Y),
					ConnectToLeft, graphics, pen);
			}
		}
	}
}