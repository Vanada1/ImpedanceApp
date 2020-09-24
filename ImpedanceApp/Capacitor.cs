using System;
using System.Numerics;
using System.Collections.Generic;

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
		/// <see cref="Capacitor"/> name property
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// <see cref="Capacitor"/> <see cref="SubSegment"/> property
		/// </summary>
		public SegmentObservableCollection<ISegment> SubSegment { get; }

		/// <summary>
		/// <see cref="Capacitor"/> value property
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
					SegmentChanged?.Invoke(this,
						new ElementEventArgs(nameof(Capacitor) + 
						" value has been change"));
				}
				_value = value;
			}
		}

		/// <summary>
		/// The <see cref="event"/> <see cref="SegmentChanged"/> warns of a value change
		/// </summary>
		public event EventHandler SegmentChanged;

		/// <summary>
		/// Calculate impedance one element of <see cref="Capacitor"/>
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns> <see cref="List{Complex}<"/> values this <see cref="Capacitor"/></returns>
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
			SubSegment = null;
		}

		/// <summary>
		/// override metod ToString()
		/// </summary>
		/// <returns><see cref="Name"/> and <see cref="Value"/> string
		/// </returns>
		public override string ToString()
		{
			return $"{this.Name} = {this.Value} F";
		}
	}
}
