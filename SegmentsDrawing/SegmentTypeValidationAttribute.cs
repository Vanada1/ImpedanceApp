using System;
using Impedance;
using Impedance.Interface;

namespace SegmentsDrawing
{
    /// <summary>
	/// Attribute for converting <see cref="ISegment"/> in <see cref="DrawableSegmentBase"/>
	/// </summary>
	public class SegmentTypeValidationAttribute : Attribute
	{
		/// <summary>
		/// Segment type
		/// </summary>
		public Type SegmentType;

		/// <summary>
		/// Constructor for <see cref="SegmentTypeValidationAttribute"/>
		/// </summary>
		/// <param name="segmentType"><see cref="SegmentType"/></param>
		public SegmentTypeValidationAttribute(Type segmentType)
		{
			SegmentType = segmentType;
		}
	}
}