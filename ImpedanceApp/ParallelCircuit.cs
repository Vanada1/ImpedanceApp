using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
    public class ParallelCircuit : Circuit
    {
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

        public ParallelCircuit(string name, SegmentObservableCollection<ISegment> subSegment)
            : base(name, subSegment)
        {

        }
    }
}
