using System.Collections.ObjectModel;
using Impedance.Interface;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DrawItems.Segments
{
	public class ParallelCircuitVM : ObservableObject, ISegmentDrawable
	{
		public ParallelCircuitVM(ISegment segment)
		{
			Segment = segment;
		}

		public ObservableCollection<ISegmentDrawable> SubSegments { get; } =
			new ObservableCollection<ISegmentDrawable>();
		public string Name { get; set; }
		public ISegment Segment { get; }
	}
}
