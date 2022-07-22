using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpedanceApp
{
	/// <summary>
	/// Class for working with a table
	/// </summary>
	public class ImpedanceData
	{
		/// <summary>
		/// Set and return frequency
		/// </summary>
		public double Frequency { get; set; }

		/// <summary>
		/// Set and return impedance
		/// </summary>
		public string Impedance { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="frequency">frequency</param>
		/// <param name="impedance">impedance</param>
		public ImpedanceData(double frequency, string impedance)
		{
			Frequency = frequency;
			Impedance = impedance;
		}
	}
}
