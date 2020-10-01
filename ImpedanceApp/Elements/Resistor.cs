using System;
using System.Numerics;
using System.Collections.Generic;

namespace ImpedanceApp
{
	/// <summary>
	/// The <see cref="Resistor"/> class contains information 
	/// about the <see cref="Resistor"/>:
	/// <see cref="Name"/>, <see cref="Value"/>
	/// </summary>
	public class Resistor : Element
	{
		/// <summary>
		/// Constructor <see cref="Resistor"/>
		/// </summary>
		/// <param name="name">name of the element</param>
		/// <param name="value">value of the element</param>
		public Resistor(string name, double value) : base(name, value)
		{
			Segment = ImpedanceApp.Segment.Resistor;
		}

		/// <summary>
		/// Calculate impedance one element of <see cref="Resistor"/>
		/// </summary>
		/// <param name="frequencies"> is frequency for element</param>
		/// <returns> <see cref="Complex"/> impedance this <see cref="Resistor"/></returns>
		public override Complex CalculateZ(double frequencies)
		{
			return new Complex(Value, 0);
		}

		public override object Clone()
		{
			return new Resistor(Name.Clone() as string, Value);
		}

		/// <summary>
        /// Converts an element to a string
        /// </summary>
        /// <returns><see cref="Name"/> and <see cref="Value"/> string
        /// </returns>
		public override string ToString()
		{
			return $"{this.Name} = {this.Value} Om";
		}
	}
}
