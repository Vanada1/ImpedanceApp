﻿using System;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// The <see cref="Inductor"/> class contains information 
	/// about the <see cref="Inductor"/>:
	/// <see cref="Name"/>, <see cref="Value"/>
	/// </summary>
	public class Inductor : IElement
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
		/// Calculate impedance one element of <see cref="Inductor"/>
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns>complex value this <see cref="Inductor"/></returns>
		public Complex CalculateZ(double frequency)
		{
			double result = 2 * Math.PI * frequency * Value;
			return new Complex(0, result);
		}

		/// <summary>
		/// Constructor for <see cref="Inductor"/>
		/// </summary>
		/// <param name="name"> name of the element</param>
		/// <param name="value"> value of the element</param>
		public Inductor(string name, double value)
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