using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Impedance
{
	public static class StringValidator
	{
		/// <summary>
		/// Creates a list of impedance responses as a string
		/// </summary>
		/// <param name="results">List of impedance results</param>
		/// <returns>List of impedance results as string</returns>
		public static List<string> CreatingStringImpedances(List<Complex> results)
		{
			List<string> resultsString = new List<string>();

			foreach (var result in results)
			{
				string sign = "+";
				if (result.Imaginary < 0)
				{
					sign = "";
				}
				resultsString.Add($"{result.Real} {sign} " +
				                  $"{result.Imaginary}i");
			}

			return resultsString;
		}

		public static string[] GetSegmentEnum(ISegment segment)
		{
			string[] segmentTypes;
			if (segment == null)
			{
				segmentTypes = Enum.GetNames(typeof(SegmentType));
			}
			else if (segment is Circuit circuit)
			{
				segmentTypes = new []
				{
					nameof(Impedance.SegmentType.SerialCircuit)
				};
			}
			else if (segment is Element element)
			{
				segmentTypes = new[]
				{
					nameof(Impedance.SegmentType.Resistor),
					nameof(Impedance.SegmentType.Capacitor),
					nameof(Impedance.SegmentType.Inductor)
				};
			}
			else
			{
				segmentTypes = new[]
				{
					nameof(Impedance.SegmentType.SerialCircuit),
					nameof(Impedance.SegmentType.ParallelCircuit),
				};
			}

			return segmentTypes;
		}
	}
}
