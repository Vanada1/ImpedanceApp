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
		public void TestSerialCircuitConstructor()
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

			SerialCircuit SerialCircuit = new SerialCircuit(
				"Test", CreateCircuit());
			SerialCircuit.Name = expected;

			string actual = SerialCircuit.Name;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Assignment of the Name is not empty")]
		public void TestNameSet_ArgumentException()
		{
			string wrongName = "";
			string message = "If the name is empty, an exception should be thrown.";
			SerialCircuit SerialCircuit = new SerialCircuit(
				"Test", CreateCircuit());
			Assert.Throws<ArgumentException>(
				() => { SerialCircuit.Name = wrongName; },
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
			var SerialCircuit = new SerialCircuit(
				"Test", CreateCircuit());
			Assert.DoesNotThrow(
				() => { SerialCircuit.SubSegments = subSegments; },
				message);
		}

		[Test(Description = "Positive test of the Segment getter")]
		public void TestSegmentGet_CorrectValue()
		{
			Segment expected = Segment.SerialCircuit;

			var circuit = new SerialCircuit("Test", 
				new SegmentObservableCollection());

			Segment actual = circuit.Segment;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the OnCircuitChanged method")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var SerialCircuit = new SerialCircuit(
				"Test", CreateCircuit());
			SerialCircuit.SegmentChanged += (o, e) => wasCalled = true;
			SerialCircuit.SubSegments.Add(new Resistor("Test", 1.0));
			Assert.IsTrue(wasCalled);
		}

		[Test(Description = "Positive test of the SerialCircuit CalculateZ")]
		public void TestCalculateZ()
		{
			double frequency = 1.0;
			var r = new Resistor("R", 5.0);
			var l = new Inductor("L1", 0.05);
			Complex result = r.CalculateZ(frequency) +  l.CalculateZ(frequency);
			Complex expected = result;

			SerialCircuit SerialCircuit = new SerialCircuit(
				"Test", CreateCircuit());

			Complex actual = SerialCircuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Test of the SerialCircuit Clone")]
		public void TestClone()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var expected = new SerialCircuit("Test", segments);

			var actual = expected.Clone() as SerialCircuit;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals")]
		public void TestEqualsISegment_IsEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = true;

			var circuit2 = new SerialCircuit("Test", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment not equals")]
		public void TestEqualsISegment_IsNotEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			var circuit2 = new SerialCircuit("Test1", 
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment other name")]
		public void TestEqualsISegment_OtherName()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			var circuit2 = new SerialCircuit("Test1", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment other collection")]
		public void TestEqualsISegment_OtherCollection()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			var circuit2 = new SerialCircuit("Test",
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment one is null")]
		public void TestEqualsISegment_Null()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			SerialCircuit circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment the same object")]
		public void TestEqualsISegment_SameObject()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = true;

			SerialCircuit circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals " +
		                    "operation ==")]
		public void TestEqualsISegment_IsEqualsOperationTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = true;

			var circuit2 = new SerialCircuit("Test", segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment is not equals " +
		                    "operation ==")]
		public void TestEqualsISegment_IsEqualsOperationFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			var circuit2 = new SerialCircuit("Test1", segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment not equals" +
		                    "operation !=")]
		public void TestEqualsISegment_IsNotEqualsOperationTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = true;

			var circuit2 = new SerialCircuit("Test1",
				new SegmentObservableCollection());

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
		                    "operation !=")]
		public void TestEqualsISegment_IsNotEqualsOperationFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			var circuit2 = new SerialCircuit("Test", segments);

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals " +
		                    "operation ==. Null")]
		public void TestEqualsISegment_IsEqualsOperationNullTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			SerialCircuit circuit1 = null;

			var expected = true;

			SerialCircuit circuit2 =null;

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
		                    "operation !=. Null")]
		public void TestEqualsISegment_IsNotEqualsOperationNullFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			SerialCircuit circuit1 = null;

			var expected = false;

			SerialCircuit circuit2 = null;

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
		                    " with object")]
		public void TestEqualsISegment_IsEqualsObject()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = true;

			object circuit2 = new SerialCircuit("Test", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
		                    " with object = null")]
		public void TestEqualsISegment_IsEqualsObjectNull()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			object circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
		                    " with object different type")]
		public void TestEqualsISegment_IsEqualsObjectOtherType()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = false;

			int circuit2 = 12;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
		                    " with object the same object")]
		public void TestEqualsISegment_IsEqualsObjectSame()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit("Test", segments);

			var expected = true;

			object circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}
	}
}
