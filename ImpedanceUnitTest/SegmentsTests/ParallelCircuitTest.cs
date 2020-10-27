using Impedance;
using NUnit.Framework;
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
		public void TestParallelCircuitConstructor_CorrectValue()
		{
			Assert.DoesNotThrow(
				() => { ParallelCircuit parallelCircuit = new ParallelCircuit(CreateCircuit()); },
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "Parallel";

			ParallelCircuit parallelCircuit = new ParallelCircuit(CreateCircuit());

			string actual = parallelCircuit.Name;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the SubSegments getter")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			var expected = CreateCircuit();

			ParallelCircuit parallelCircuit = new ParallelCircuit(
				CreateCircuit()) {SubSegments = expected};

			var actual = parallelCircuit.SubSegments;

			Assert.AreEqual(expected, actual,
				"Getter SubSegments returns incorrect value");
		}

		[Test(Description = "Positive test of the SubSegments setter")]
		public void TestSubSegmentsSet_CorrectValue()
		{
			var subSegments = CreateCircuit();
			string message = "Positive test of the SubSegments setter not passed";
			var parallelCircuit = new ParallelCircuit(CreateCircuit());
			Assert.DoesNotThrow(
				() => { parallelCircuit.SubSegments = subSegments; },
				message);
		}

		[Test(Description = "Positive test of the SegmentType getter")]
		public void TestSegmentGet_CorrectValue()
		{
			SegmentType expected = SegmentType.ParallelCircuit;

			var circuit = new ParallelCircuit(new SegmentObservableCollection());

			SegmentType actual = circuit.SegmentType;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the OnCircuitChanged method")]
		public void TestOnCircuitChanged()
		{
			bool wasCalled = false;
			var parallelCircuit = new ParallelCircuit(CreateCircuit());
			parallelCircuit.SegmentChanged += (o, e) => wasCalled = true;
			parallelCircuit.SubSegments.Add(new Resistor("Test", 1.0));

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

			ParallelCircuit parallelCircuit = new ParallelCircuit(CreateCircuit());

			Complex actual = parallelCircuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}

		[Test(Description = "Test of the ParallelCircuit Clone")]
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

			var expected = new ParallelCircuit(segments);

			var actual = expected.Clone() as ParallelCircuit;

			Assert.AreEqual(expected.SubSegments, actual.SubSegments,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals")]
		public void TestEqualsISegment_IsEquals()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			var circuit2 = new ParallelCircuit(segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment not equals")]
		public void TestEqualsISegment_IsNotEquals()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			var circuit2 = new ParallelCircuit(new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment other collection")]
		public void TestEqualsISegment_OtherCollection()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			var circuit2 = new ParallelCircuit(new SegmentObservableCollection());

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment one is null")]
		public void TestEqualsISegment_Null()
		{
			var expected = false;
			
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			ParallelCircuit circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment the same object")]
		public void TestEqualsISegment_SameObject()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			ParallelCircuit circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals " +
							"operation ==")]
		public void TestEqualsISegment_IsEqualsOperationTrue()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			var circuit2 = new ParallelCircuit(segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment is not equals " +
							"operation ==")]
		public void TestEqualsISegment_IsEqualsOperationFalse()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			segments = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01),
				new Inductor("L1", 0.05)
			};

			var circuit2 = new ParallelCircuit(segments);

			var actual = circuit1 == circuit2;
			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment not equals" +
							"operation !=")]
		public void TestEqualsISegment_IsNotEqualsOperationTrue()
		{
			var expected = true;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			var circuit2 = new ParallelCircuit(new SegmentObservableCollection());

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
							"operation !=")]
		public void TestEqualsISegment_IsNotEqualsOperationFalse()
		{
			var expected = false;

			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			var circuit1 = new ParallelCircuit(segments);
			var circuit2 = new ParallelCircuit(segments);

			var actual = circuit1 != circuit2;
			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals " +
							"operation ==. Null")]
		public void TestEqualsISegment_IsEqualsOperationNullTrue()
		{
			var expected = true;

			ParallelCircuit circuit1 = null;
			ParallelCircuit circuit2 = null;

			var actual = circuit1 == circuit2;

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
							"operation !=. Null")]
		public void TestEqualsISegment_IsNotEqualsOperationNullFalse()
		{
			var expected = false;

			ParallelCircuit circuit1 = null;
			ParallelCircuit circuit2 = null;

			var actual = circuit1 != circuit2;

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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
			var circuit1 = new ParallelCircuit(segments);
			object circuit2 = new ParallelCircuit(segments);

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}


		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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
			var circuit1 = new ParallelCircuit(segments);
			object circuit2 = null;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}


		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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
			var circuit1 = new ParallelCircuit(segments);
			int circuit2 = 12;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}


		[Test(Description = "Test of the ParallelCircuit Equals ISegment equals" +
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
			var circuit1 = new ParallelCircuit(segments);
			object circuit2 = circuit1;

			var actual = circuit1.Equals(circuit2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}


		[Test(Description = "Positive test of the ParallelCircuit ToString method")]
		public void TestParallelCircuit_ToString()
		{
			string expected = "Parallel";

			ParallelCircuit serialCircuit = new ParallelCircuit(new SegmentObservableCollection());

			string actual = serialCircuit.ToString();

			Assert.AreEqual(expected, actual,
				"Incorrect conversion to string in ToString method");
		}
	}
}
