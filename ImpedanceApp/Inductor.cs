using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TZ1
{
	/// <summary>
	/// The <see cref="Inductor"/> class contains information 
	/// about the <see cref="Inductor"/>:
	/// <see cref="Name"/>, <see cref="Value"/>
	/// </summary>
	class Inductor : IElement
	{
		/// <summary>
		/// Value <see cref="Inductor"/> element
		/// </summary>
		private double _value;

		/// <summary>
		/// Property <see cref="Inductor"/> name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Property <see cref="Inductor"/> value
		/// </summary>
		public double Value {
			get => _value;
			set
			{ 
				_value = value;
				ValueChanged.Invoke(this,
					nameof(Inductor) + " value has been change");
			} 
		}

		/// <summary>
		/// The event <see cref="ValueChanged"/> warns of a value change
		/// </summary>
		public event IElement.Changed ValueChanged;

		/// <summary>
		/// Calculate impedance one element of <see cref="Inductor"/>
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns>complex value this <see cref="Inductor"/></returns>
		public Complex CalculateZ(double frequency)
		{
			double result = 2 * Math.PI * frequency * Value;
			return new Complex(0, result);
		}
	}
}
