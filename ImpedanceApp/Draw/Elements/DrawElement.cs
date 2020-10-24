using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public abstract class DrawElement : DrawableSegment
	{
		protected DrawElement(ISegment segment)
		{
			Segment = segment;
		}

		/// <summary>
		/// Method for drawing segment
		/// </summary>
		public abstract override void Draw(Graphics graphics, Pen pen);

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
				StartPoint = new Point(parent.StartPoint.X,
					parent.StartPoint.Y);
			}
			else
			{
				var prevNode = PrevNode as DrawableSegment;
				StartPoint = new Point(prevNode.ConnectToRight.X,
					prevNode.StartPoint.Y);
			}

		}
	}
}