using System;
using Impedance;
using ImpedanceApp.Draw.Elements;
using ImpedanceApp.Draw.Segments;

namespace ImpedanceApp.Draw
{
	/// <summary>
	/// Attribute for converting <see cref="ISegment"/> in <see cref="DrawableSegmentBase"/>
	/// </summary>
	public class SegmentTypeValidationAttribute : Attribute

	{
		/// <summary>
		/// Get a type of <see cref="ISegment"/>
		/// </summary>
		/// <param name="segment"></param>
		/// <returns>Drawing segment</returns>
		public DrawableSegmentBase GetDrawingSegmentType(ISegment segment)
		{
			switch (segment)
			{
				case Resistor _:
				{
					return new DrawingResistor();
				}

				case Inductor _:
				{
					return new DrawingInductor();
				}

				case Capacitor _:
				{
					return new DrawingCapacitor();
				}

				case ParallelCircuit _:
				{
					return new DrawingParallelCircuit();
				}

				case SerialCircuit _:
				{
					return new DrawingSerialCircuit();
				}

				case Circuit _:
				{
					return new CircuitDrawer();
				}

				default:
				{
					throw new ArgumentException("Unknown Segment");
				}
			}
		}
	}
}