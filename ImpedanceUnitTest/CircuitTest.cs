using System;
using NUnit.Framework;
using ImpedanceApp;
using System.Numerics;
using System.Collections.Generic;

namespace ImpedanceUnitTest
{
	[TestFixture]
	class CircuitTest
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

		[Test(Description = "Test Circuit constructor")]
		public void TestCircuitConstructor()
		{
			string name = "Test";
			Assert.DoesNotThrow(
				() => {
					Circuit inductor = new Circuit(
						name, CreateCircuit());
				},
				"Constructor test not passed");
		}

		[Test(Description = "Test Circuit default constructor")]
		public void TestCircuitDefaultConstructor()
		{
			string name = "Test";
			Assert.DoesNotThrow(
				() => {
					Circuit inductor = new Circuit();
				},
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "C";

			Circuit circuit = new Circuit(
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
			Circuit circuit = new Circuit(
				"Test", CreateCircuit());
			Assert.Throws<ArgumentException>(
				() => { circuit.Name = wrongName; },
				message);
		}

		[Test(Description = "Positive test of the Name setter")]
		public void TestNameSet_CorrectValue()
		{
			string name = "Test";
			string message = "Positive test of the Name setter not passed";
			Circuit element = new Circuit(
				"Test", CreateCircuit());
			Assert.DoesNotThrow(
				() => { element.Name = name; },
				message);
		}

		[Test(Description = "Positive test of the SubSegments getter")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			var expected = CreateCircuit();

			Circuit element = new Circuit(
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
			var circuit = new Circuit(
				"Test", CreateCircuit());
			Assert.DoesNotThrow(
				() => { circuit.SubSegments = subSegments; },
				message);
		}

		[Test(Description = "Positive test of the OnCircuitChanged method")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var circuit = new Circuit(
				"Test", CreateCircuit());
			circuit.SegmentChanged += (o, e) => wasCalled = true;
			circuit.SubSegments.Add(new Resistor("Test", 1.0));
			Assert.IsTrue(wasCalled);
		}

		[Test(Description = "Positive test of the Circuit CalculateZ")]
		public void TestCalculateZ()
		{
			List <double> frequencies = new List<double>{1.0, 2.0};
			var r = new Resistor("R", 5.0);
			var l = new Inductor("L1", 0.05);
			var c = new Capacitor("C1", 0.01);
			List<Complex> results = new List<Complex>();
			foreach (var frequency in frequencies)
			{
				Complex result1 = 1.0 / r.CalculateZ(frequency) + 1.0 / l.CalculateZ(frequency);
				result1 = 1 / result1;
				Complex result = result1 + c.CalculateZ(frequency);
				results.Add(result);
			}
			List<Complex> expected = results;

			Circuit circuit = new Circuit(
				"Test", CreateCircuit());

			List<Complex> actual = circuit.CalculateZ(frequencies);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Positive test of the Circuit CalculateZ with " +
		                    "zero count frequencies")]
		public void TestCalculateZ_ZeroFrequencies()
		{
			List<double> frequencies = new List<double>();
			
			int expected = 0;

			Circuit inductor = new Circuit(
				"Test", CreateCircuit());

			List<Complex> actual = inductor.CalculateZ(frequencies);

			Assert.AreEqual(expected, actual.Count,
					"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Positive test of the Circuit CalculateZ with " +
		                    "zero elements")]
		public void TestCalculateZ_ZeroElements()
		{
			List<double> frequencies = new List<double> { 1.0, 2.0 };
			List<Complex> results = new List<Complex>();
			foreach (var frequency in frequencies)
			{
				Complex result=new Complex(0.0,0.0);
				results.Add(result);
			}
			List<Complex> expected = results;

			Circuit inductor = new Circuit(
				"Test", new SegmentObservableCollection());
			List<Complex> actual = inductor.CalculateZ(frequencies);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Positive test of the Circuit RemoveElement")]
		public void TestRemoveElement()
		{
			var expected = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				})
			};

			Circuit circuit = new Circuit("Test",
				CreateCircuit());
			ISegment deletedElement = circuit.SubSegments[1];
			circuit.RemoveElement(deletedElement);

			var actual = circuit.SubSegments;

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(expected[i].Name, actual[i].Name,
					"Incorrect delete for the RemoveElement method");
			}
		}

		[Test(Description = "Positive test of the Circuit RemoveElement" +
		                    "with start segment")]
		public void TestRemoveElement_WithStartSegment()
		{
			var expected = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			Circuit circuit = new Circuit("Test",
				CreateCircuit());
			ISegment deletedElement = circuit.SubSegments[0].SubSegments[0];
			circuit.RemoveElement(deletedElement, circuit.SubSegments[0]);

			var actual = circuit.SubSegments;

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(expected[i].Name, actual[i].Name,
					"Incorrect delete for the RemoveElement method");
			}
		}

		[Test(Description = "Positive test of the Circuit RemoveElement" +
		                    "in some segment")]

		public void TestRemoveElement_InSegmentSegment()
		{
			var expected = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			Circuit circuit = new Circuit("Test",
				CreateCircuit());
			ISegment deletedElement = circuit.SubSegments[0].SubSegments[0];
			circuit.RemoveElement(deletedElement);

			var actual = circuit.SubSegments;

			for (int i = 0; i < expected.Count; i++)
			{
				Assert.AreEqual(expected[i].Name, actual[i].Name,
					"Incorrect delete for the RemoveElement method");
			}
		}
	}
}
