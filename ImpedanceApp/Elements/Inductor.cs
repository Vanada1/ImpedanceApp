using System;
using System.Numerics;
using System.Collections.Generic;

namespace ImpedanceApp
{
	/// <summary>
	/// The <see cref="Inductor"/> class contains information 
	/// about the <see cref="Inductor"/>:
	/// <see cref="Name"/>, <see cref="Value"/>
	/// </summary>
	public class Inductor : Element
	{
		/// <summary>
		/// Calculate impedance one element of <see cref="Inductor"/>
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns> <see cref="List{Complex}<"/> values this <see cref="Inductor"/></returns>
		public override Complex CalculateZ(double frequency)
		{
			double result = 2 * Math.PI * frequency * Value;
			return new Complex(0, result);
		}

		/// <summary>
		/// Constructor for <see cref="Inductor"/>
		/// </summary>
		/// <param name="name"> name of the element</param>
		/// <param name="value"> value of the element</param>
		public Inductor(string name, double value) : base(name, value)
		{
		}

        /// <summary>
		/// override metod ToString()
		/// </summary>
		/// <returns><see cref="Name"/> and <see cref="Value"/> string
		/// </returns>
		public override string ToString()
		{
			return $"{this.Name} = {this.Value} H";
		}
	}
}
