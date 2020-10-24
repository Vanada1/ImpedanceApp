using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public class DrawCircuit : DrawSerialCircuit
	{
		private int _startPosition = 0;

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
			GetSegmentSize();
			if (Size.Width == 0 && Size.Height == 0)
			{
				Size = new Size(Picture.Size.Width - Range, Picture.Size.Height - Range);
			}
			CalculateCoordinates();
			var bitmap = new Bitmap(Size.Width, Size.Height);
			graphics = Graphics.FromImage(bitmap);

			foreach (DrawableSegment node in Nodes)
			{
				if(node.Index != 0)
				{
					DrawConnect(((DrawableSegment) node.PrevNode).ConnectToRight,
						node.ConnectToLeft, graphics, pen);
				}
				node.DrawSegment(graphics, pen);
			}

			Picture.Image = bitmap;
		}

		public override void CalculateCoordinates()
		{
			StartPoint = new Point(0, _startPosition);
			
			foreach (DrawableSegment node in Nodes)
			{
				node.CalculateCoordinates();

				if (node.Index != 0)
				{
					var prevNode = node.PrevNode as DrawableSegment;
					node.StartPoint = new Point(prevNode.ConnectToRight.X + Range, prevNode.StartPoint.Y);
					node.ConnectToLeft = new Point(node.ConnectToLeft.X, prevNode.ConnectToRight.Y);
				}
			}
		}

		public override Size GetSegmentSize()
		{
			if(Nodes.Count == 0) return new Size();

			var lastNode = Nodes[Nodes.Count - 1] as DrawableSegment;

			var width = lastNode.ConnectToRight.X + lastNode.Size.Width;
			var height = GetMaxHeight() + Range;
			_startPosition = height / 2;
			height *= 2;
			Size = new Size(width, height);
			return Size;
		}
	}
}