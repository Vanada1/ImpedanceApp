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
						 CreateCircuit());
				},
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "Serial0";

			SerialCircuit SerialCircuit = new SerialCircuit(
				 CreateCircuit());

			string actual = SerialCircuit.Name;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the SubSegments getter")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			var expected = CreateCircuit();

			SerialCircuit element = new SerialCircuit(
				 CreateCircuit());
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
				 CreateCircuit());
			Assert.DoesNotThrow(
				() => { SerialCircuit.SubSegments = subSegments; },
				message);
		}

		[Test(Description = "Positive test of the SegmentType getter")]
		public void TestSegmentGet_CorrectValue()
		{
			SegmentType expected = SegmentType.SerialCircuit;

			var circuit = new SerialCircuit( 
				new SegmentObservableCollection());

			SegmentType actual = circuit.SegmentType;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the OnCircuitChanged method")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var SerialCircuit = new SerialCircuit(
				 CreateCircuit());
			SerialCircuit.SegmentChanged += (o, e) => wasCalled = true;
			SerialCircuit.SubSegments.Add(new Resistor( "Test", 1.0));
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
				 CreateCircuit());

			Complex actual = SerialCircuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Test of the SerialCircuit Clone")]
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

			var expected = new SerialCircuit( segments);

			var actual = expected.Clone() as SerialCircuit;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals")]
		public void TestEqualsISegment_IsEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = true;

			var circuit2 = new SerialCircuit( segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment not equals")]
		public void TestEqualsISegment_IsNotEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = false;

			var circuit2 = new SerialCircuit( 
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment other collection")]
		public void TestEqualsISegment_OtherCollection()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = false;

			var circuit2 = new SerialCircuit(
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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = true;

			var circuit2 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = false;

			segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01),
				new Inductor("L1", 0.05)
			};

			var circuit2 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = true;

			var circuit2 = new SerialCircuit(
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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = false;

			var circuit2 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
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
				new ParallelCircuit( new SegmentObservableCollection
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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = true;

			object circuit2 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

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
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var circuit1 = new SerialCircuit( segments);

			var expected = true;

			object circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}
	}
}
