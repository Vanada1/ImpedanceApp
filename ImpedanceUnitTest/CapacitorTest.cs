using System;
using NUnit.Framework;
using System.Numerics;
using ImpedanceApp;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class CapacitorTest
	{
		[Test(Description = "Test Capacitor constructor")]
		public void TestCapacitorConstructor_CorrectValue()
		{
			string name = "Test";
			double value = 1.0;
			Assert.DoesNotThrow(
				()=>{Capacitor capacitor = new Capacitor(name, value);},
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Capacitor CalculateZ")]
		public void TestCapacitor_CalculateZ()
		{
			string name = "Test";
			double value = 1.0;
			double frequency = 1.0;
			double result = -1.0 / (2 * Math.PI * frequency * value);
			Complex expected = new Complex(0.0, result);

			Capacitor capacitor = new Capacitor(name, value);

			Complex actual = capacitor.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Positive test of the Capacitor CalculateZ")]
		public void TestCapacitor_ToString()
		{
			string name = "Test";
			double value = 1.0;
			string expected = $"{name} = {value} F";

			Capacitor capacitor = new Capacitor(name, value);

			string actual = capacitor.ToString();

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string in ToString method");
		}

	}
}
