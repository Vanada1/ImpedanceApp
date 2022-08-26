using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Impedance;
using Impedance.Elements;
using Impedance.Interface;
using Impedance.Managers;
using Impedance.Segments;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ImpedanceVM
{
	public class ElementVM : ObservableObject
	{
		/// <summary>
		/// Element VM.
		/// </summary>
		private Element _element;

		/// <summary>
		/// Name of element.
		/// </summary>
		private string _name;

		/// <summary>
		/// Element value.
		/// </summary>
		private double _value;

		/// <summary>
		/// Segment type.
		/// </summary>
		private SegmentType _segmentType;

		/// <summary>
		/// Set and return name of element.
		/// </summary>
		public string Name
		{
			get => _name;
			set => SetProperty(ref _name, value);
		}

		/// <summary>
		/// Set and return segment type.
		/// </summary>
		public SegmentType SegmentType
		{
			get => _segmentType;
			set => SetProperty(ref _segmentType, value);
		}

		/// <summary>
		/// Set and return element value.
		/// </summary>
		public double Value
		{
			get => _value;
			set => SetProperty(ref _value, value);
		}

		public ElementVM(Element element)
		{
			_element = element;
			if (element == null)
			{
				return;
			}

			Name = _element.Name;
			Value = _element.Value;
			SegmentType = _element.SegmentType;
		}

		public ISegment GetNewElement()
		{
			if (_element.SegmentType != SegmentType)
			{
				return CircuitManager.CreateNewElement(SegmentType, Name, Value.ToString());
			}

			_element.Name = Name;
			_element.Value = Value;
			return _element;
		}
	}
}
