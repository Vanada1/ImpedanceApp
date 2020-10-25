using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	/// <summary>
	/// Draw <see cref="Circuit"/> class
	/// </summary>
	public class DrawCircuit : DrawSerialCircuit
	{
		/// <summary>
		/// Start position for draw
		/// </summary>
		private int _startPosition = 0;

		/// <summary>
		/// Scale picture size
		/// </summary>
		private const double Scale = 1;

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

		/// <summary>
		/// Draw <see cref="Circuit"/> 
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public void DrawNewCircuit(Graphics graphics, Pen pen)
		{
			CalculateSegmentSize();
			if (Size.Width == 0 && Size.Height == 0)
			{
				Size = new Size(Picture.Size.Width - Range, Picture.Size.Height - Range);
			}

			CalculatePoints();
			var bitmap = new Bitmap(Size.Width, Size.Height);
			graphics = Graphics.FromImage(bitmap);
			// Для проверки границ картинки
			//graphics.DrawRectangle(pen, 0, 0, Size.Width-1, Size.Height-1);
			foreach (DrawableSegment node in Nodes)
			{
				if(node.Index != 0)
				{
					DrawConnect(((DrawableSegment) node.PrevNode).ConnectToRight,
						node.ConnectToLeft, graphics, pen);
				}
				node.Draw(graphics, pen);
			}

			bitmap = new Bitmap(bitmap, new Size((int)(Size.Width * Scale), (int)(Size.Height * Scale)));
			Picture.Image = bitmap;
		}

		/// <summary>
		/// Calculate all points for segments
		/// </summary>
		public override void CalculatePoints()
		{
			StartPoint = new Point(0, _startPosition);

			foreach (DrawableSegment node in Nodes)
			{
				node.CalculatePoints();
				if (node.Index == 0)
				{
					node.ConnectToLeft = new Point(node.ConnectToLeft.X, StartPoint.Y);
				}
				else
				{
					var prevNode = node.PrevNode as DrawableSegment;
					node.StartPoint = new Point(prevNode.ConnectToRight.X + Range, prevNode.StartPoint.Y);
					node.ConnectToLeft = new Point(node.ConnectToLeft.X, StartPoint.Y);
				}
			}
		}

		/// <summary>
		/// Calculate <see cref="Circuit"/> size
		/// </summary>
		/// <returns><see cref="Circuit"/> size</returns>
		public override Size CalculateSegmentSize()
		{
			if(Nodes.Count == 0) return new Size();

			const int addPixel = 50;
			const int scale = 5;
			var lastNode = Nodes[Nodes.Count - 1] as DrawableSegment;
			var width = lastNode.ConnectToRight.X;
			var maxHeight = FindMaxHeight();
			_startPosition = maxHeight / 2 + addPixel / scale;
			var height = maxHeight + addPixel;
			Size = new Size(width, height);
			return Size;
		}
	}
}