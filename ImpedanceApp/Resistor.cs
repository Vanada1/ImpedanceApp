using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TZ1
{
	/// <summary>
	/// The <see cref="Resistor"/> class contains information 
	/// about the <see cref="Resistor"/>:
	/// <see cref="Name"/>, <see cref="Value"/>
	/// </summary>
	class Resistor : IElement
	{
		/// <summary>
		/// Value <see cref="Resistor"/> element
		/// </summary>
		private double _value;

		/// <summary>
		/// Property <see cref="Resistor"/> name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Property <see cref="Resistor"/> value
		/// </summary>
		public double Value 
		{ 
			get => _value;
			set
			{
				_value = value;
				ValueChanged.Invoke(this, 
					nameof(Resistor) + " value has been change");
			}
		}

		/// <summary>
		/// The event <see cref="ValueChanged"/> warns of a value change
		/// </summary>
		public event IElement.Changed ValueChanged;

		/// <summary>
		/// Calculate impedance one element of <see cref="Resistor"/>
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns>complex value this <see cref="Resistor"/></returns>
		public Complex CalculateZ(double frequency)
		{
			return new Complex(Value, 0);
		}

		public Resistor(string name, double value)
		{
			Name = name;
			Value = value;
		}
	}
}
