using System;

namespace ImpedanceApp
{
    /// <summary>
    /// Event args for elements
    /// </summary>
    public class ElementEventArgs : EventArgs
    {
        /// <summary>
        /// Message property
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"> is the message</param>
        public ElementEventArgs(string message)
        {
            Message = message;
        }
    }
}
