using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Impedance
{
	public static class CircuitValidator
	{
		/// <summary>
		/// Create a new segment for the circuit
		/// </summary>
		/// <param name="segmentType">Segment type</param>
		/// <param name="name">Name of segment</param>
		/// <param name="value">Value of segment if it is
		/// <see cref="Impedance.Element"/></param>
		/// <param name="subSegments">Segment collection for circuit</param>
		public static ISegment CreateNewSegment(SegmentType segmentType, string name, 
			double value, SegmentObservableCollection subSegments)
		{
			ISegment segment = null;
			switch (segmentType)
			{
				case Impedance.SegmentType.Capacitor:
				{
					segment = new Capacitor(name, value);
					break;
				}

				case Impedance.SegmentType.Inductor:
				{
					segment = new Inductor(name, value);
					break;
				}

				case Impedance.SegmentType.Resistor:
				{
					segment = new Resistor(name, value);
					break;
				}

				case Impedance.SegmentType.SerialCircuit:
				{
					if (subSegments == null)
					{
						subSegments = new SegmentObservableCollection();
					}

					segment = new SerialCircuit(subSegments);
					break;
				}

				case Impedance.SegmentType.ParallelCircuit:
				{
					if (subSegments == null)
					{
						subSegments = new SegmentObservableCollection();
					}

					segment = new ParallelCircuit(subSegments);
					break;
				}
			}

			return segment;
		}

	}
}
