using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// Abstract class Circuit 
	/// </summary>
	abstract public class Circuit : ISegment
	{

		/// <summary>
		/// The event <see cref="SegmentChanged"/> warns of a circuit change
		/// </summary>
		public event EventHandler SegmentChanged;

		public string Name { get; set; }

		/// <summary>
		/// All elements list in the circuit
		/// </summary>
		public SegmentObservableCollection<ISegment> SubSegment { get; set; }

		/// <summary>
		/// Calculate full impedance in the circuit
		/// </summary>
		/// <param name="frequencies"></param>
		/// <returns>All complex for <see name="frequencies"/></returns>
		public abstract List<Complex> CalculateZ(List<double> frequencies);

		/// <summary>
		/// Circuit constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit"/></param>
		/// <param name="subSegment"> of <see cref="Circuit"/></param>
		public Circuit(string name, SegmentObservableCollection<ISegment> subSegment)
        {
			Name = name;
			SubSegment = subSegment;
			SubSegment.ElementObservableCollectionChanged += EventCircuitChanged;
		}

		/// <summary>
		/// Circuit changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void EventCircuitChanged(object sender, EventArgs e)
		{
			SegmentChanged?.Invoke(sender, e);
		}
	}
}
