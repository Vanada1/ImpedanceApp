using Impedance.Elements;
using Impedance.Interface;

namespace DrawItems.Elements
{
	/// <summary>
	/// View model for drawing <see cref="Resistor"/>.
	/// </summary>
	[SegmentTypeValidation(typeof(Resistor))]
	public class ResisctorVM : DrawableElementBase
	{
		public ResisctorVM(ISegment segment) : base(segment)
		{
		}
	}
}
