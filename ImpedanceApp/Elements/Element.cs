using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
    /// <summary>
    /// The base class for all elements
    /// </summary>
    public abstract class Element:IElement
    {
        /// <summary>
        /// Value <see cref="Element"/>
        /// </summary>
        private double _value;

        /// <summary>
        /// Name <see cref="Element"/>
        /// </summary>
        private string _name;

        /// <summary>
        /// Set and return <see cref="Name"/> of <see cref="Element"/>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return <see cref="SubSegments"/> of <see cref="Element"/>
        /// </summary>
        public SegmentObservableCollection SubSegments { get; }

        /// <summary>
        /// Set and return <see cref="Value"/> of <see cref="Element"/>
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Less than zero");
                }
                if (_value != value)
                {
                    _value = value;
                    SegmentChanged?.Invoke(this,
                        new ElementEventArgs(nameof(Capacitor) +
                                             " value has been change"));
                }
            }
        }

        /// <summary>
        /// Constructor <see cref="Capacitor"/>
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
        /// The event <see cref="SegmentChanged"/> warns of a value change
        /// </summary>
        public event EventHandler SegmentChanged;

        /// <summary>
        /// Calculate impedance one element
        /// </summary>
        /// <param name="frequency"> is frequency for element</param>
        /// <returns> <see cref="List{Complex}"/> impedance this <see cref="Element"/></returns>
        public abstract Complex CalculateZ(double frequency);
    }
}

