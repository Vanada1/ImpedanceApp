using System;
using System.Drawing;
using System.Security.Policy;
using System.Windows.Forms;
using Impedance;
using Impedance.Segments;

namespace ImpedanceApp.Draw.Segments
{
    /// <summary>
	/// Draw <see cref="Circuit"/> class
	/// </summary>
	[SegmentTypeValidation(typeof(Circuit))]
	public class CircuitDrawer : DrawingSerialCircuit
	{
		/// <summary>
		/// Scale picture size
		/// </summary>
		private const double Scale = 1;

		/// <summary>
		/// Start position for draw
		/// </summary>
		private int _startPosition = 0;

		/// <summary>
		/// Set and return Picture
		/// </summary>
		public PictureBox Picture { get; set; }

		/// <summary>
		/// <see cref="CircuitDrawer"/> constructor
		/// </summary>
		public CircuitDrawer():base(){}

		/// <summary>
		/// Draw <see cref="Circuit"/> 
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public void RedrawCircuit(Graphics graphics, Pen pen)
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
			foreach (DrawableSegmentBase node in Nodes)
			{
				if(node.Index != 0)
				{
					DrawConnect(((DrawableSegmentBase) node.PrevNode).ConnectToRight,
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

			foreach (DrawableSegmentBase node in Nodes)
			{
				node.CalculatePoints();
				if (node.Index == 0)
				{
					node.ConnectToLeft = new Point(node.ConnectToLeft.X, StartPoint.Y);
				}
				else
				{
					var prevNode = node.PrevNode as DrawableSegmentBase;
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

			const int addPixels = 50;
			const int scale = 2;
			var lastNode = Nodes[Nodes.Count - 1] as DrawableSegmentBase;
			var width = lastNode.ConnectToRight.X + addPixels;
			var maxHeight = FindMaxHeight();
			_startPosition = maxHeight / 2 + addPixels / scale;
			var height = maxHeight + addPixels * scale;
			Size = new Size(width, height);
			return Size;
		}
	}
}