using System.Collections.ObjectModel;
using Impedance.Interface;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace DrawItems.Elements
{
    /// <summary>
    /// Base class for elements.
    /// </summary>
    public class DrawableElementBase : ObservableObject, ISegmentDrawable
    {
		/// <summary>
		/// Element name.
		/// </summary>
	    private string _elementName;

		/// <inheritdoc/>
	    public ObservableCollection<ISegmentDrawable> SubSegments => null;

		/// <inheritdoc/>
		public string Name
	    {
		    get => _elementName;
		    set => SetProperty(ref _elementName, value);
	    }

		/// <inheritdoc/>
		public ISegment Segment { get; set; }

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="segment"></param>
		public DrawableElementBase(ISegment segment)
		{
			Segment = segment;
		}
	}
}
