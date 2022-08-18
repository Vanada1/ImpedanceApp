using Impedance;
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
        /// Constructor.
        /// </summary>
        /// <param name="project">Application project.</param>
        /// <param name="drawable">Service for drawing circuit.</param>
        public MainWindowVM(Project project, IDrawable drawable)
        {
            _project = project;
            _drawable = drawable;
        }
        
        
    }
}