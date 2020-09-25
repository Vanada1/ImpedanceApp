using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// Abstract class Circuit 
	/// </summary>
	public class Circuit : ISegment
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
        public List<Complex> CalculateZ(List<double> frequencies)
        {
			List<Complex> results = new List<Complex>();
			for (int i = 0; i < frequencies.Count; i++)
			{
				Complex result = new Complex(0.0, 0.0);
				foreach(var element in SubSegment)
                {
					result += element.CalculateZ(frequencies[i]);
                }
				results.Add(result);
			}
			return results;
        }

		/// <summary>
		/// Circuit constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit"/></param>
		/// <param name="subSegment"> of <see cref="Circuit"/></param>
		public Circuit()
        {
			Name = "Main";
			SubSegment = new SegmentObservableCollection<ISegment>();
			SubSegment.SegmentObservableCollectionChanged += EventCircuitChanged;
			SubSegment.CollectionChanged += EventCircuitChanged;
		}

		public Circuit(string name, SegmentObservableCollection<ISegment> segments)
        {
			Name = name;
			SubSegment = segments;
			SubSegment.SegmentObservableCollectionChanged += EventCircuitChanged;
			SubSegment.CollectionChanged += EventCircuitChanged;
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

        Complex ISegment.CalculateZ(double frequency)
        {
            throw new NotImplementedException();
        }
    }
}
