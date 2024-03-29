﻿using Impedance;
using NUnit.Framework;
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
		public void TestSerialCircuitConstructor_CorrectValue()
		{
			Assert.DoesNotThrow(
				() =>
				{
					SerialCircuit serialCircuit = new SerialCircuit(
						 CreateCircuit());
				},
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "Serial";

			SerialCircuit serialCircuit = new SerialCircuit(
				 CreateCircuit());

			string actual = serialCircuit.Name;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the SubSegments getter")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			var expected = CreateCircuit();

			SerialCircuit serialCircuit = new SerialCircuit(
				 CreateCircuit());
			serialCircuit.SubSegments = expected;

			var actual = serialCircuit.SubSegments;

			Assert.AreEqual(expected, actual,
				"Getter SubSegments returns incorrect value");
		}

		[Test(Description = "Positive test of the SubSegments setter")]
		public void TestSubSegmentsSet_CorrectValue()
		{
			var subSegments = CreateCircuit();
			string message = "Positive test of the SubSegments setter not passed";
			var serialCircuit = new SerialCircuit(
				 CreateCircuit());

			Assert.DoesNotThrow(
				() => { serialCircuit.SubSegments = subSegments; },
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

		[Test(Description = "Positive test of the SegmentChanged event")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var serialCircuit = new SerialCircuit(
				 CreateCircuit());
			serialCircuit.SegmentChanged += (o, e) => wasCalled = true;
			serialCircuit.SubSegments.Add(new Resistor("Test", 1.0));

			Assert.IsTrue(wasCalled);
		}

		[Test(Description = "Positive test of the SerialCircuit CalculateZ")]
		public void TestSerialCircuitCalculateZ()
		{
			double frequency = 1.0;
			var r = new Resistor("R", 5.0);
			var l = new Inductor("L1", 0.05);
			Complex result = r.CalculateZ(frequency) + l.CalculateZ(frequency);
			Complex expected = result;

			SerialCircuit SerialCircuit = new SerialCircuit(
				 CreateCircuit());

			Complex actual = SerialCircuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Test of the SerialCircuit Clone")]
		public void TestSerialCircuitClone()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var expected = new SerialCircuit(segments);

			var actual = expected.Clone() as SerialCircuit;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals")]
		public void TestEqualsISegment_IsEquals()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			var circuit2 = new SerialCircuit(segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment not equals")]
		public void TestEqualsISegment_IsNotEquals()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			var circuit2 = new SerialCircuit(
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment other collection")]
		public void TestEqualsISegment_OtherCollection()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			var circuit2 = new SerialCircuit(
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment one is null")]
		public void TestEqualsISegment_Null()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			SerialCircuit circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment the same object")]
		public void TestEqualsISegment_SameObject()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			SerialCircuit circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals " +
							"operation ==")]
		public void TestEqualsISegment_IsEqualsOperationTrue()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			var circuit2 = new SerialCircuit(segments);

			var actual = circuit1 == circuit2;

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment is not equals " +
							"operation ==")]
		public void TestEqualsISegment_IsEqualsOperationFalse()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01),
				new Inductor("L1", 0.05)
			};

			var circuit2 = new SerialCircuit(segments);

			var actual = circuit1 == circuit2;

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment not equals" +
							"operation !=")]
		public void TestEqualsISegment_IsNotEqualsOperationTrue()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			var circuit2 = new SerialCircuit(
				new SegmentObservableCollection());

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
							"operation !=")]
		public void TestEqualsISegment_IsNotEqualsOperationFalse()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			var circuit2 = new SerialCircuit(segments);

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals " +
							"operation ==. Null")]
		public void TestEqualsISegment_IsEqualsOperationNullTrue()
		{
			var expected = true;

			SerialCircuit circuit1 = null;
			SerialCircuit circuit2 = null;

			var actual = circuit1 == circuit2;

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
							"operation !=. Null")]
		public void TestEqualsISegment_IsNotEqualsOperationNullFalse()
		{
			var expected = false;

			SerialCircuit circuit1 = null;
			SerialCircuit circuit2 = null;

			var actual = circuit1 != circuit2;

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
							" with object")]
		public void TestEqualsISegment_IsEqualsObject()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			object circuit2 = new SerialCircuit(segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}


		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
							" with object = null")]
		public void TestEqualsISegment_IsEqualsObjectNull()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			object circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}


		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
							" with object different type")]
		public void TestEqualsISegment_IsEqualsObjectOtherType()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			int circuit2 = 12;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}


		[Test(Description = "Test of the SerialCircuit Equals ISegment equals" +
							" with object the same object")]
		public void TestEqualsISegment_IsEqualsObjectSame()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new SerialCircuit(segments);
			object circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Positive test of the SerialCircuit ToString method")]
		public void TestSerialCircuit_ToString()
		{
			string expected = "Serial";

			SerialCircuit serialCircuit = new SerialCircuit(new SegmentObservableCollection());

			string actual = serialCircuit.ToString();

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string in ToString method");
		}
	}
}
