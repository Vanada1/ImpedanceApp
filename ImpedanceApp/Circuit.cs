using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TZ1
{
	/// <summary>
	/// The delegate <see cref=" Changed"/> warns of a value change
	/// </summary>
	/// <param name="obj"> the object, wich has been change</param>
	/// <param name="arg">the argument for output </param>
	delegate void Changed(object obg, object arg);
	class Circuit
	{
		/// <summary>
		/// All elements list in the circuit
		/// </summary>
		public List<IElement> Elements;

		/// <summary>
		/// Calculate full impedance in the circuit
		/// </summary>
		/// <param name="frequencies"></param>
		/// <returns>All complex for <see name="frequencies"/></returns>
		public Complex[] CalculateZ(double[] frequencies)
		{
			Complex[] results = new Complex[frequencies.Length];
			for (int i = 0; i < results.Length; i++)
			{
				foreach (IElement element in Elements)
				{
					results[i] += element.CalculateZ(frequencies[i]);
				}
			}
			return results;
		}

		/// <summary>
		/// The event <see cref="CircuitChanged"/> warns of a circuit change
		/// </summary>
		public event Changed CircuitChanged;
	}
}
