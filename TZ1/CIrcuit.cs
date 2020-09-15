using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TZ1
{

	delegate void Changed(object obg, object arg);
	class Circuit
	{ 
		public List<IElement> Elements;
		
		public Complex[] CalculateZ(double[] frequencies)
		{
			Complex[] results = new Complex[frequencies.Length];
			for (int i = 0; i < results.Length; i++)
			{
				foreach (IElement element in Elements)
				{
					results[i] += element.CalculateZ(frequencies[i]);
				}
			}
			return results;
		}

		public event Changed CircuitChanged;
	}
}
