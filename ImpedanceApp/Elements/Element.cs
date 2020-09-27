using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace ImpedanceApp
{
    public abstract class Element:IElement
    {
        /// <summary>
        /// Value <see cref="Capacitor"/> element
        /// </summary>
        private double _value;

        /// <summary>
        /// <see cref="Capacitor"/> name property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="Capacitor"/> <see cref="SubSegments"/> property
        /// </summary>
        public SegmentObservableCollection<ISegment> SubSegments { get; }

        /// <summary>
        /// <see cref="Capacitor"/> value property
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
        /// The <see cref="event"/> <see cref="SegmentChanged"/> warns of a value change
        /// </summary>
        public event EventHandler SegmentChanged;

        /// <summary>
        /// Calculate impedance one element of <see cref="Capacitor"/>
        /// </summary>
        /// <param name="frequency"> is frequency for element</param>
        /// <returns> <see cref="List{Complex}<"/> values this <see cref="Capacitor"/></returns>
        public abstract Complex CalculateZ(double frequency);

        /// <summary>
        /// Constructor <see cref="Capacitor"/>
        /// </summary>
        /// <param name="name"> name of the element</param>
        /// <param name="value"> value of the element</param>
        public Element(string name, double value)
        {
            Name = name;
            Value = value;
            SubSegments = null;
        }

        /// <summary>
        /// override metod ToString()
        /// </summary>
        /// <returns><see cref="Name"/> and <see cref="Value"/> string
        /// </returns>
        public override string ToString()
        {
            return $"{this.Name} = {this.Value} F";
        }
    }
}

