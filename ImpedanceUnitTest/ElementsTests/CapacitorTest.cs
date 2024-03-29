﻿using Impedance;
using NUnit.Framework;
using System;
using System.Numerics;

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
				() => { Capacitor capacitor = new Capacitor(name, value); },
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the SegmentType getter")]
		public void TestSegmentGet_CorrectValue()
		{
			SegmentType expected = SegmentType.Capacitor;

			var element = new Capacitor("Test", 1.0);

			SegmentType actual = element.SegmentType;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
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

		[Test(Description = "Positive test of the Capacitor ToString method")]
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

		[Test(Description = "Test of the Clone method")]
		public void TestCapacitor_Clone()
		{
			string name = "Test";
			double value = 1.0;

			Capacitor expected = new Capacitor(name, value);

			Capacitor capacitor = new Capacitor(name, value);

			Capacitor actual = capacitor.Clone() as Capacitor;

			bool result = (expected.Name == actual.Name && expected.Value == expected.Value);

			Assert.IsTrue(result,
				"Incorrect copy");
		}


	}
}
