using System;
using NUnit.Framework;
using System.Numerics;
using ImpedanceApp;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class InductorTest
	{
		[Test(Description = "Test Inductor constructor")]
		public void TestCapacitorConstructor_CorrectValue()
		{
			string name = "Test";
			double value = 1.0;
			Assert.DoesNotThrow(
				() => { Inductor inductor = new Inductor(name, value); },
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Inductor CalculateZ")]
		public void TestCapacitor_CalculateZ()
		{
			string name = "Test";
			double value = 1.0;
			double frequency = 1.0;
			double result = 2 * Math.PI * frequency * value;
			Complex expected = new Complex(0.0, result);

			Inductor inductor = new Inductor(name, value);

			Complex actual = inductor.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Positive test of the Inductor CalculateZ")]
		public void TestCapacitor_ToString()
		{
			string name = "Test";
			double value = 1.0;
			string expected = $"{name} = {value} H";

			Inductor inductor = new Inductor(name, value);

			string actual = inductor.ToString();

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string in ToString method");
		}

	}
}