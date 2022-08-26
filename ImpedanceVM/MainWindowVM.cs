using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DrawItems;
using DrawItems.Elements;
using DrawItems.Segments;
using Impedance;
using Impedance.Elements;
using Impedance.Segments;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Services;

namespace ImpedanceVM
{
    /// <summary>
    /// View model for main window.
    /// </summary>
    public class MainWindowVM : ObservableObject
    {
        /// <summary>
        /// Application project.
        /// </summary>
        private readonly Project _project;

        /// <summary>
        /// View model for circuit window.
        /// </summary>
        private readonly CircuitWindowVM _circuitWindowVm;

        /// <summary>
        /// View model for element window.
        /// </summary>
        private readonly ElementWindowVM _elementWindowVm;

        /// <summary>
        /// Current circuit.
        /// </summary>
        private CircuitVM _selectedCircuit;

        /// <summary>
        /// Service for open new window.
        /// </summary>
        private IWindowService _windowService;

        /// <summary>
        /// Service for show message box.
        /// </summary>
        private readonly IMessageBoxService _messageBoxService;

        private ISegmentDrawable _selectedSegment;
        private ElementVM _element;

        /// <summary>
        /// Set and return current circuit
        /// </summary>
        public CircuitVM SelectedCircuit
        {
	        get => _selectedCircuit;
	        set
	        {
		        SetProperty(ref _selectedCircuit, value);
		        _project.CurrentCircuit = value.Segment as Circuit;
                OnPropertyChanged(nameof(CurrentCircuitItems));
	        }
        }

        /// <summary>
        /// Set and return selected segment in tree.
        /// </summary>
        public ISegmentDrawable SelectedSegment
        {
	        get => _selectedSegment;
	        set
	        {
		        SetProperty(ref _selectedSegment, value);
		        Element = new ElementVM(SelectedSegment.Segment is Element element ? element : null);
	        }
        }

        public ElementVM Element
        {
	        get => _element;
	        set => SetProperty(ref _element, value);
        }

        /// <summary>
        /// Return sub segments selected circuit.
        /// </summary>
        public ObservableCollection<ISegmentDrawable> CurrentCircuitItems => SelectedCircuit.SubSegments;

        /// <summary>
        /// Return all circuits.
        /// </summary>
        public ObservableCollection<CircuitVM> Circuits { get; }

        /// <summary>
        /// Return command adding new Circuit.
        /// </summary>
        public ICommand AddCircuitCommand { get; }

        /// <summary>
        /// Return command editing element.
        /// </summary>
        public ICommand EditElementCommand { get; }

        public ICommand SelectedItemChangedCommand { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="project">Application project.</param>
        /// <param name="messageBoxService"></param>
        /// <param name="windowService"></param>
        public MainWindowVM(Project project, IMessageBoxService messageBoxService, IWindowService windowService)
        {
            _project = project;
            _messageBoxService = messageBoxService;
            _windowService = windowService;
            _circuitWindowVm = new CircuitWindowVM(messageBoxService);
            Circuits = new ObservableCollection<CircuitVM>();
            foreach (var circuit in _project.AllExamples)
            {
	            Circuits.Add(DrawingTreeViewManager.CreateDrawableCircuit(circuit));
            }

            SelectedCircuit = Circuits.First();
            AddCircuitCommand = new RelayCommand(AddCircuit);
            EditElementCommand = new RelayCommand(EditElement);
            SelectedItemChangedCommand = new RelayCommand<ISegmentDrawable>(SelectedItemChanged);
        }

        private void SelectedItemChanged(ISegmentDrawable segment)
        {
	        SelectedSegment = segment;
        }

        /// <summary>
        /// Edit element
        /// </summary>
        private void EditElement()
        {
	        var segment = SelectedSegment.Segment;
	        var newSegment = Element.GetNewElement();
	        _project.CurrentCircuit.ReplaceSegment(segment, newSegment);
	        (SelectedSegment as DrawableElementBase).Segment = newSegment;
        }

        /// <summary>
        /// Add new circuit.
        /// </summary>
        private void AddCircuit()
        {
	        
        }
    }
}