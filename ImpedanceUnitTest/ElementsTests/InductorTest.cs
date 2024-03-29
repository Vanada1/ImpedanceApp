﻿using Impedance;
using NUnit.Framework;
using System;
using System.Numerics;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class InductorTest
	{
		[Test(Description = "Test Inductor constructor")]
		public void TestInductorConstructor_CorrectValue()
		{
			string name = "Test";
			double value = 1.0;

			Assert.DoesNotThrow(
				() => { Inductor inductor = new Inductor(name, value); },
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the SegmentType getter")]
		public void TestSegmentGet_CorrectValue()
		{
			SegmentType expected = SegmentType.Inductor;

			var element = new Inductor("Test", 1.0);

			SegmentType actual = element.SegmentType;

			Assert.AreEqual(expected, actual,
				"Getter SegmentType returns incorrect value");
		}

		[Test(Description = "Positive test of the Inductor CalculateZ")]
		public void TestInductor_CalculateZ()
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

		[Test(Description = "Positive test of the Inductor ToString method")]
		public void TestInductor_ToString()
		{
			string name = "Test";
			double value = 1.0;
			string expected = $"{name} = {value} H";

			Inductor inductor = new Inductor(name, value);

			string actual = inductor.ToString();

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string in ToString method");
		}

		[Test(Description = "Test of the Clone method")]
		public void TestInductor_Clone()
		{
			string name = "Test";
			double value = 1.0;

			Inductor expected = new Inductor(name, value);

			Inductor capacitor = new Inductor(name, value);

			Inductor actual = capacitor.Clone() as Inductor;

			bool result = expected.Name == actual.Name && expected.Value == actual.Value;

			Assert.IsTrue(result,
				"Incorrect copy");
		}

	}
}