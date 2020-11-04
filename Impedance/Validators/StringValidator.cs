using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Impedance
{
	/// <summary>
	/// Serves class for working with strings
	/// </summary>
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
				resultsString.Add($"{Math.Round(result.Real, 3)} {sign} " +
				                  $"{Math.Round(result.Imaginary, 3)}i");
			}

			return resultsString;
		}

		/// <summary>
		/// Defines elements for a combo box
		/// </summary>
		/// <param name="segment">A specific segment by which a list of items will be returned</param>
		/// <returns>Segment list</returns>
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
					nameof(SegmentType.SerialCircuit)
				};
			}
			else if (segment is Element element)
			{
				segmentTypes = new[]
				{
					nameof(SegmentType.Resistor),
					nameof(SegmentType.Capacitor),
					nameof(SegmentType.Inductor)
				};
			}
			else
			{
				segmentTypes = new[]
				{
					nameof(SegmentType.SerialCircuit),
					nameof(SegmentType.ParallelCircuit),
				};
			}

			return segmentTypes;
		}
	}
}
