using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public abstract class DrawElement : DrawableSegment
	{
		/// <summary>
		/// Element
		/// </summary>
		private ISegment _element;

		/// <summary>
		/// Set and return <see cref="SegmentStartPoint"/>
		/// </summary>
		public override Point SegmentStartPoint { get; set; }

		/// <summary>
		/// Set and return connect position to the element of right side
		/// </summary>
		public override Point SegmentEndPoint { get; set; }

		/// <summary>
		/// Set and return element size
		/// </summary>
		public abstract override Size Size { get; set; }

		/// <summary>
		/// Set and return element <see cref="ISegment"/>
		/// </summary>
		public override ISegment Segment
		{
			get=> _element;
			set
			{
				if (!(value is Element))
				{
					throw new ArgumentException("Segment is not element");
				}

				_element = value;
			}
		}

		protected DrawElement(ISegment segment)
		{
			Segment = segment;
			Size = new Size(ElementWidth, ElementHeight);
		}

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public abstract override void DrawSegment(Graphics graphics, Pen pen);

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
				SegmentStartPoint = new Point(parent.SegmentStartPoint.X,
					parent.SegmentStartPoint.Y);
			}
			else
			{
				var prevNode = PrevNode as IDrawableSegment;
				SegmentStartPoint = new Point(prevNode.SegmentEndPoint.X + Range,
					prevNode.SegmentEndPoint.Y);
			}

			if (Index == parent.Nodes.Count - 1)
			{
				SegmentEndPoint = new Point(parent.SegmentEndPoint.X, parent.SegmentEndPoint.Y);
			}
			else
			{
				var connectRightX = SegmentStartPoint.X + Size.Width;

				SegmentEndPoint = new Point(connectRightX, SegmentStartPoint.Y);
			}
		}
	}
}