using System.Collections.ObjectModel;
using Impedance.Interface;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DrawItems.Segments
{
	/// <summary>
	/// Circuit view model for drawing.
	/// </summary>
	public class CircuitVM : ObservableObject, ISegmentDrawable
	{
		/// <inheritdoc/>
		public ObservableCollection<ISegmentDrawable> SubSegments { get; } =
			new ObservableCollection<ISegmentDrawable>();

		/// <inheritdoc/>
		public string Name { get; set; }

		/// <inheritdoc/>
		public ISegment Segment { get; }

		public CircuitVM(ISegment segment)
		{
			Segment = segment;
		}
	}
}
