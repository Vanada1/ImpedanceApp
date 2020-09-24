﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace ImpedanceApp
{
    /// <summary>
    /// Interface all segments
    /// </summary>
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
        Complex CalculateZ(double frequency);

        /// <summary>
        /// SubSegment property
        /// </summary>
        SegmentObservableCollection<ISegment> SubSegment { get; }

        /// <summary>
        /// Event for Segments
        /// </summary>
        event EventHandler SegmentChanged;

    }
}
