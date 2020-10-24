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

		public override void Draw(Graphics graphics, Pen pen)
		{
			var startX = ConnectToLeft.X;
			var endX = ConnectToRight.X;

			foreach (DrawableSegment node in Nodes)
			{
				if (!(node is DrawElement) && node.Nodes.Count == 0)
				{
					continue;
				}

				DrawConnect(new Point(ConnectToLeft.X, node.ConnectToLeft.Y), 
					node.ConnectToLeft, graphics, pen);

				node.Draw(graphics, pen);

				DrawConnect(node.ConnectToRight, new Point(ConnectToRight.X, node.ConnectToRight.Y),
						graphics, pen);
			}

			if (Nodes.Count > 1)
			{
				var topY = (Nodes[0] as DrawableSegment).ConnectToLeft.Y;
				var bottomY = (Nodes[Nodes.Count - 1] as DrawableSegment).ConnectToLeft.Y;
				DrawConnect(new Point(startX, topY),
					new Point(startX, bottomY), graphics, pen);
				topY = (Nodes[0] as DrawableSegment).ConnectToRight.Y;
				bottomY = (Nodes[Nodes.Count - 1] as DrawableSegment).ConnectToRight.Y;
				DrawConnect(new Point(endX, topY),
					new Point(endX, bottomY), graphics, pen);
			}
		}

		public override void CalculatePoints()
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

				node.StartPoint = new Point(StartPoint.X + Range, y);

				if (node.Nodes.Count != 0)
				{
					node.CalculatePoints();
				}


				if (ConnectToRight.X == node.ConnectToRight.X)
				{
					ConnectToRight = new Point(ConnectToRight.X, ConnectToRight.Y);
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

			Size = new Size(width + Range, height);

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