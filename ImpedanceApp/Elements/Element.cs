using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	///     The base class for all elements
	/// </summary>
	public abstract class Element : ISegment, IEquatable<Element>
	{
		/// <summary>
		///     Name of <see cref="ImpedanceApp.Element" />
		/// </summary>
		private string _name;

		/// <summary>
		///     Value of <see cref="ImpedanceApp.Element" />
		/// </summary>
		private double _value;

		/// <summary>
		///     <see cref="ImpedanceApp.Element" /> constructor
		/// </summary>
		/// <param name="name"> name of the element</param>
		/// <param name="value"> value of the element</param>
		protected Element(string name, double value)
		{
			Name = name;
			Value = value;
			SubSegments = null;
		}

		/// <summary>
		///     Set and return <see cref="Name" /> of <see cref="ImpedanceApp.Element" />
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
		///     Set and return <see cref="Value" /> of <see cref="ImpedanceApp.Element" />
		/// </summary>
		public double Value
		{
			get => _value;
			set
			{
				if (value < 0)
					throw new ArgumentException(nameof(Value) +
					                            "cannot have negative value");
				if (_value != value)
				{
					var oldValue = _value;
					_value = value;
					SegmentChanged?.Invoke(this,
						new ElementEventArgs(Name +
						                     " value has been changed from" +
						                     $" {oldValue} to {value}"));
				}
			}
		}

		/// <summary>
		///     Return segment the object is
		/// </summary>
		public SegmentType SegmentType { get; protected set; }

		/// <summary>
		///     Return <see cref="SubSegments" /> of <see cref="ImpedanceApp.Element" />
		/// </summary>
		public SegmentObservableCollection SubSegments { get; }

		/// <summary>
		///     The event <see cref="SegmentChanged" /> warns of a value change
		/// </summary>
		public event EventHandler SegmentChanged;

		/// <summary>
		///     Calculate impedance one element
		/// </summary>
		/// <param name="frequency"> is frequency for element</param>
		/// <returns> <see cref="List{T}" /> impedance this <see cref="ImpedanceApp.Element" /></returns>
		public abstract Complex CalculateZ(double frequency);

		/// <summary>
		///     Object copy method
		/// </summary>
		/// <returns>Returns a new object with the same values</returns>
		public abstract object Clone();

		/// <summary>
		///     Comparing <see cref="ISegment" /> and <see cref="ImpedanceApp.Element" /> Objects
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
			return Name == other.Name && Equals(SubSegments, other.SubSegments);
		}

		/// <summary>
		///     Comparing Two <see cref="ImpedanceApp.Element" /> Objects
		/// </summary>
		/// <param name="other">This <see cref="ImpedanceApp.Element" /> compares with the current</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public bool Equals(Element other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return _value.Equals(other._value) && _name == other._name &&
			       Equals(SubSegments, other.SubSegments);
		}

		/// <summary>
		///     Comparing object and <see cref="ImpedanceApp.Element" /> Objects
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
			return Equals((Element) obj);
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing two <see cref="ImpedanceApp.Element" />
		/// </summary>
		/// <param name="element1">First <see cref="ImpedanceApp.Element" /> for comparison</param>
		/// <param name="element2">Second <see cref="ImpedanceApp.Element" /> for comparison</param>
		/// <returns>
		///     Comparison result.True - equal.
		///     False - not equal
		/// </returns>
		public static bool operator ==(Element element1, Element element2)
		{
			if ((object) element1 == null || (object) element2 == null) return Equals(element1, element2);

			return element1.Equals(element2);
		}

		/// <summary>
		///     Overriding the == comparison operator. Comparing two <see cref="ImpedanceApp.Element" />
		/// </summary>
		/// <param name="element1">First <see cref="ImpedanceApp.Element" /> for comparison</param>
		/// <param name="element2">Second <see cref="ImpedanceApp.Element" /> for comparison</param>
		/// <returns>
		///     Comparison result.True - not equal.
		///     False - equal
		/// </returns>
		public static bool operator !=(Element element1, Element element2)
		{
			if ((object) element1 == null || (object) element2 == null) return !Equals(element1, element2);

			return !element1.Equals(element2);
		}
	}
}