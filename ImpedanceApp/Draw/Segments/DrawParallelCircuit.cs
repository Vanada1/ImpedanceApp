using System;
using System.Drawing;
using Impedance;

namespace ImpedanceApp
{
	/// <summary>
	/// Draw <see cref="ParallelCircuit"/> class
	/// </summary>
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

		/// <summary>
		/// Draw <see cref="ParallelCircuit"/>
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		public override void Draw(Graphics graphics, Pen pen)
		{
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

			if (Nodes.Count <= 1) return;

			var startX = ConnectToLeft.X;
			var topY = ((DrawableSegment) Nodes[0]).ConnectToLeft.Y;
			var bottomY = ((DrawableSegment) Nodes[Nodes.Count - 1]).ConnectToLeft.Y;
			DrawConnect(new Point(startX, topY),
				new Point(startX, bottomY), graphics, pen);

			var endX = ConnectToRight.X;
			topY = ((DrawableSegment) Nodes[0]).ConnectToRight.Y;
			bottomY = ((DrawableSegment) Nodes[Nodes.Count - 1]).ConnectToRight.Y;
			DrawConnect(new Point(endX, topY),
				new Point(endX, bottomY), graphics, pen);
		}

		/// <summary>
		/// Calculate all points for SubSegments of <see cref="ParallelCircuit"/>
		/// </summary>
		public override void CalculatePoints()
		{
			if (Index == 0)
			{
				var parent = Parent as DrawableSegment;
				StartPoint = new Point(parent.StartPoint.X, parent.StartPoint.Y);
				ConnectToLeft = new Point(StartPoint.X, parent.ConnectToLeft.Y);
			}

			foreach (DrawableSegment node in Nodes)
			{
				if (Nodes.Count == 1)
				{
					var parent = node.Parent as DrawableSegment;
					node.ConnectToLeft = new Point(StartPoint.X, parent.ConnectToLeft.Y);
					return;
				}

				var x = StartPoint.X + Size.Width / 2 - node.Size.Width / 2;

				var y = StartPoint.Y;
				if(node.Index != 0)
				{
					if (node.PrevNode is DrawableSegment prevSegment)
					{
						y = prevSegment.StartPoint.Y + prevSegment.Size.Height + Range;
					}
				}

				node.StartPoint = new Point(x, y);

				if (node.Nodes.Count != 0)
				{
					node.CalculatePoints();
				}


				while (ConnectToRight.X <= node.ConnectToRight.X)
				{
					Size = new Size(Size.Width + Range, Size.Height);
					ConnectToRight = new Point(ConnectToRight.X + Range, ConnectToRight.Y);
				}
			}
		}

		/// <summary>
		/// Calculate <see cref="ParallelCircuit"/> size
		/// </summary>
		/// <returns><see cref="ParallelCircuit"/> size</returns>
		public override Size CalculateSegmentSize()
		{
			if (Nodes.Count == 0) return new Size(0, 0);

			var width = FindMaxWidth() + Range;
			var height = 0;
			foreach (var node in Nodes)
			{
				var segmentNode = node as DrawableSegment;
				height += segmentNode.CalculateSegmentSize().Height + Range;
			}

			Size = new Size(width, height);

			return Size;
		}

		/// <summary>
		/// Find max Width between all SubSegments
		/// </summary>
		/// <returns>SubSegments max Width </returns>
		private int FindMaxWidth()
		{
			if (Nodes.Count == 0) return 0;

			var sizeWidth = ((DrawableSegment) Nodes[0]).CalculateSegmentSize().Width;

			foreach (DrawableSegment node in Nodes)
			{
				if (node.CalculateSegmentSize().Width > sizeWidth)
				{
					sizeWidth = node.CalculateSegmentSize().Width;
				}
			}

			return sizeWidth;
		}
	}
}