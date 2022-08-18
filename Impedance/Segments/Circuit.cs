using System;
using System.Collections.Generic;
using System.Numerics;
using Impedance.Elements;
using Impedance.Interface;

namespace Impedance.Segments
{
	/// <summary>
	///     Abstract class Circuit
	/// </summary>
	public class Circuit : ISegment
	{
		/// <summary>
		///     Name of <see cref="Circuit" />
		/// </summary>
		private string _name;

		/// <summary>
		///     Default <see cref="Circuit" /> constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit" /></param>
		/// <param name="subSegment"> of <see cref="Circuit" /></param>
		public Circuit()
		{
			Name = "Main";
			SubSegments = new SegmentObservableCollection();
			SubSegments.SegmentObservableCollectionChanged += OnCircuitChanged;
			SubSegments.CollectionChanged += OnCircuitChanged;
		}

		/// <summary>
		///     <see cref="Circuit" /> constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit" /></param>
		/// <param name="subSegment"> of <see cref="Circuit" /></param>
		public Circuit(string name, SegmentObservableCollection segments)
		{
			Name = name;
			SubSegments = segments;
			SubSegments.SegmentObservableCollectionChanged += OnCircuitChanged;
			SubSegments.CollectionChanged += OnCircuitChanged;
		}

		/// <summary>
		///     Set and return <see cref="Name" /> of the <see cref="ParallelCircuit" />
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (value.Length == 0)
					throw new ArgumentException(nameof(Name) +
												" cannot have string length 0");

				_name = value;
			}
		}

		/// <summary>
		///     Set and return <see cref="SubSegments" /> of the <see cref="Circuit" />
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
		///     Calculate impedance in the <see cref="Circuit" />
		/// </summary>
		/// <param name="frequency">for calculate</param>
		/// <returns><see cref="Complex" /> impedance this <see cref="Circuit" /></returns>
		public Complex CalculateZ(double frequency)
		{
			var result = new Complex(0.0, 0.0);
			foreach (var segment in SubSegments)
			{
				result += segment.CalculateZ(frequency);
			}

			return result;
		}

		/// <summary>
		///     Object copy method
		/// </summary>
		/// <returns>Returns a new object with the same values</returns>
		public object Clone()
		{
			return new Circuit(Name.Clone() as string,
				SubSegments.Clone() as SegmentObservableCollection);
		}

		/// <summary>
		///     Comparing <see cref="ISegment" /> and <see cref="Circuit" /> Objects
		/// </summary>
		/// <param Name="other">This <see cref="ISegment" /> compares with the current</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public bool Equals(ISegment other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Name == other.Name && SubSegments.Equals(other.SubSegments);
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
		///     Calculate impedances in the <see cref="Circuit" />
		/// </summary>
		/// <param name="frequencies"> for calculate</param>
		/// <returns><see cref="List{Complex}" /> impedances this <see cref="Circuit" /></returns>
		public List<Complex> CalculateZ(List<double> frequencies)
		{
			var results = new List<Complex>();
			for (var i = 0; i < frequencies.Count; i++)
			{
				results.Add(CalculateZ(frequencies[i]));
			}

			return results;
		}

		/// <summary>
		/// Remove <see cref="ISegment"/> in the circuit
		/// </summary>
		/// <param name="removedElement"> <see cref="ISegment"/> for remove</param>
		/// <param name="segments">currently segment</param>
		public void RemoveSegment(ISegment removedElement, ISegment segments = null)
		{
			var foundRoot = segments ?? this;

			if (foundRoot.SubSegments.Remove(removedElement)) return;
			foreach (var segment in foundRoot.SubSegments)
				if (!(segment is Element))
				{
					RemoveSegment(removedElement, segment);
				}
		}

		/// <summary>
		/// Recursively find and replace segment
		/// </summary>
		/// <param name="insteadSegment">segment that change</param>
		/// <param name="replacingSegment"> segment to which will change</param>
		/// <param name="currentSegment">segment in which the search takes place.
		///     If <see cref="currentSegment" /> is null, then <see cref="this" /></param>
		/// <returns>changed item</returns>
		public ISegment ReplaceSegment(ISegment insteadSegment,
			ISegment replacingSegment, ISegment currentSegment = null)
		{
			ISegment result = null;
			if (ReferenceEquals(currentSegment, null))
			{
				if (ReferenceEquals(insteadSegment, this))
				{
					this.Name = replacingSegment.Name;
					return this;
				}
				currentSegment = this;
			}

			if (currentSegment is Element)
			{
				return result;
			}

			for (int i = 0; i < currentSegment.SubSegments.Count; i++)
			{
				if (ReferenceEquals(currentSegment.SubSegments[i], insteadSegment))
				{
					currentSegment.SubSegments[i] = replacingSegment;
					return currentSegment.SubSegments[i];
				}

				if (!(currentSegment.SubSegments[i] is Element))
				{
					result = ReplaceSegment(insteadSegment, replacingSegment,
						currentSegment.SubSegments[i]);
				}
			}

			return result;
		}

		/// <summary>
		///     Comparing Two <see cref="Circuit" /> Objects
		/// </summary>
		/// <param name="other">This <see cref="Circuit" /> compares with the current</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		protected bool Equals(Circuit other)
		{
			return Name == other.Name && SubSegments.Equals(other.SubSegments);
		}

		/// <summary>
		///     Comparing object and <see cref="Element" /> Objects
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
			return Equals((Circuit)obj);
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing two <see cref="Circuit" />
		/// </summary>
		/// <param name="circuit1">First <see cref="Circuit" /> for comparison</param>
		/// <param name="circuit2">Second <see cref="Circuit" /> for comparison</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public static bool operator ==(Circuit circuit1, Circuit circuit2)
		{
			if ((object)circuit1 == null || (object)circuit2 == null) return Equals(circuit1, circuit2);

			return circuit1.Equals(circuit2);
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing two <see cref="Circuit" />
		/// </summary>
		/// <param name="circuit1">First <see cref="Circuit" /> for comparison</param>
		/// <param name="circuit2">Second <see cref="Circuit" /> for comparison</param>
		/// <returns>
		///     Comparison result.True - not equal.
		///     False - equal
		/// </returns>
		public static bool operator !=(Circuit circuit1, Circuit circuit2)
		{
			if ((object)circuit1 == null || (object)circuit2 == null) return !Equals(circuit1, circuit2);

			return !circuit1.Equals(circuit2);
		}

		public override string ToString()
		{
			return Name;
		}
	}
}