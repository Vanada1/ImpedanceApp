using System;
using System.Numerics;

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
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException(
						"Less than zero");
				}
				if (_value != value)
				{
					ValueChanged?.Invoke(this,
						new ElementEventArgs(nameof(Capacitor) + 
						" value has been change"));
				}
				_value = value;
			}
		}

		/// <summary>
		/// The event <see cref="ValueChanged"/> warns of a value change
		/// </summary>
		public event EventHandler ValueChanged;

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

		/// <summary>
		/// Constructor <see cref="Capacitor"/>
		/// </summary>
		/// <param name="name"> name of the element</param>
		/// <param name="value"> value of the element</param>
		public Capacitor(string name, double value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// override metod ToString()
		/// </summary>
		/// <returns><see cref="Name"/> and <see cref="Value"/> string
		/// </returns>
		public override string ToString()
		{
			return $"{this.Name} = {this.Value}";
		}
	}
}
