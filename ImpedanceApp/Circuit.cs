using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	public class Circuit
	{

		/// <summary>
		/// The event <see cref="CircuitChanged"/> warns of a circuit change
		/// </summary>
		public event EventHandler CircuitChanged;

		/// <summary>
		/// All elements list in the circuit
		/// </summary>
		public ElementObservableCollection<IElement> Elements { get; set; }

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

		/// <summary>
		/// Constructor default <see cref="Capacitor"/>
		/// </summary>
		public Circuit()
		{
			Elements = new ElementObservableCollection<IElement>();
			Elements.ElementObservableCollectionChanged += EventCircuitChanged;
		}

		/// <summary>
		/// Constructor <see cref="Capacitor"/>
		/// </summary>
		/// <param name="elements"> is collection <see cref="IElement"/>
		/// </param>
		public Circuit(ElementObservableCollection<IElement> elements)
		{
			Elements = elements;
			Elements.ElementObservableCollectionChanged += EventCircuitChanged;
		}

		/// <summary>
		/// Circuit changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EventCircuitChanged(object sender, EventArgs e)
		{
			CircuitChanged?.Invoke(sender, e);
		}
	}
}
