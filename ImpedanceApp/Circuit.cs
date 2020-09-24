using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
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

		public Circuit(string name, SegmentObservableCollection<ISegment> subSegment)
        {
			Name = name;
			SubSegment = subSegment;

        }

		/// <summary>
		/// Circuit changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EventCircuitChanged(object sender, EventArgs e)
		{
			SegmentChanged?.Invoke(sender, e);
		}
	}
}
