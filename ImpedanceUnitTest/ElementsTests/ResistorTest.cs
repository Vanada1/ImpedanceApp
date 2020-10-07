using ImpedanceApp;
using NUnit.Framework;
using System.Numerics;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class ResistorTest
	{
		[Test(Description = "Test Resistor constructor")]
		public void TestInductorConstructor_CorrectValue()
		{
			string name = "Test";
			double value = 1.0;

			Assert.DoesNotThrow(
				() => { Resistor inductor = new Resistor(name, value); },
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the SegmentType getter")]
		public void TestSegmentGet_CorrectValue()
		{
			SegmentType expected = SegmentType.Resistor;

			var element = new Resistor("Test", 1.0);

			SegmentType actual = element.SegmentType;

			Assert.AreEqual(expected, actual,
				"Getter SegmentType returns incorrect value");
		}

		[Test(Description = "Positive test of the Resistor CalculateZ")]
		public void TestResistor_CalculateZ()
		{
			Complex expected = new Complex(1.0, 0.0);

			string name = "Test";
			double value = 1.0;
			double frequencies = 1.0;
			Resistor resistor = new Resistor(name, value);

			Complex actual = resistor.CalculateZ(frequencies);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Positive test of the Resistor ToString method")]
		public void TestResistor_ToString()
		{
			string name = "Test";
			double value = 1.0;

			string expected = $"{name} = {value} Om";

			Resistor resistor = new Resistor(name, value);

			string actual = resistor.ToString();

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string in ToString method");
		}

		[Test(Description = "Test of the Clone method")]
		public void TestResistor_Clone()
		{
			string name = "Test";
			double value = 1.0;

			Resistor expected = new Resistor(name, value);

			Resistor capacitor = new Resistor(name, value);

			Resistor actual = capacitor.Clone() as Resistor;

			bool result = expected.Name == actual.Name && expected.Value == actual.Value;

			Assert.IsTrue(result,
				"Incorrect copy");
		}
	}
}
