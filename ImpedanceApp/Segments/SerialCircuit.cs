using System;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	///     <see cref="SerialCircuit" /> is inheritor of an abstract class <see cref="SerialCircuit" />
	/// </summary>
	public class SerialCircuit : ISegment
	{
		/// <summary>
		/// ID Serial segment
		/// </summary>
		private static uint _id = 0;

		/// <summary>
		///     <see cref="SerialCircuit" /> constructor
		/// </summary>
		/// <param name="subSegments"> sub-segments of the <see cref="SerialCircuit" /></param>
		public SerialCircuit(SegmentObservableCollection subSegments)
		{
			Name = SetIDSegment();
			SubSegments = subSegments;
			SubSegments.SegmentObservableCollectionChanged += OnCircuitChanged;
			SubSegments.CollectionChanged += OnCircuitChanged;
		}

		/// <summary>
		///     Return <see cref="Name" /> of the <see cref="SerialCircuit" />
		/// </summary>
		public string Name { get; }

		/// <summary>
		///     Set and return <see cref="SubSegments" /> of the <see cref="SerialCircuit" />
		/// </summary>
		public SegmentObservableCollection SubSegments { get; set; }

		/// <summary>
		///     Return segment the object is
		/// </summary>
		public SegmentType SegmentType { get; } = SegmentType.SerialCircuit;

		/// <summary>
		///     Event fires when segment changes
		/// </summary>
		public event EventHandler SegmentChanged;

		/// <summary>
		/// Sets the id for the segment
		/// </summary>
		/// <returns>The segment name string</returns>
		private static string SetIDSegment()
		{
			string id = "Serial" + _id.ToString();
			_id++;
			return id;
		}

		/// <summary>
		///     Calculate impedance in the <see cref="SerialCircuit" />
		/// </summary>
		/// <param name="frequency"> for calculate</param>
		/// <returns> <see cref="Complex" /> impedance this <see cref="SerialCircuit" /></returns>
		public Complex CalculateZ(double frequency)
		{
			var results = new Complex(0.0, 0.0);

			foreach (var segment in SubSegments)
			{
				results += segment.CalculateZ(frequency);
			}

			return results;
		}

		/// <summary>
		///     Object copy method
		/// </summary>
		/// <returns>Returns a new object with the same values</returns>
		public object Clone()
		{
			return new SerialCircuit(SubSegments.Clone() as SegmentObservableCollection);
		}

		/// <summary>
		///     Comparing <see cref="ISegment" /> and <see cref="SerialCircuit" /> Objects
		/// </summary>
		/// <param name="other">This <see cref="ISegment" /> compares with the current</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public bool Equals(ISegment other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return  Equals(SubSegments, other.SubSegments);
		}

		/// <summary>
		///     Glows when both the structure of the chain is changed,
		///     and when an individual element of the chain is changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCircuitChanged(object sender, EventArgs e)
		{
			SegmentChanged?.Invoke(sender, e);
		}

		/// <summary>
		///     Comparing Two <see cref="SerialCircuit" /> Objects
		/// </summary>
		/// <param name="other">This <see cref="SerialCircuit" /> compares with the current</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		protected bool Equals(SerialCircuit other)
		{
			return SubSegments.Equals(other.SubSegments);
		}

		/// <summary>
		///     Comparing object and <see cref="SerialCircuit" /> Objects
		/// </summary>
		/// <param name="obj">This object compares with the current</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;
			return Equals((SerialCircuit) obj);
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing two <see cref="SerialCircuit" />
		/// </summary>
		/// <param name="circuit1">First <see cref="ParallelCircuit" /> for comparison</param>
		/// <param name="circuit2">Second <see cref="ParallelCircuit" /> for comparison</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public static bool operator ==(SerialCircuit circuit1, SerialCircuit circuit2)
		{
			if ((object) circuit1 == null || (object) circuit2 == null) return Equals(circuit1, circuit2);

			return circuit1.Equals(circuit2);
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing two <see cref="SerialCircuit" />
		/// </summary>
		/// <param name="circuit1">First <see cref="SerialCircuit" /> for comparison</param>
		/// <param name="circuit2">Second <see cref="SerialCircuit" /> for comparison</param>
		/// <returns>
		///     Comparison result.True - not equal.
		///     False - equal
		/// </returns>
		public static bool operator !=(SerialCircuit circuit1, SerialCircuit circuit2)
		{
			if ((object) circuit1 == null || (object) circuit2 == null) return !Equals(circuit1, circuit2);

			return !circuit1.Equals(circuit2);
		}
	}
}