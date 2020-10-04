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
				new ParallelCircuit( new SegmentObservableCollection
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

		[Test(Description = "Positive test of the SegmentType getter")]
		public void TestSegmentGet_CorrectValue()
		{
			SegmentType expected = SegmentType.SerialCircuit;

			var circuit = new Circuit("Test", 
				new SegmentObservableCollection());

			SegmentType actual = circuit.SegmentType;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
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
				new ParallelCircuit( new SegmentObservableCollection
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
				Assert.AreEqual(expected, actual,
					"Incorrect delete for the RemoveElement method");
			}
		}

		[Test(Description = "Positive test of the Circuit RemoveElement" +
		                    "with start segment")]
		public void TestRemoveElement_WithStartSegment()
		{
			var expected = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
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
				Assert.AreEqual(expected, actual,
					"Incorrect delete for the RemoveElement method");
			}
		}

		[Test(Description = "Positive test of the Circuit RemoveElement" +
		                    "in some segment")]

		public void TestRemoveElement_InSegmentSegment()
		{
			var expected = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
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
				Assert.AreEqual(expected, actual,
					"Incorrect delete for the RemoveElement method");
			}
		}

		[Test(Description = "Test of the Circuit Clone")]
		public void TestClone()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var expected = new Circuit("Test", segments);

			var actual = expected.Clone() as Circuit;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment equals")]
		public void TestEquals_IsEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = true;

			var circuit2 = new Circuit("Test", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment not equals")]
		public void TestEquals_IsNotEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			var circuit2 = new Circuit("Test1", 
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment other name")]
		public void TestEquals_OtherName()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			var circuit2 = new Circuit("Test1", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment other collection")]
		public void TestEquals_OtherCollection()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			var circuit2 = new Circuit("Test",
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment one is null")]
		public void TestEquals_Null()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			Circuit circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment the same object")]
		public void TestEquals_SameObject()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = true;

			Circuit circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment equals " +
		                    "operation ==")]
		public void TestEquals_IsEqualsOperationTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = true;

			var circuit2 = new Circuit("Test", segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment is not equals " +
		                    "operation ==")]
		public void TestEquals_IsEqualsOperationFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			var circuit2 = new Circuit("Test1", segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment not equals" +
		                    "operation !=")]
		public void TestEquals_IsNotEqualsOperationTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = true;

			var circuit2 = new Circuit("Test1",
				new SegmentObservableCollection());

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment equals" +
		                    "operation !=")]
		public void TestEquals_IsNotEqualsOperationFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			var circuit2 = new Circuit("Test", segments);

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment equals " +
		                    "operation ==. Null")]
		public void TestEquals_IsEqualsOperationNullTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			Circuit circuit1 = null;

			var expected = true;

			Circuit circuit2 =null;

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment equals" +
		                    "operation !=. Null")]
		public void TestEquals_IsNotEqualsOperationNullFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			Circuit circuit1 = null;

			var expected = false;

			Circuit circuit2 = null;

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Circuit Equals ISegment equals" +
		                    " with object")]
		public void TestEquals_IsEqualsObject()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = true;

			object circuit2 = new Circuit("Test", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the Circuit Equals ISegment equals" +
		                    " with object = null")]
		public void TestEquals_IsEqualsObjectNull()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			object circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the Circuit Equals ISegment equals" +
		                    " with object different type")]
		public void TestEquals_IsEqualsObjectOtherType()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = false;

			int circuit2 = 12;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the Circuit Equals ISegment equals" +
		                    " with object the same object")]
		public void TestEquals_IsEqualsObjectSame()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new Circuit("Test", segments);

			var expected = true;

			object circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the FindSegment method without inital segment")]
		public void TestFindSegment_WithoutInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);

			ISegment expected = circuit.SubSegments[0].SubSegments[1];

			ISegment actual = circuit.FindSegment("L1");

			Assert.AreEqual(expected, actual,
				"Finds the item incorrectly");
		}

		[Test(Description = "Test of the FindSegment method with inital segment")]
		public void TestFindSegment_WithInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);

			ISegment expected = circuit.SubSegments[0].SubSegments[1];

			ISegment actual = circuit.FindSegment("L1", 
				circuit.SubSegments[0]);

			Assert.AreEqual(expected, actual,
				"Finds the item incorrectly");
		}

		[Test(Description = "Test of the FindSegment method with inital segment")]
		public void TestFindSegment_WithInitalSegmentAndThisElement()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);


			ISegment expected =
				circuit.SubSegments[0].SubSegments[0];

			ISegment actual = circuit.FindSegment("R",
				circuit.SubSegments[0]);

			Assert.AreEqual(expected, actual,
				"Finds the item incorrectly");
		}

		[Test(Description = "Test of the ReplaceSegment method without inital segment")]
		public void TestReplaceSegment_WithoutInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);

			ISegment expected = new Inductor("L1", 0.05);

			ISegment actual = circuit.ReplaceSegment(circuit.SubSegments[0].SubSegments[1],
				circuit.SubSegments[0].SubSegments[0]);

			Assert.AreEqual(expected, actual,
				"Replace the item incorrectly");
		}

		[Test(Description = "Test of the ReplaceSegment method with inital segment")]
		public void TestReplaceSegment_WithInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);

			ISegment expected = circuit.SubSegments[0].SubSegments[0];

			ISegment actual = circuit.ReplaceSegment(circuit.SubSegments[0].SubSegments[1],
				circuit.SubSegments[0].SubSegments[0],
				circuit.SubSegments[0]);

			Assert.AreEqual(expected, actual,
				"Replace the item incorrectly");
		}

		[Test(Description = "Test of the FindSegment method root segment")]
		public void TestReplaceSegment_WithInitalSegmentAndRootElement()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);


			ISegment expected = new Circuit("Test1", segment);

			ISegment actual = circuit.ReplaceSegment(circuit,
				new Circuit("Test1", segment));

			Assert.AreEqual(expected, actual,
				"Replace the item incorrectly");
		}

		[Test(Description = "Test of the FindSegment method segment")]
		public void TestReplaceSegment_WithInitalSegmentAndElement()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);


			ISegment expected = null;

			ISegment actual = circuit.ReplaceSegment(circuit,
				new Circuit("Test1", segment),
				circuit.SubSegments[0].SubSegments[0]);

			Assert.AreEqual(expected, actual,
				"Replace the item incorrectly");
		}

		[Test(Description = "Test of the FindSegment method non-existent segment")]
		public void TestReplaceSegment_WithInitalSegmentAndNonExistentElement()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit = new Circuit("Test", segment);


			ISegment expected = null;

			ISegment actual = circuit.ReplaceSegment(
				new Capacitor("C2", 0.001),
				new Circuit("Test1", segment));

			Assert.AreEqual(expected, actual,
				"Replace the item incorrectly");
		}
	}
}
