using System;
using NUnit.Framework;
using ImpedanceApp;


namespace ImpedanceUnitTest
{
	[TestFixture]
	class ParallelCircuitTest
	{
		private SegmentObservableCollection CreateCircuit()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			return segment;
		}

		private ParallelCircuit CreateParallelCircuit()
		{
			return new ParallelCircuit("Test", CreateCircuit());
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "C";

			ParallelCircuit circuit = CreateParallelCircuit();
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
			ParallelCircuit circuit = CreateParallelCircuit();
			Assert.Throws<ArgumentException>(
				() => { circuit.Name = wrongName; },
				message);
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameSet_CorrectValue()
		{
			string name = "Test";
			string message = "Positive test of the Name setter not passed";
			ParallelCircuit element = CreateParallelCircuit();
			Assert.DoesNotThrow(
				() => { element.Name = name; },
				message);
		}
		
		[Test(Description = "Positive test of the SubSegments getter")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			var expected = CreateCircuit();

			ParallelCircuit element = CreateParallelCircuit();
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
			var circuit = CreateParallelCircuit();
			Assert.DoesNotThrow(
				() => { circuit.SubSegments = subSegments; },
				message);
		}

		[Test(Description = "Positive test of the OnCircuitChanged method")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var circuit = CreateParallelCircuit();
			circuit.SegmentChanged += (o, e) => wasCalled = true;
			circuit.SubSegments.Add(new Resistor("Test", 1.0));
			Assert.IsTrue(wasCalled);
		}


	}
}
