using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impedance;

namespace ImpedanceApp
{
	public class DrawCircuit
	{
		/// <summary>
		/// Return main <see cref="DrawCircuitNode"/>
		/// </summary>
		public DrawCircuitNode Circuit { get; }

		/// <summary>
		/// Set and return start point
		/// </summary>
		public Point StartPoint { 
			get => Circuit.SegmentPoint;
			set => Circuit.SegmentPoint = value;
		} 

		/// <summary>
		/// DrawCircuit constructor
		/// </summary>
		/// <param name="segment"><see cref="Circuit"/></param>
		/// <param name="startPoint">Starting point for drawing</param>
		public DrawCircuit(ISegment segment)
		{
			if (!(segment is Circuit))
			{
				throw new ArgumentException(nameof(ISegment) + "is not " + nameof(Circuit));
			}

			Circuit = new DrawCircuitNode(null, segment);
			StartPoint = new Point();
			SetDrawCircuitNode(Circuit, segment);
			Circuit.CalculatePosition();
		}

		/// <summary>
		/// Connects all sub-segments of a segment
		/// </summary>
		/// <param name="parent">Parent <see cref="DrawCircuitNode"/></param>
		/// <param name="segment">The segment that will communicate with the parent</param>
		private static void SetDrawCircuitNode(DrawCircuitNode parent, ISegment segment)
		{
			foreach (var subSegment in segment.SubSegments)
			{
				var node = new DrawCircuitNode(parent, subSegment);
				parent.SubNodes.Add(node);
				if (!(subSegment is Element))
				{
					SetDrawCircuitNode(node, subSegment);
				}
			}
		}
	}
}
