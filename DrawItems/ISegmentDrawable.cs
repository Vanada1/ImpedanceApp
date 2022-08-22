using System.Collections.ObjectModel;
using Impedance.Interface;

namespace DrawItems
{
	/// <summary>
	/// Interface for collecting segment VMs.
	/// </summary>
	public interface ISegmentDrawable
	{
		/// <summary>
		/// Return collection sub segments.
		/// </summary>
		ObservableCollection<ISegmentDrawable> SubSegments { get; }

		/// <summary>
		/// Set and return element name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Return segment data.
		/// </summary>
		ISegment Segment { get; }
	}
}
