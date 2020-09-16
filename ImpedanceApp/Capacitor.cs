using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ImpedanceApp
{
	/// <summary>
	/// The <see cref="Capacitor"/> class contains information 
	/// about the <see cref="Capacitor"/>:
	/// <see cref="Name"/>, <see cref="Value"/>
	/// </summary>
	public class Capacitor : IElement
	{
		/// <summary>
		/// Value <see cref="Capacitor"/> element
		/// </summary>
		private double _value;

		/// <summary>
		/// Property <see cref="Capacitor"/> name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Property <see cref="Capacitor"/> value
		/// </summary>
		public double Value 
		{ 
			get => _value; 
			set
			{
				_value = value;
				//ValueChanged.Invoke(this, 
				//	nameof(Capacitor) + " value has been change");
			}
		}

		/// <summary>
		/// The event <see cref="ValueChanged"/> warns of a value change
		/// </summary>
		public event IElement.Changed ValueChanged;

		/// <summary>
		/// Calculate impedance one element of <see cref="Capacitor"/>
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns>complex value this <see cref="Capacitor"/></returns>
		public Complex CalculateZ(double frequency)
		{
			double result = -1 / (2 * Math.PI * frequency * Value);
			return new Complex(0, result);
		}

		public Capacitor(string name, double value)
		{
			Name = name;
			Value = value;
		}

		public override string ToString()
		{
			return $"{this.Name} = {this.Value}";
		}
	}
}
