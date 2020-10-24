using System;
using System.Drawing;
using Impedance;

namespace ImpedanceApp
{
	public class DrawParallelCircuit:DrawableSegment
	{
		/// <summary>
		/// Set and return segment size
		/// </summary>
		public override Size Size { get; set; }
		
		/// <summary>
		/// <see cref="DrawParallelCircuit"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="ParallelCircuit"/></param>
		public DrawParallelCircuit(ISegment segment)
		{
			Segment = segment;
		}

		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			var startX = ConnectToLeft.X;
			var endX = ConnectToRight.X;

			var leftTopCorner = new Point();
			var leftBottomCorner = new Point();
			var rightTopCorner = new Point();
			var rightBottomCorner = new Point();

			foreach (DrawableSegment node in Nodes)
			{
				if (node.Index == 0 )
				{
					leftTopCorner.X = startX;
					leftTopCorner.Y = node.ConnectToLeft.Y;
					rightTopCorner.X = endX;
					rightTopCorner.Y = node.ConnectToRight.Y;
				}

				if (node.Index == Nodes.Count - 1)
				{
					leftBottomCorner.X = startX;
					leftBottomCorner.Y = node.ConnectToLeft.Y;
					rightBottomCorner.X = endX;
					rightBottomCorner.Y = node.ConnectToRight.Y;
				}

				DrawConnect(new Point(ConnectToRight.X, node.ConnectToLeft.Y), node.ConnectToLeft,
					graphics, pen);
				node.DrawSegment(graphics, pen);
				DrawConnect(node.ConnectToLeft, new Point(ConnectToRight.X, node.ConnectToLeft.Y),
					graphics, pen);
			}

			if (Nodes.Count > 1)
			{
				DrawConnect(leftTopCorner, leftBottomCorner, graphics, pen);
				DrawConnect(rightTopCorner, rightBottomCorner, graphics, pen);
			}
		}

		public override void CalculateCoordinates()
		{
			if (Index == 0)
			{
				var parent = Parent as DrawableSegment;
				StartPoint = new Point(parent.StartPoint.X, parent.StartPoint.Y);
			}

			foreach (DrawableSegment node in Nodes)
			{
				if (Nodes.Count == 1)
				{
					node.StartPoint = StartPoint;
					return;
				}

				var y = StartPoint.Y;
				if(node.Index != 0)
				{
					if (node.PrevNode is DrawableSegment prevSegment)
					{
						y = prevSegment.StartPoint.Y + prevSegment.Size.Height + Range / 2;
					}
				}

				node.StartPoint = new Point(StartPoint.X, y);

				if (node.Nodes.Count != 0)
				{
					node.CalculateCoordinates();
				}
			}
		}

		public override Size GetSegmentSize()
		{
			var width = GetMaxWidth();
			var height = 0;
			foreach (var node in Nodes)
			{
				var segmentNode = node as DrawableSegment;
				height += segmentNode.GetSegmentSize().Height;
			}

			Size = new Size(width, height);

			return Size;
		}

		private int GetMaxWidth()
		{
			if (Nodes.Count == 0) return 0;

			var sizeWidth = ((DrawableSegment) Nodes[0]).GetSegmentSize().Width;

			foreach (DrawableSegment node in Nodes)
			{
				if (node.GetSegmentSize().Width > sizeWidth)
				{
					sizeWidth = node.GetSegmentSize().Width;
				}
			}

			return sizeWidth;
		}
	}
}