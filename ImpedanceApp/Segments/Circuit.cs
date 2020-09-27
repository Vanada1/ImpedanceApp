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
		/// Set and return <see cref="Name"/> of the <see cref="ParallelCircuit"/>
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Set and return <see cref="SubSegments"/> of the <see cref="Circuit"/>
		/// </summary>
		public SegmentObservableCollection<ISegment> SubSegments { get; set; }

		/// <summary>
		/// Default <see cref="Circuit"/> constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit"/></param>
		/// <param name="subSegment"> of <see cref="Circuit"/></param>
		public Circuit()
		{
			Name = "Main";
			SubSegments = new SegmentObservableCollection<ISegment>();
			SubSegments.SegmentObservableCollectionChanged += OnCircuitChanged;
			SubSegments.CollectionChanged += OnCircuitChanged;
		}

		/// <summary>
		/// <see cref="Circuit"/> constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit"/></param>
		/// <param name="subSegment"> of <see cref="Circuit"/></param>
		public Circuit(string name, SegmentObservableCollection<ISegment> segments)
		{
			Name = name;
			SubSegments = segments;
			SubSegments.SegmentObservableCollectionChanged += OnCircuitChanged;
			SubSegments.CollectionChanged += OnCircuitChanged;
		}

		/// <summary>
		///  Event fires when segment changes
		/// </summary>
		public event EventHandler SegmentChanged;

		/// <summary>
		/// Glows when both the structure of the chain is changed,
		/// and when an individual element of the chain is changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCircuitChanged(object sender, EventArgs e)
		{
			SegmentChanged?.Invoke(sender, e);
		}

		/// <summary>
		/// Calculate impedances in the <see cref="Circuit"/>
		/// </summary>
		/// <param name="frequencies"> for calculate</param>
		/// <returns><see cref="List{Complex}"/> impedances this <see cref="Circuit"/></returns>
		public List<Complex> CalculateZ(List<double> frequencies)
        {
			List<Complex> results = new List<Complex>();
			for (int i = 0; i < frequencies.Count; i++)
			{
				Complex result = new Complex(0.0, 0.0);
				foreach(var element in SubSegments)
                {
					result += element.CalculateZ(frequencies[i]);
                }
				results.Add(result);
			}
			return results;
        }

		/// <summary>
		/// Calculate impedance in the <see cref="Circuit"/>
		/// </summary>
		/// <param name="frequency">for calculate</param>
		/// <returns><see cref="Complex"/> impedance this <see cref="Circuit"/></returns>
		Complex ISegment.CalculateZ(double frequency)
        {
            throw new NotImplementedException();
        }
    }
}
