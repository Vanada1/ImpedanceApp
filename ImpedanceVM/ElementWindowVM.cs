using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Impedance;
using Impedance.Interface;
using Impedance.Managers;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Services;

namespace ImpedanceVM
{
    public class ElementWindowVM : SecondaryWindowVMBase
    {
        /// <summary>
        /// Segment type as string.
        /// </summary>
        private SegmentType _segmentType = SegmentType.Capacitor;
        
        /// <summary>
        /// Segment name.
        /// </summary>
        private string _segmentName;

        /// <summary>
        /// Value as string.
        /// </summary>
        private string _value;

        /// <summary>
        /// Set and return current segment for changed
        /// </summary>
        public ISegment Segment { get; set; }

        /// <summary>
        /// Set and return segment type as string.
        /// </summary>
        public SegmentType SegmentType
        {
            get => _segmentType;
            set => SetProperty(ref _segmentType, value);
        }

        /// <summary>
        /// Set and return segment name.
        /// </summary>
        public string SegmentName
        {
            get => _segmentName;
            set => SetProperty(ref _segmentName, value);
        }

        /// <summary>
        /// Set and return value as string.
        /// </summary>
        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public ObservableCollection<SegmentType> SegmentTypes { get; } =
            new ObservableCollection<SegmentType>
            {
                Impedance.SegmentType.Capacitor,
                Impedance.SegmentType.Inductor,
                Impedance.SegmentType.Resistor
            };

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messageBoxService"></param>
        public ElementWindowVM(IMessageBoxService messageBoxService) : base(messageBoxService)
        {
            
        }

        /// <summary>
        /// Invoke Ok click button.
        /// </summary>
        protected override void OnOkClick()
        {
            try
            {
                Segment = CircuitManager.CreateNewElement(SegmentType, SegmentName, Value);
            }
            catch (ArgumentException e)
            {
                _messageBoxService.Show(e.Message, MessageBoxButton.Ok, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
                return;
            }
			
            DialogResult = DialogResult.Ok;
        }
    }
}