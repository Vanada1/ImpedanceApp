using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
    /// <summary>
    /// <see cref="ParallelCircuit"/> is inheritor of an abstract class <see cref="Circuit"/>
    /// </summary>
    public class ParallelCircuit : Circuit
    {
        /// <summary>
        /// Calculate impedance in the serial circuit
        /// </summary>
        /// <param name="frequencies"> for calculate</param>
        /// <returns><see cref="List<Complex>"/> values for result</returns>
        public override List<Complex> CalculateZ(List<double> frequencies)
        {
            List<Complex> results = new List<Complex>();

            for (int i = 0; i < frequencies.Count; i++)
            {
                results.Add(new Complex(0.0, 0.0));
            }

            foreach(var segment in SubSegment)
            {
                List<Complex> resultsElement = segment.CalculateZ(frequencies);
                for (int i = 0; i < resultsElement.Count; i++)
                {
                    results[i] += 1.0 / resultsElement[i];
                }
            }

            for (int i = 0; i < results.Count; i++)
            {
                results[i] = Complex.Pow(results[i], -1);
            }

            return results;
        }


        /// <summary>
        /// <see cref="SerialCircuit"/> constructor
        /// </summary>
        /// <param name="name"> of the <see cref="Circuit"/></param>
        /// <param name="subSegment"> of the <see cref="Circuit"/></param>
        public ParallelCircuit(string name, SegmentObservableCollection<ISegment> subSegment)
            : base(name, subSegment)
        {

        }
    }
}
