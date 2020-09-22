using System;
using System.Numerics;

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
		/// The event <see cref=" ValueChanged"/> warns of a value change
		/// </summary>
		event EventHandler ValueChanged;
	}
}
