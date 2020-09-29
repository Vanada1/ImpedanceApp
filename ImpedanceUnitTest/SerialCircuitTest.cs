using System;
using NUnit.Framework;
using ImpedanceApp;
using System.Numerics;

namespace ImpedanceUnitTest
{
	[TestFixture]
	class SerialCircuitTest
	{
		private SegmentObservableCollection CreateCircuit()
		{
			return new SegmentObservableCollection
			{
				new Resistor("R", 5.0),
				new Inductor("L1", 0.05)
			};
		}

		[Test(Description = "Test SerialCircuit constructor")]
		public void CreateSerialCircuit()
		{
			string name = "Test";
			Assert.DoesNotThrow(
				() => {
					SerialCircuit inductor = new SerialCircuit(
						name, CreateCircuit());
				},
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "C";

			SerialCircuit circuit = new SerialCircuit(
				"Test", CreateCircuit());
			circuit.Name = expected;

			string actual = circuit.Name;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Assignment of the Name is not empty")]
		public void TestNameSet_ArgumentException()
		{
			string wrongName = "";
			string message = "If the name is empty, an exception should be thrown.";
			SerialCircuit circuit = new SerialCircuit(
				"Test", CreateCircuit());
			Assert.Throws<ArgumentException>(
				() => { circuit.Name = wrongName; },
				message);
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameSet_CorrectValue()
		{
			string name = "Test";
			string message = "Positive test of the Name setter not passed";
			SerialCircuit element = new SerialCircuit(
				"Test", CreateCircuit());
			Assert.DoesNotThrow(
				() => { element.Name = name; },
				message);
		}

		[Test(Description = "Positive test of the SubSegments getter")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			var expected = CreateCircuit();

			SerialCircuit element = new SerialCircuit(
				"Test", CreateCircuit());
			element.SubSegments = expected;

			var actual = element.SubSegments;

			Assert.AreEqual(expected, actual,
				"Getter SubSegments returns incorrect value");
		}

		[Test(Description = "Positive test of the SubSegments setter")]
		public void TestSubSegmentsSet_CorrectValue()
		{
			var subSegments = CreateCircuit();
			string message = "Positive test of the SubSegments setter not passed";
			var circuit = new SerialCircuit(
				"Test", CreateCircuit());
			Assert.DoesNotThrow(
				() => { circuit.SubSegments = subSegments; },
				message);
		}

		[Test(Description = "Positive test of the OnCircuitChanged method")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var circuit = new SerialCircuit(
				"Test", CreateCircuit());
			circuit.SegmentChanged += (o, e) => wasCalled = true;
			circuit.SubSegments.Add(new Resistor("Test", 1.0));
			Assert.IsTrue(wasCalled);
		}

		[Test(Description = "Positive test of the SerialCircuit CalculateZ")]
		public void TestCalculateZ()
		{
			double frequency = 1.0;
			var r = new Resistor("R", 5.0);
			var l = new Inductor("L1", 0.05);
			Complex result = r.CalculateZ(frequency) +  l.CalculateZ(frequency);
			result = result;
			Complex expected = result;

			SerialCircuit inductor = new SerialCircuit(
				"Test", CreateCircuit());

			Complex actual = inductor.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}
	}
}
