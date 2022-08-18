using System;
using System.Collections.Generic;
using System.Numerics;

namespace Impedance.Elements
{
	/// <summary>
	///     The <see cref="Inductor" /> class contains information
	///     about the <see cref="Inductor" />:
	///     <see cref="Name" />, <see cref="Value" />
	/// </summary>
	public class Inductor : Element
	{
		/// <summary>
		///     Constructor for <see cref="Inductor" />
		/// </summary>
		/// <param name="name"> name of the element</param>
		/// <param name="value"> value of the element</param>
		public Inductor(string name, double value) : base(name, value)
		{
			SegmentType = SegmentType.Inductor;
		}

		/// <summary>
		///     Calculate impedance one element of <see cref="Inductor" />
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns> <see cref="List{T}" /> impedance this <see cref="Inductor" /></returns>
		public override Complex CalculateZ(double frequency)
		{
			var result = 2 * Math.PI * frequency * Value;
			return new Complex(0, result);
		}

		public override object Clone()
		{
			return new Inductor(Name.Clone() as string, Value);
		}

		/// <summary>
		///     Converts an element to a string
		/// </summary>
		/// <returns>
		///     <see cref="Name" /> and <see cref="Value" /> string
		/// </returns>
		public override string ToString()
		{
			return $"{Name} = {Value} H";
		}
	}
}