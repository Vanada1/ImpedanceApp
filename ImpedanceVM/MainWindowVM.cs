using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DrawItems;
using DrawItems.Segments;
using Impedance;
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
        /// Service for drawing circuit.
        /// </summary>
        private readonly IDrawable _drawable;

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
        /// Constructor.
        /// </summary>
        /// <param name="project">Application project.</param>
        /// <param name="drawable">Service for drawing circuit.</param>
        public MainWindowVM(Project project, IDrawable drawable, CircuitWindowVM circuitWindowVm)
        {
            _project = project;
            _drawable = drawable;
            _circuitWindowVm = circuitWindowVm;
            Circuits = new ObservableCollection<CircuitVM>();
            foreach (var circuit in _project.AllExamples)
            {
	            Circuits.Add(DrawingTreeViewManager.CreateDrawableCircuit(circuit));
            }

            SelectedCircuit = Circuits.First();
            AddCircuitCommand = new RelayCommand(AddCircuit);
        }

        /// <summary>
        /// Add new circuit.
        /// </summary>
        private void AddCircuit()
        {
	        
        }
    }
}