using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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



		/// <summary>
		/// The event <see cref="CircuitChanged"/> warns of a circuit change
		/// </summary>
		public event Changed CircuitChanged;

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

		public Circuit()
		{
			Elements = new ElementObservableCollection<IElement>();
			Elements.ElementObservableCollectionChanged += EventCircuitChanged;
		}

		public Circuit(ElementObservableCollection<IElement> elements)
		{
			Elements = elements;
			Elements.ElementObservableCollectionChanged += EventCircuitChanged;
		}

		private void EventCircuitChanged(object sender, object e)
		{
			CircuitChanged?.Invoke(sender, e);
		}
	}
}
