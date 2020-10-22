using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public class DrawCircuit : DrawSerialCircuit
	{
		private const int StartPosition = 10;

		/// <summary>
		/// Set and return Picture
		/// </summary>
		public static PictureBox Picture { get; set; }

		/// <summary>
		/// <see cref="DrawSerialCircuit"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="SerialCircuit"/></param>
		public DrawCircuit(ISegment segment) : base(segment)
		{ }

		public void DrawNewCircuit(Graphics graphics, Pen pen)
		{
			CalculateCoordinates();
			var bitmap = new Bitmap(Size.Width, Size.Height);
			graphics = Graphics.FromImage(bitmap);

			foreach (DrawableSegment node in Nodes)
			{
				node.DrawSegment(graphics, pen);
			}
			Picture.Image = bitmap;
		}

		public override void CalculateCoordinates()
		{
			foreach (DrawableSegment node in Nodes)
			{
				SegmentStartPoint = new Point(StartPosition, StartPosition * Size.Height / 2);
				var endX = SegmentStartPoint.X + Size.Width;
				SegmentEndPoint = new Point(endX, SegmentStartPoint.Y);

				if (Nodes.Count != 0)
				{
					(Nodes[0] as DrawableSegment)?.CalculateCoordinates();
				}
			}
		}
	}
}