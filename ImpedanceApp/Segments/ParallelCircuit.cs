using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// <see cref="ParallelCircuit"/> is inheritor of an abstract class <see cref="Circuit"/>
	/// </summary>
	public class ParallelCircuit : ISegment
	{

		/// <summary>
		/// Name of <see cref="ParallelCircuit"/>
		/// </summary>
		private string _name;
		
		/// <summary>
		/// Set and return <see cref="Name"/> of the <see cref="ParallelCircuit"/>
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (value.Length == 0)
				{
					throw new ArgumentException(nameof(Name) +
					                            " cannot have string length 0");
				}

				_name = value;
			}
		}

		/// <summary>
		/// Set and return <see cref="SubSegments"/> of the <see cref="SerialCircuit"/>
		/// </summary>
		public SegmentObservableCollection SubSegments { get; set; }

		/// <summary>
		/// <see cref="SerialCircuit"/> constructor
		/// </summary>
		/// <param name="name"> name of the <see cref="Circuit"/></param>
		/// <param name="subSegments"> subSegments of the <see cref="Circuit"/></param>
		public ParallelCircuit(string name, SegmentObservableCollection subSegments)
		{
			Name = name;
			SubSegments = subSegments;
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
		protected void OnCircuitChanged(object sender, EventArgs e)
		{
			SegmentChanged?.Invoke(sender, e);
		}

		/// <summary>
		/// Calculate impedance in the <see cref="ParallelCircuit"/>
		/// </summary>
		/// <param name="frequency"> for calculate</param>
		/// <returns> <see cref="Complex"/> impedance this <see cref="ParallelCircuit"/></returns>
		public Complex CalculateZ(double frequency)
		{
			Complex result = new Complex(0.0, 0.0);

			foreach(var segment in SubSegments)
			{
				result += 1.0 / segment.CalculateZ(frequency);
			}

			return 1 / result;
		}
	}
}
