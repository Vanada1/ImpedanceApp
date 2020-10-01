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
		/// Name of <see cref="Circuit"/>
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
		/// Set and return <see cref="SubSegments"/> of the <see cref="Circuit"/>
		/// </summary>
		public SegmentObservableCollection SubSegments { get; set; }

		/// <summary>
		/// Default <see cref="Circuit"/> constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit"/></param>
		/// <param name="subSegment"> of <see cref="Circuit"/></param>
		public Circuit()
		{
			Name = "Main";
			SubSegments = new SegmentObservableCollection();
			SubSegments.SegmentObservableCollectionChanged += OnCircuitChanged;
			SubSegments.CollectionChanged += OnCircuitChanged;
		}

		/// <summary>
		/// <see cref="Circuit"/> constructor
		/// </summary>
		/// <param name="name"> of <see cref="Circuit"/></param>
		/// <param name="subSegment"> of <see cref="Circuit"/></param>
		public Circuit(string name, SegmentObservableCollection segments)
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

		public void RemoveElement(ISegment removedElement, ISegment segments = null)
		{
			var foundRoot = segments ?? this;

			if (foundRoot.SubSegments.Remove(removedElement)) return;
			foreach (var segment in foundRoot.SubSegments)
			{
				if (!(segment is IElement))
				{
					RemoveElement(removedElement, segment);
				}
			}
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

		/// <summary>
		/// Object copy method
		/// </summary>
		/// <returns>Returns a new object with the same values</returns>
		public object Clone()
		{
			return new Circuit(Name, SubSegments.Clone() as SegmentObservableCollection);
		}

		/// <summary>
		/// Comparing Two <see cref="Circuit"/> Objects
		/// </summary>
		/// <param name="other">This <see cref="Circuit"/> compares with the current</param>
		/// <returns>Comparison result.True - equal. 
		///False - not equal</returns>
		protected bool Equals(Circuit other)
		{
			return Name == other.Name && Equals(SubSegments, other.SubSegments);
		}

		/// <summary>
		/// Comparing object and <see cref="Element"/> Objects
		/// </summary>
		/// <param name="obj">This object compares with the current</param>
		/// <returns>Comparison result.True - equal. 
		///False - not equal</returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Circuit) obj);
		}

		/// <summary>
		/// Comparing <see cref="ISegment"/> and <see cref="Circuit"/> Objects
		/// </summary>
		/// <param Name="other">This <see cref="ISegment"/> compares with the current</param>
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
				return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (SubSegments != null ? SubSegments.GetHashCode() : 0);
			}
		}

		/// <summary>
		/// Overriding the == comparison operator. Comparing two <see cref="Circuit"/>
		/// </summary>
		/// <param name="circuit1">First <see cref="Circuit"/> for comparison</param>
		/// <param name="circuit2">Second <see cref="Circuit"/> for comparison</param>
		/// <returns>Comparison result.True - equal. 
		///False - not equal</returns>
		public static bool operator ==(Circuit circuit1, Circuit circuit2)
		{
			if (((object)circuit1 == null) || ((object)circuit2 == null))
			{
				return Object.Equals(circuit1, circuit2);
			}

			return circuit1.Equals(circuit2);
		}

		/// <summary>
		/// Overriding the == comparison operator. Comparing two <see cref="Circuit"/>
		/// </summary>
		/// <param name="circuit1">First <see cref="Circuit"/> for comparison</param>
		/// <param name="circuit2">Second <see cref="Circuit"/> for comparison</param>
		/// <returns>Comparison result.True - not equal. 
		///False - equal</returns>
		public static bool operator !=(Circuit circuit1, Circuit circuit2)
		{

			if (((object)circuit1 == null) || ((object)circuit2 == null))
			{
				return Object.Equals(circuit1, circuit2);
			}

			return !(circuit1.Equals(circuit2));
		}
	}
}
