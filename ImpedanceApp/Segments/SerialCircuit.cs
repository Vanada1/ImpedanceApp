using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// <see cref="SerialCircuit"/> is inheritor of an abstract class <see cref="Circuit"/>
	/// </summary>
	public class SerialCircuit : ISegment
	{
		/// <summary>
		/// Set and return <see cref="Name"/> of the <see cref="SerialCircuit"/>
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Set and return <see cref="SubSegments"/> of the <see cref="SerialCircuit"/>
		/// </summary>
		public SegmentObservableCollection<ISegment> SubSegments { get; set; }

		/// <summary>
		/// <see cref="SerialCircuit"/> constructor
		/// </summary>
		/// <param name="name"> name of the <see cref="Circuit"/></param>
		/// <param name="subSegments"> sub-segments of the <see cref="Circuit"/></param>
		public SerialCircuit(string name, SegmentObservableCollection<ISegment> subSegments)
		{
			Name = name;
			SubSegments = subSegments;
			SubSegments.SegmentObservableCollectionChanged += OnCircuitChanged;
			SubSegments.CollectionChanged += OnCircuitChanged;
		}

		/// <summary>
		/// Event fires when segment changes
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
		/// Calculate impedance in the <see cref="SerialCircuit"/>
		/// </summary>
		/// <param name="frequency"> for calculate</param>
		/// <returns> <see cref="Complex"/> impedance this <see cref="SerialCircuit"/></returns>
		public Complex CalculateZ(double frequency)
		{
			Complex results = new Complex(0.0, 0.0);  

			foreach (var segment in SubSegments)
			{
				results += segment.CalculateZ(frequency);
			}

			return results;
		}
	}
}
