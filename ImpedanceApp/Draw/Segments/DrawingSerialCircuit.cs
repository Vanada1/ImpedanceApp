using System;
using System.Drawing;
using Impedance;
using ImpedanceApp.Draw.Elements;

namespace ImpedanceApp.Draw.Segments
{
	/// <summary>
	/// Draw <see cref="SerialCircuit"/> class
	/// </summary>
	public class DrawingSerialCircuit : DrawableSegmentBase
	{
		/// <summary>
		/// Segment of the class
		/// </summary>
		private ISegment _segment;

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		public override ISegment Segment
		{
			get => _segment;
			set
			{
				if (!(value is SerialCircuit))
				{
					throw new ArgumentException("It's not " + nameof(SerialCircuit));
				}

				_segment = value;
			}
		}

		/// <summary>
		/// <see cref="DrawingSerialCircuit"/> constructor
		/// </summary>
		/// <param name="segment"><see cref="SerialCircuit"/></param>
		public DrawingSerialCircuit(ISegment segment)
		{
			Segment = segment;
		}

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

			if (Index == 0)
			{
				if (parent is CircuitDrawer)
				{
					ConnectToLeft = new Point(parent.StartPoint.X + Range, parent.StartPoint.Y);
				}
				else
				{
					StartPoint = new Point(parent.StartPoint.X + Range, parent.StartPoint.Y);
				}
			}

			foreach (DrawableSegmentBase node in Nodes)
			{
				if (node == null) continue;

				if (!(node is DrawingElementBase) && node.Nodes.Count == 0)
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