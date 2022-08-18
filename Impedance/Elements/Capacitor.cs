using System;
using System.Collections.Generic;
using System.Numerics;

namespace Impedance.Elements
{
	/// <summary>
	///     The <see cref="Capacitor" /> class contains information
	///     about the <see cref="Capacitor" />:
	///     <see cref="Name" />, <see cref="Value" />
	/// </summary>
	public class Capacitor : Element
	{
		/// <summary>
		///     Constructor <see cref="Capacitor" />
		/// </summary>
		/// <param name="name"> name of the element</param>
		/// <param name="value"> value of the element</param>
		public Capacitor(string name, double value) : base(name, value)
		{
			SegmentType = SegmentType.Capacitor;
		}

		/// <summary>
		///     Calculate impedance one element of <see cref="Capacitor" />
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns> <see cref="List{T}" /> impedance this <see cref="Capacitor" /></returns>
		public override Complex CalculateZ(double frequency)
		{
			var result = -1.0 / (2 * Math.PI * frequency * Value);
			return new Complex(0, result);
		}

		public override object Clone()
		{
			return new Capacitor(Name.Clone() as string, Value);
		}

		/// <summary>
		///     Converts an element to a string
		/// </summary>
		/// <returns>
		///     <see cref="Name" /> and <see cref="Value" /> string
		/// </returns>
		public override string ToString()
		{
			return $"{Name} = {Value} F";
		}
	}
}