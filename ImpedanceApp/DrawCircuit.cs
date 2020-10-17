using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impedance;

namespace ImpedanceApp
{
	class DrawCircuit
	{
		/// <summary>
		/// Return main <see cref="DrawCircuitNode"/>
		/// </summary>
		public DrawCircuitNode Circuit { get; }

		public DrawCircuit(ISegment segment)
		{
			if (!(segment is Circuit))
			{
				throw new ArgumentException(nameof(ISegment) + "is not " + nameof(Circuit));
			}

			Circuit = new DrawCircuitNode(null, segment);
			SetDrawCircuitNode(Circuit, segment);
		}

		private void SetDrawCircuitNode(DrawCircuitNode parent, ISegment segment)
		{
			foreach (var subSegment in segment.SubSegments)
			{
				var node = new DrawCircuitNode(parent, subSegment);
				parent.SubNodes.Add(node);
				if (!(subSegment is Element))
				{
					SetDrawCircuitNode(node, subSegment);
					node.CalculatePosition();
				}
			}
		}
	}
}
