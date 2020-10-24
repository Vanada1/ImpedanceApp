using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public class DrawSerialCircuit : DrawableSegment
	{
		/// <summary>
		/// Set and return segment size
		/// </summary>
		public override Size Size { get; set; }
		
		/// <summary>
		/// <see cref="DrawSerialCircuit"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="SerialCircuit"/></param>
		public DrawSerialCircuit(ISegment segment)
		{
			Segment = segment;
		}

		/// <summary>
		/// Draw Serial segment
		/// </summary>
		public override void DrawSegment(Graphics graphics, Pen pen)
		{
			foreach (DrawableSegment node in Nodes)
			{
				DrawConnect(node.Index == 0 ? ConnectToLeft : ((DrawableSegment) node.PrevNode).ConnectToRight,
					node.ConnectToLeft, graphics, pen);

				node.DrawSegment(graphics, pen);

				if (node.Index == Nodes.Count - 1)
				{
					DrawConnect(node.ConnectToRight, ConnectToRight, graphics, pen);
				}
			}
		}

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public override void CalculateCoordinates()
		{
			if (!(Parent is DrawableSegment parent))
			{
				throw new ArgumentException("Parent is not " + nameof(DrawableSegment));
			}

			if (Index == 0)
			{
				StartPoint = (Parent as DrawableSegment).StartPoint;
			}

			foreach (DrawableSegment node in Nodes)
			{
				if (node.Index == 0)
				{
					node.StartPoint = new Point(StartPoint.X,
						StartPoint.Y);
				}
				else
				{
					var prevNode = node.PrevNode as DrawableSegment;
					node.StartPoint = new Point(prevNode.ConnectToRight.X + Range,
						prevNode.StartPoint.Y);
				}

				if (node.Nodes.Count != 0)
				{
					node.CalculateCoordinates();
				}

				if (node.Index != 0)
				{
					var prevNode = node.PrevNode as DrawableSegment;
					node.ConnectToLeft = new Point(node.ConnectToLeft.X, prevNode.ConnectToRight.Y);
				}
			}
		}

		/// <summary>
		/// Get <see cref="SerialCircuit"/> size
		/// </summary>
		/// <returns><see cref="SerialCircuit"/> size</returns>
		public override Size GetSegmentSize()
		{
			var height = GetMaxHeight();
			var width = 0;
			foreach (DrawableSegment node in Nodes)
			{
				width += node.GetSegmentSize().Width;
			}

			Size = new Size(width, height);

			return Size;
		}

		protected int GetMaxHeight()
		{
			if (Nodes.Count == 0) return 0;

			var sizeHeight = ((DrawableSegment) Nodes[0]).GetSegmentSize().Height;

			foreach (DrawableSegment node in Nodes)
			{
				if (node.GetSegmentSize().Height > sizeHeight)
				{
					sizeHeight = node.Size.Height;
				}
			}

			return sizeHeight;
		}
}
}