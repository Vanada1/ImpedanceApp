using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// <see cref="ParallelCircuit"/> is inheritor of an abstract class <see cref="ParallelCircuit"/>
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
		/// <param name="name"> name of the <see cref="ParallelCircuit"/></param>
		/// <param name="subSegments"> subSegments of the <see cref="ParallelCircuit"/></param>
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

			return 1.0 / result;
		}

		/// <summary>
		/// Object copy method
		/// </summary>
		/// <returns>Returns a new object with the same values</returns>
		public object Clone()
		{
			return new ParallelCircuit(Name, SubSegments.Clone() as SegmentObservableCollection);
		}

		/// <summary>
		/// Comparing Two <see cref="ParallelCircuit"/> Objects
		/// </summary>
		/// <param name="other">This <see cref="ParallelCircuit"/> compares with the current</param>
		/// <returns>Comparison result.True - equal. 
		///False - not equal</returns>
		protected bool Equals(ParallelCircuit other)
		{
			return Name == other.Name && Equals(SubSegments, other.SubSegments);
		}

		/// <summary>
		/// Comparing object and <see cref="ParallelCircuit"/> Objects
		/// </summary>
		/// <param name="obj">This object compares with the current</param>
		/// <returns>Comparison result.True - equal. 
		///False - not equal</returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ParallelCircuit)obj);
		}

		/// <summary>
		/// Comparing <see cref="ISegment"/> and <see cref="ParallelCircuit"/> Objects
		/// </summary>
		/// <param name="other">This <see cref="ISegment"/> compares with the current</param>
		/// <returns>Comparison result.True - equal. 
		///False - not equal</returns>
		public bool Equals(ISegment other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Name == other.Name && Equals(SubSegments, other.SubSegments);
		}

		/// <summary>
		/// Getting the hash of an object
		/// </summary>
		/// <returns>object hash</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ (SubSegments != null ? SubSegments.GetHashCode() : 0);
			}
		}

		/// <summary>
		/// Overriding the == comparison operator. Comparing two <see cref="ParallelCircuit"/>
		/// </summary>
		/// <param name="circuit1">First <see cref="ParallelCircuit"/> for comparison</param>
		/// <param name="circuit2">Second <see cref="ParallelCircuit"/> for comparison</param>
		/// <returns>Comparison result.True - equal. 
		///False - not equal</returns>
		public static bool operator ==(ParallelCircuit circuit1, ParallelCircuit circuit2)
		{
			if (((object)circuit1 == null) || ((object)circuit2 == null))
			{
				return Object.Equals(circuit1, circuit2);
			}

			return circuit1.Equals(circuit2);
		}

		/// <summary>
		/// Overriding the == comparison operator. Comparing two <see cref="ParallelCircuit"/>
		/// </summary>
		/// <param name="circuit1">First <see cref="ParallelCircuit"/> for comparison</param>
		/// <param name="circuit2">Second <see cref="ParallelCircuit"/> for comparison</param>
		/// <returns>Comparison result.True - not equal. 
		///False - equal</returns>
		public static bool operator !=(ParallelCircuit circuit1, ParallelCircuit circuit2)
		{

			if (((object)circuit1 == null) || ((object)circuit2 == null))
			{
				return Object.Equals(circuit1, circuit2);
			}

			return !(circuit1.Equals(circuit2));
		}
	}
}
