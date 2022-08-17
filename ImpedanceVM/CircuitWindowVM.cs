using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Impedance;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Services;

namespace ImpedanceVM
{
    /// <summary>
    /// View Model Circuit window.
    /// </summary>
    public class CircuitWindowVM : SecondaryWindowVMBase
    {
	    /// <summary>
		/// New or editing circuit.
		/// </summary>
	    private Circuit _circuit;

	    /// <summary>
		/// Returns or sets new or editing circuit.
		/// </summary>
		public Circuit Circuit
	    {
		    get => _circuit;
		    set
		    {
			    SetProperty(ref _circuit, value);
				OnPropertyChanged(nameof(CircuitName));
		    }
	    }

		/// <summary>
		/// Returns or sets circuit name.
		/// </summary>
		public string CircuitName
		{
			get => _circuit.Name;
			set
			{
				_circuit.Name = value;
				OnPropertyChanged();
			}
		}
		
		/// <summary>
		/// Constructor.
		/// </summary>
		public CircuitWindowVM(IMessageBoxService messageBoxService) : base(messageBoxService)
		{
			
		}

		/// <summary>
		/// Invoke Ok click button.
		/// </summary>
		protected override void OnOkClick()
		{
			if (CircuitName.Length == 0)
			{
				_messageBoxService.Show("Circuit name cannot be empty",
					MessageBoxButton.Ok, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
				return;
			}
			
			DialogResult = DialogResult.Ok;
		}
    }
}
