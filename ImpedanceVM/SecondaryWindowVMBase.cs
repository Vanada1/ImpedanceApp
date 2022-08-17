using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Services;

namespace ImpedanceVM
{
    public abstract class SecondaryWindowVMBase : ObservableObject
    {
        
        /// <summary>
        /// Message Box service.
        /// </summary>
        protected readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// Returns result window.
        /// </summary>
        public Result Result { get; protected set; }
        
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
        /// <param name="messageBoxService">Message box service.</param>
        protected SecondaryWindowVMBase(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
            OkClickCommand = new RelayCommand(OnOkClick);
            CancelClickCommand = new RelayCommand(OnCancelClick);
        }
        
        /// <summary>
        /// Invoke Cancel click button.
        /// </summary>
        protected virtual void OnCancelClick()
        {
            Result = Result.Cancel;
        }

        /// <summary>
        /// Invoke Ok click button.
        /// </summary>
        protected abstract void OnOkClick();
    }
}