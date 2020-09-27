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
		/// Set and return <see cref="Value"/> of the <see cref="IElement"/>
		/// </summary>
		double Value { get; set; }
	}
}
