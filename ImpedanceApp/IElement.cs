using System;
using System.Numerics;
using System.Threading;

namespace ImpedanceApp
{
	/// <summary>
	/// Interface all elements
	/// </summary>
	public interface IElement
	{
		/// <summary>
		/// Element name property
		/// </summary>
		string Name { get; set; }
		/// <summary>
		/// Element value property
		/// </summary>
		double Value { get; set; }

		/// <summary>
		/// Calculate impedance of element
		/// </summary>
		/// <param name="frequency"></param>
		/// <returns>Complex impedance value</returns>
		Complex CalculateZ(double frequency);

		/// <summary>
		/// The delegate <see cref=" Changed"/> warns of a value change
		/// </summary>
		/// <param name="obj"> the object, wich has been change</param>
		/// <param name="arg">the argument for output </param>
		delegate void Changed(object obj, object arg);

		/// <summary>
		/// The event <see cref=" ValueChanged"/> warns of a value change
		/// </summary>
		event Changed ValueChanged;
	}
}
