using System;
using Impedance.Interface;

namespace DrawItems
{
    /// <summary>
	/// Attribute for converting <see cref="ISegment"/> in <see cref="ISegmentDrawable"/>
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