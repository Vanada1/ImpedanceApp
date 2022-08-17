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
    public class CircuitWindowVM : ObservableObject
    {
	    /// <summary>
	    /// Message Box service.
	    /// </summary>
	    private readonly IMessageBoxService _messageBoxService;
	    
		/// <summary>
		/// New or editing circuit.
		/// </summary>
	    private Circuit _circuit;

		/// <summary>
		/// Result window.
		/// </summary>
		private Result _result;

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
		/// Returns result window.
		/// </summary>
		public Result Result => _result;

		/// <summary>
		/// Returns Ok command button click.
		/// </summary>
		public ICommand OkClickCommand { get; }

		/// <summary>
		/// Returns Cancel command button click.
		/// </summary>
		public ICommand CancelClickCommand { get; }

		/// <summary>
		/// Constructor.
		/// </summary>
		public CircuitWindowVM(IMessageBoxService messageBoxService)
		{
			_messageBoxService = messageBoxService;
			OkClickCommand = new RelayCommand(OnOkClick);
			CancelClickCommand = new RelayCommand(OnCancelClick);
		}

		/// <summary>
		/// Invoke Cancel click button.
		/// </summary>
		private void OnCancelClick()
		{
			_result = Result.Cancel;
		}

		/// <summary>
		/// Invoke Ok click button.
		/// </summary>
		private void OnOkClick()
		{
			_result = Result.Ok;
		}
    }
}
