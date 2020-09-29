using System;
using NUnit.Framework;
using ImpedanceApp;
using System.Numerics;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class ResistorTest
	{
		[Test(Description = "Positive test of the Resistor CalculateZ")]
		public void TestResistor_CalculateZ()
		{
			string name = "Test";
			double value = 1.0;
			double frequencies = 1.0;
			Complex expected = new Complex(value, 0.0);

			Resistor resistor = new Resistor(name, value);

			Complex actual = resistor.CalculateZ(frequencies);

			Assert.AreEqual(expected,actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Positive test of the Resistor CalculateZ")]
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
	}
}
