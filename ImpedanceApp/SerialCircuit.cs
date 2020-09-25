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
        public string Name { get; set; }

        public SegmentObservableCollection<ISegment> SubSegment { get; set; }

        public event EventHandler SegmentChanged;

        /// <summary>
        /// Calculate impedance in the serial circuit
        /// </summary>
        /// <param name="frequency"> for calculate</param>
        /// <returns><see cref="List<Complex>"/> values for result</returns>
        public  Complex CalculateZ(double frequency)
        {
            Complex results = new Complex(0.0, 0.0);  

            foreach (var segment in SubSegment)
            {
                results += segment.CalculateZ(frequency);
            }

            return results;
        }

        /// <summary>
        /// <see cref="SerialCircuit"/> constructor
        /// </summary>
        /// <param name="name"> of the <see cref="Circuit"/></param>
        /// <param name="subSegment"> of the <see cref="Circuit"/></param>
        public SerialCircuit(string name, SegmentObservableCollection<ISegment> subSegment)
        {
            Name = name;
            SubSegment = subSegment;
            SubSegment.SegmentObservableCollectionChanged += EventCircuitChanged;
            SubSegment.CollectionChanged += EventCircuitChanged;
        }

        private void EventCircuitChanged(object sender, EventArgs e)
        {
            SegmentChanged?.Invoke(sender, e);
        }
    }
}
