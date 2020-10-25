using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	/// <summary>
	/// Draw <see cref="SerialCircuit"/> class
	/// </summary>
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
		/// Draw <see cref="SerialCircuit"/> segment
		/// </summary>
		public override void Draw(Graphics graphics, Pen pen)
		{
			foreach (DrawableSegment node in Nodes)
			{
				if (node.Index == 0)
				{
					DrawConnect(new Point(StartPoint.X, node.ConnectToLeft.Y),
						ConnectToLeft, graphics, pen);
				}
				else
				{
					DrawConnect(((DrawableSegment) node.PrevNode).ConnectToRight,
						node.ConnectToLeft, graphics, pen);
				}

				node.Draw(graphics, pen);

				if (node.Index == Nodes.Count - 1)
				{
					DrawConnect(node.ConnectToRight,
						new Point(ConnectToRight.X, node.ConnectToRight.Y),
						graphics, pen);
				}
			}
		}

		/// <summary>
		/// Calculating the coordinates for each node
		/// </summary>
		public override void CalculatePoints()
		{
			if (!(Parent is DrawableSegment parent))
			{
				throw new ArgumentException("Parent is not " + nameof(DrawableSegment));
			}

			if (Index == 0)
			{
				if (parent is DrawCircuit)
				{
					ConnectToLeft = new Point(parent.StartPoint.X + Range, parent.StartPoint.Y);
				}
				else
				{
					StartPoint = new Point(parent.StartPoint.X + Range, parent.StartPoint.Y);
				}
			}

			foreach (DrawableSegment node in Nodes)
			{
				if (node == null) continue;

				if (!(node is DrawElement) && node.Nodes.Count == 0)
				{
					node.Remove();
					continue;
				}

				if (node.Index == 0)
				{
					node.ConnectToLeft = new Point(StartPoint.X,
						ConnectToLeft.Y);
				}
				else
				{
					var prevNode = node.PrevNode as DrawableSegment;
					node.ConnectToLeft = new Point(prevNode.ConnectToRight.X + Range,
						ConnectToRight.Y);
				}

				if (node.Nodes.Count != 0)
				{
					node.CalculatePoints();
				}
			}
		}

		/// <summary>
		/// Get <see cref="SerialCircuit"/> size
		/// </summary>
		/// <returns><see cref="SerialCircuit"/> size</returns>
		public override Size CalculateSegmentSize()
		{
			if (Nodes.Count == 0) return new Size(0, 0);

			var height = FindMaxHeight();
			var width = 0;
			foreach (DrawableSegment node in Nodes)
			{
				width += node.CalculateSegmentSize().Width + Range;
			}

			Size = new Size(width, height);

			return Size;
		}

		/// <summary>
		/// Find max Height between all SubSegments
		/// </summary>
		/// <returns>SubSegments max Height </returns>
		protected int FindMaxHeight()
		{
			if (Nodes.Count == 0) return 0;

			var sizeHeight = ((DrawableSegment) Nodes[0]).CalculateSegmentSize().Height;

			foreach (DrawableSegment node in Nodes)
			{
				if (node.CalculateSegmentSize().Height > sizeHeight)
				{
					sizeHeight = node.Size.Height;
				}
			}

			return sizeHeight + Range;
		}
}
}