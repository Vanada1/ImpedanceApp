using System;
using System.Numerics;
using System.Threading;

namespace TZ1
{
	public interface IElement
	{
		string Name { get; set; }
		double Value { get; set; }
		Complex CalculateZ(double value);
		delegate void ValueChanged(object obj, object arg);
		event ValueChanged Changed;
	}
}
