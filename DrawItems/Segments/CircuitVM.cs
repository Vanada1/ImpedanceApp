using System.Collections.ObjectModel;
using Impedance.Interface;
using Impedance.Segments;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DrawItems.Segments
{
	/// <summary>
	/// Circuit view model for drawing.
	/// </summary>
	[SegmentTypeValidation(typeof(Circuit))]
	public class CircuitVM : ObservableObject, ISegmentDrawable
	{
		/// <summary>
		/// Circuit name.
		/// </summary>
		private string _name;

		/// <inheritdoc/>
		public ObservableCollection<ISegmentDrawable> SubSegments { get; } =
			new ObservableCollection<ISegmentDrawable>();

		/// <inheritdoc/>
		public string Name
		{
			get => _name;
			set
			{
				SetProperty(ref _name, value);
				Segment.Name = _name;
			}
		}

		/// <inheritdoc/>
		public ISegment Segment { get; }

		public CircuitVM(ISegment segment)
		{
			Segment = segment;
			_name = Segment.Name;
		}
	}
}
