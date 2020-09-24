using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace ImpedanceApp
{
    public interface ISegment
    {

        /// <summary>
        /// Element name property
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        List<Complex> CalculateZ(List<double> frequency);

        SegmentObservableCollection<ISegment> SubSegment { get; }

        /// <summary>
        /// Event for Segments
        /// </summary>
        event EventHandler SegmentChanged;

    }
}
