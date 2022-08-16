using System;
using Impedance;

namespace SegmentsDrawing.Segments
{
	/// <summary>
	/// Draw <see cref="SerialCircuit"/> class
	/// </summary>
	[SegmentTypeValidation(typeof(SerialCircuit))]
	public class DrawingSerialCircuit : DrawableSegmentBase
	{
		/// <summary>
		/// <see cref="DrawingSerialCircuit"/> constructor
		/// </summary>
		public DrawingSerialCircuit(){}

		/// <summary>
		/// Draw <see cref="SerialCircuit"/> segment
		/// </summary>
		public override void Draw(Graphics graphics, Pen pen)
		{
			foreach (DrawableSegmentBase node in Nodes)
			{
				if (node.Index == 0)
				{
					DrawConnect(new Point(StartPoint.X, node.ConnectToLeft.Y),
						ConnectToLeft, graphics, pen);
				}
				else
				{
					DrawConnect(((DrawableSegmentBase) node.PrevNode).ConnectToRight,
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
			if (!(Parent is DrawableSegmentBase parent))
			{
				throw new ArgumentException("Parent is not " + nameof(DrawableSegmentBase));
			}

			foreach (DrawableSegmentBase node in Nodes)
			{
				if (node.Index == 0)
				{
					node.ConnectToLeft = new Point(StartPoint.X,
						ConnectToLeft.Y);
				}
				else
				{
					var prevNode = node.PrevNode as DrawableSegmentBase;
					node.ConnectToLeft = new Point(prevNode.ConnectToRight.X + Range,
						prevNode.ConnectToRight.Y);
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
			foreach (DrawableSegmentBase node in Nodes)
			{
				width += node.CalculateSegmentSize().Width + Range;
			}

			width -= Range;
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

			var sizeHeight = ((DrawableSegmentBase) Nodes[0]).CalculateSegmentSize().Height;

			foreach (DrawableSegmentBase node in Nodes)
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