using System;
using System.Collections.ObjectModel;
using Impedance;
using Impedance.Managers;
using Services;

namespace ImpedanceVM
{
    public class SegmentWindowVM : SecondaryWindowVMBase
    {
        /// <summary>
        /// Selected segment.
        /// </summary>
        private SegmentType _selectedSegment;

        /// <summary>
        /// Set and return segment type as string.
        /// </summary>
        public ISegment Segment { get; set; }

        /// <summary>
        /// Return segment types.
        /// </summary>
        public ObservableCollection<SegmentType> SegmentsNames { get; } =
            new ObservableCollection<SegmentType>
            {
                SegmentType.ParallelCircuit,
                SegmentType.SerialCircuit
            };

        /// <summary>
        /// Set and return selected segment.
        /// </summary>
        public SegmentType SelectedSegment
        {
            get => _selectedSegment;
            set => SetProperty(ref _selectedSegment, value);
        }

        public SegmentWindowVM(IMessageBoxService messageBoxService) : base(messageBoxService)
        {
        }

        protected override void OnOkClick()
        {
            DialogResult = DialogResult.None;
            try
            {
                Segment = CircuitManager.CreateNewSegment(SelectedSegment,
                    string.Empty, double.NaN, null);
            }
            catch (ArgumentException e)
            {
                _messageBoxService.Show(e.Message, MessageBoxButton.Ok, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult = DialogResult.Ok;
        }
    }
}