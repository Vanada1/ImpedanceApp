using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impedance.Interface;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DrawItems.Segments
{
	public class SerialCircuitVM : ObservableObject, ISegmentDrawable
	{
		public SerialCircuitVM(ISegment segment)
		{
			Segment = segment;
		}

		public ObservableCollection<ISegmentDrawable> SubSegments { get; } =
			new ObservableCollection<ISegmentDrawable>();
		public string Name { get; set; }
		public ISegment Segment { get; }
	}
}
