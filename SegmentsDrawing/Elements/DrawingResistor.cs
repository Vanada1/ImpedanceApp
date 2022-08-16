using Impedance;

namespace SegmentsDrawing.Elements
{
	
	/// <summary>
	/// Draw <see cref="Resistor"/> class
	/// </summary>
	[SegmentTypeValidation(typeof(Resistor))]
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
		/// <see cref="DrawingResistor"/> constructor 
		/// </summary>
		public DrawingResistor()
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