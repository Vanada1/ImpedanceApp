using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
    public class SerialCircuit : Circuit
    {
        public override List<Complex> CalculateZ(List<double> frequencies)
        {
            List<Complex> results = new List<Complex>(frequencies.Count);

            for (int i = 0; i < frequencies.Count; i++)
            {
                results.Add(new Complex(0.0, 0.0));
            }   

            foreach (var segment in SubSegment)
            {
                List<Complex> resultsElement = segment.CalculateZ(frequencies);
                for (int i = 0; i < resultsElement.Count; i++)
                {
                    results[i] += resultsElement[i];
                }
            }

            return results;
        }

       public SerialCircuit(string name, SegmentObservableCollection<ISegment> subSegment)
            : base(name, subSegment)
        {

        }
    }
}
