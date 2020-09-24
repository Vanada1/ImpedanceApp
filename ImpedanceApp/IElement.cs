using System;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// Interface all elements
	/// </summary>
	public interface IElement : ISegment
	{
		/// <summary>
		/// Element value property
		/// </summary>
		double Value { get; set; }
	}
}
