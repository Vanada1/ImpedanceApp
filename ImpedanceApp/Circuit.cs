using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ImpedanceApp
{
	public class Circuit
	{

		/// <summary>
		/// The delegate <see cref=" Changed"/> warns of a value change
		/// </summary>
		/// <param name="obj"> the object, wich has been change</param>
		/// <param name="arg">the argument for output </param>
		public delegate void Changed(object obg, object arg);

		List<IElement> _elements;
		/// <summary>
		/// All elements list in the circuit
		/// </summary>
		public List<IElement> Elements
		{
			get => _elements;
			set
			{
				_elements = value;
				//CircuitChanged.Invoke(this,
				//	nameof(Elements) + " values has been changet");
			}
		}

		/// <summary>
		/// Calculate full impedance in the circuit
		/// </summary>
		/// <param name="frequencies"></param>
		/// <returns>All complex for <see name="frequencies"/></returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			List<Complex> results = new List<Complex>();
			for (int i = 0; i < frequencies.Count; i++)
			{
				Complex resultTemp = new Complex(0, 0);
				foreach (IElement element in Elements)
				{
					resultTemp += element.CalculateZ(frequencies[i]);
				}
				results.Add(resultTemp);
			}
			return results;
		}

		public Circuit()
		{
			Elements = new List<IElement>();
		}

		public Circuit(List<IElement> elements)
		{
			Elements = elements;
		}

		/// <summary>
		/// The event <see cref="CircuitChanged"/> warns of a circuit change
		/// </summary>
		public event Changed CircuitChanged;
	}
}
