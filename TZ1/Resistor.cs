using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TZ1
{
	class Resistor : IElement
	{
		private double _value;
		public string Name { get; set; }
		public double Value 
		{ 
			get => _value;
			set
			{
				_value = value;
				Changed.Invoke(this, 
					nameof(Resistor) + " value has been change");
			}
		}

		public event IElement.ValueChanged Changed;

		// maybe to chenge location of metod? 
		public void OutputMessage(object obj, object arg)
		{
			IElement element = obj as IElement;
			if (element != null)
			{
				// print message
			}
		}

		public Complex CalculateZ(double frequency)
		{
			return new Complex(Value, 0);
		}
	}
}
