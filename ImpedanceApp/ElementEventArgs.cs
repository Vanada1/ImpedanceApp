using System;

namespace ImpedanceApp
{
    /// <summary>
    /// Event args for elements
    /// </summary>
    public class ElementEventArgs : EventArgs
    {
        /// <summary>
        /// Return message from event
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// <see cref="ElementEventArgs"/> constructor
        /// </summary>
        /// <param name="message"> is the message</param>
        public ElementEventArgs(string message)
        {
            Message = message;
        }
    }
}
