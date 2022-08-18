using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Impedance;
using Impedance.Elements;
using Impedance.Segments;
using Impedance.Validators;

namespace ImpedanceUnitTest.Validators
{
	[TestFixture]
	class StringValidatorTest
	{
		[Test(Description = "Positive test of the CreatingStringImpedances method")]
		public void TestCreatingStringImpedances_CorrectValue()
		{
			string expected = "4 + 4i";

			List<Complex> results = new List<Complex>
			{
				new Complex(4.0,4.0)
			};

			string actual = StringValidator.CreatingStringImpedances(results)[0];

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string");
		}

		[Test(Description = "Positive test of the CreatingStringImpedances method with negative value")]
		public void TestCreatingStringImpedances_CorrectValueNegative()
		{
			string expected = "4  -4i";

			List<Complex> results = new List<Complex>
			{
				new Complex(4.0,-4.0)
			};

			string actual = StringValidator.CreatingStringImpedances(results)[0];

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string");
		}

		[Test(Description = "Positive test of the GetSegmentEnum method where segment is null")]
		public void TestGetSegmentEnum_SegmentIsNull()
		{
			var expected = Enum.GetNames(typeof(SegmentType));

			var actual = StringValidator.GetSegmentEnum(null);

			Assert.AreEqual(expected, actual,
				"Incorrect segment types");
		}

		[Test(Description = "Positive test of the GetSegmentEnum method where segment is Circuit")]
		public void TestGetSegmentEnum_SegmentIsCircuit()
		{
			var expected = new[]
			{
				nameof(SegmentType.SerialCircuit)
			};

			var actual = StringValidator.GetSegmentEnum(new Circuit("Test",
				new SegmentObservableCollection()));

			Assert.AreEqual(expected, actual,
				"Incorrect segment types");
		}


		[Test(Description = "Positive test of the GetSegmentEnum method where segment is Element")]
		public void TestGetSegmentEnum_SegmentIsElement()
		{
			var expected = new[]
			{
				nameof(SegmentType.Resistor),
				nameof(SegmentType.Capacitor),
				nameof(SegmentType.Inductor)
			};

			var actual = StringValidator.GetSegmentEnum(new Capacitor("Test", 0.0002));

			Assert.AreEqual(expected, actual,
				"Incorrect segment types");
		}


		[Test(Description = "Positive test of the GetSegmentEnum method where segment is Segment")]
		public void TestGetSegmentEnum_SegmentIsSegment()
		{
			var expected = new[]
			{
				nameof(SegmentType.SerialCircuit),
				nameof(SegmentType.ParallelCircuit),
			};

			var actual = StringValidator.GetSegmentEnum(new ParallelCircuit(
				new SegmentObservableCollection()));

			Assert.AreEqual(expected, actual,
				"Incorrect segment types");
		}
	}
}
