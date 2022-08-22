using System.Collections.ObjectModel;
using System.Linq;
using DrawItems.Segments;
using Impedance;
using Impedance.Segments;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
		        _selectedCircuit = value;
		        _project.CurrentCircuit = value.Segment as Circuit;
                OnPropertyChanged();
	        }
        }

        public ObservableCollection<CircuitVM> Circuits { get; }

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
            Circuits = new ObservableCollection<CircuitVM>(_project.AllExamples.Select(x => new CircuitVM(x)));
            SelectedCircuit = Circuits.First();
        }
    }
}