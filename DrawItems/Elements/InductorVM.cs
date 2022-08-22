using Impedance.Elements;
using Impedance.Interface;

namespace DrawItems.Elements
{
	/// <summary>
	/// View model for drawing <see cref="Inductor"/>.
	/// </summary>
	[SegmentTypeValidation(typeof(Inductor))]
	public class InductorVM : DrawableElementBase
	{
		public InductorVM(ISegment segment) : base(segment)
		{
		}
	}
}
