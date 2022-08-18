using System;
using Impedance.Elements;
using Impedance.Interface;
using Impedance.Segments;

namespace Impedance.Managers
{
	/// <summary>
	/// Serves class for circuit
	/// </summary>
	public static class CircuitManager
	{
		/// <summary>
		/// Create a new segment for the circuit
		/// </summary>
		/// <param name="segmentType">Segment type</param>
		/// <param name="name">Name of segment</param>
		/// <param name="value">Value of segment if it is
		/// <see cref="Element"/></param>
		/// <param name="subSegments">Segment collection for circuit</param>
		public static ISegment CreateNewSegment(SegmentType segmentType, string name, 
			double value, SegmentObservableCollection subSegments)
		{
			ISegment segment = null;
			switch (segmentType)
			{
				case SegmentType.Capacitor:
				{
					segment = new Capacitor(name, value);
					break;
				}

				case SegmentType.Inductor:
				{
					segment = new Inductor(name, value);
					break;
				}

				case SegmentType.Resistor:
				{
					segment = new Resistor(name, value);
					break;
				}

				case SegmentType.SerialCircuit:
				{
					if (subSegments == null)
					{
						subSegments = new SegmentObservableCollection();
					}

					segment = new SerialCircuit(subSegments);
					break;
				}

				case SegmentType.ParallelCircuit:
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

		/// <summary>
		/// Create new segment by string parameters.
		/// </summary>
		/// <param name="segmentType">Segment type.</param>
		/// <param name="name">Segment name.</param>
		/// <param name="value">Segment value.</param>
		/// <returns>New segment.</returns>
		/// <exception cref="ArgumentException">If cannot get value from string.</exception>
		public static ISegment CreateNewElement(SegmentType segmentType, string name, string value)
		{
			if (!double.TryParse(value, out var doubleValue))
			{
				throw new ArgumentException(@"Incorrect value. Enter the number.");
			}

			return CreateNewSegment(segmentType, name, doubleValue,
				null);
		}
	}
}
