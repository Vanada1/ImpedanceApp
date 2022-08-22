using Impedance.Elements;
using Impedance.Interface;

namespace DrawItems.Elements
{
	/// <summary>
	/// View model for drawing <see cref="Capacitor"/>.
	/// </summary>
	[SegmentTypeValidation(typeof(Capacitor))]
	public class CapacitorVM : DrawableElementBase
	{
		public CapacitorVM(ISegment segment) : base(segment)
		{
		}
	}
}
