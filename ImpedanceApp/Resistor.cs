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
	public class Resistor : IElement
	{
		/// <summary>
		/// Value <see cref="Resistor"/> element
		/// </summary>
		private double _value;

		/// <summary>
		/// Property <see cref="Resistor"/> <see cref="Name"/>
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Property <see cref="Resistor"/> <see cref="SubSegment"/>
		/// </summary>
		public SegmentObservableCollection<ISegment> SubSegment { get; }

		/// <summary>
		/// Property <see cref="Resistor"/> <see cref="Value"/>
		/// </summary>
		public double Value 
		{ 
			get => _value;
			set
			{
				if(value<0)
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
		/// The event <see cref="SegmentChanged"/> warns of a value change
		/// </summary>
		public event EventHandler SegmentChanged;

		/// <summary>
		/// Calculate impedance one element of <see cref="Resistor"/>
		/// </summary>
		/// <param name="frequencies"> is frequency for element</param>
		/// <returns> <see cref="List{Complex}<"/> values this <see cref="Resistor"/></returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			List<Complex> results = new List<Complex>();
			for(int i=0;i<frequencies.Count;i++)
            {
				results.Add(new Complex(Value, 0));
            }
			return results;
		}

		/// <summary>
		/// Constructor <see cref="Resistor"/>
		/// </summary>
		/// <param name="name">name of the element</param>
		/// <param name="value">value of the element</param>
		public Resistor(string name, double value)
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
			return $"{this.Name} = {this.Value} Om";
		}
	}
}
