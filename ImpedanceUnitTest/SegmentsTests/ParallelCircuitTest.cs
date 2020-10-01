using System;
using NUnit.Framework;
using ImpedanceApp;
using System.Numerics;


namespace ImpedanceUnitTest
{
	[TestFixture]
	class ParallelCircuitTest
	{
		private SegmentObservableCollection CreateCircuit()
		{
			return new SegmentObservableCollection
			{
				new Resistor("R", 5.0),
				new Inductor("L1", 0.05)
			};
		}

		[Test(Description = "Test ParallelCircuit constructor")]
		public void TestParallelCircuitConstructor()
		{
			string name = "Test";
			Assert.DoesNotThrow(
				() => { ParallelCircuit inductor = new ParallelCircuit(
					name, CreateCircuit()); },
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "C";

			ParallelCircuit ParallelCircuit = new ParallelCircuit(
				"Test", CreateCircuit());
			ParallelCircuit.Name = expected;

			string actual = ParallelCircuit.Name;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Assignment of the Name is not empty")]
		public void TestNameSet_ArgumentException()
		{
			string wrongName = "";
			string message = "If the name is empty, an exception should be thrown.";
			ParallelCircuit ParallelCircuit = new ParallelCircuit(
				"Test", CreateCircuit());
			Assert.Throws<ArgumentException>(
				() => { ParallelCircuit.Name = wrongName; },
				message);
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameSet_CorrectValue()
		{
			string name = "Test";
			string message = "Positive test of the Name setter not passed";
			ParallelCircuit element = new ParallelCircuit(
				"Test", CreateCircuit());
			Assert.DoesNotThrow(
				() => { element.Name = name; },
				message);
		}
		
		[Test(Description = "Positive test of the SubSegments getter")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			var expected = CreateCircuit();

			ParallelCircuit element = new ParallelCircuit(
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
			var ParallelCircuit = new ParallelCircuit(
				"Test", CreateCircuit());
			Assert.DoesNotThrow(
				() => { ParallelCircuit.SubSegments = subSegments; },
				message);
		}

		[Test(Description = "Positive test of the OnCircuitChanged method")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var ParallelCircuit = new ParallelCircuit(
				"Test", CreateCircuit());
			ParallelCircuit.SegmentChanged += (o, e) => wasCalled = true;
			ParallelCircuit.SubSegments.Add(new Resistor("Test", 1.0));
			Assert.IsTrue(wasCalled);
		}

		[Test(Description = "Positive test of the ParallelCircuit CalculateZ")]
		public void TestCalculateZ()
		{
			double frequency = 1.0;
			var r = new Resistor("R", 5.0);
			var l = new Inductor("L1", 0.05);
			Complex result = 1 / r.CalculateZ(frequency) + 1 / l.CalculateZ(frequency);
			result = 1 / result;
			Complex expected = result;

			ParallelCircuit parallelCircuit = new ParallelCircuit(
				"Test", CreateCircuit());

			Complex actual = parallelCircuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Test of the ParallelCircuit Clone")]
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

			var expected = new ParallelCircuit("Test", segments);

			var actual = expected.Clone() as ParallelCircuit;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals")]
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = true;

			var circuit2 = new ParallelCircuit("Test", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment not equals")]
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			var circuit2 = new ParallelCircuit("Test1",
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment other name")]
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			var circuit2 = new ParallelCircuit("Test1", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment other collection")]
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			var circuit2 = new ParallelCircuit("Test",
				new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment one is null")]
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			ParallelCircuit circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment the same object")]
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = true;

			ParallelCircuit circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals " +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = true;

			var circuit2 = new ParallelCircuit("Test", segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment is not equals " +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			var circuit2 = new ParallelCircuit("Test1", segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment not equals" +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = true;

			var circuit2 = new ParallelCircuit("Test1",
				new SegmentObservableCollection());

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			var circuit2 = new ParallelCircuit("Test", segments);

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals " +
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

			ParallelCircuit circuit1 = null;

			var expected = true;

			ParallelCircuit circuit2 = null;

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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

			ParallelCircuit circuit1 = null;

			var expected = false;

			ParallelCircuit circuit2 = null;

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = true;

			object circuit2 = new ParallelCircuit("Test", segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			object circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = false;

			int circuit2 = 12;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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

			var circuit1 = new ParallelCircuit("Test", segments);

			var expected = true;

			object circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}
	}
}
