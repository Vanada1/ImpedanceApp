using System;
using NUnit.Framework;
using ImpedanceApp;
using System.Numerics;
using System.Collections.Generic;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class SegmentObservableCollectionTest
	{
		[Test(Description = "Test of the SegmentObservableCollection Clone")]
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

			var expected = segments;

			var actual = expected.Clone() as SegmentObservableCollection;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals")]
		public void TestEquals_IsEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = true;

			var SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment not equals")]
		public void TestEquals_IsNotEquals()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment other name")]
		public void TestEquals_OtherName()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment other collection")]
		public void TestEquals_OtherCollection()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment one is null")]
		public void TestEquals_Null()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			SegmentObservableCollection SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection" +
		                    " Equals different values")]
		public void TestEquals_DifferentValues()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			SegmentObservableCollection SegmentObservableCollection2 = 
				new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Inductor("L1", 0.01)
			}; ;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment the same object")]
		public void TestEquals_SameObject()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = true;

			SegmentObservableCollection SegmentObservableCollection2 = SegmentObservableCollection1;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals " +
							"operation ==")]
		public void TestEquals_IsEqualsOperationTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = true;

			var SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1 == SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment is not equals " +
							"operation ==")]
		public void TestEquals_IsEqualsOperationFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1 == SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment not equals" +
							"operation !=")]
		public void TestEquals_IsNotEqualsOperationTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = true;

			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1 != SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							"operation !=")]
		public void TestEquals_IsNotEqualsOperationFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			var SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1 != SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals " +
							"operation ==. Null")]
		public void TestEquals_IsEqualsOperationNullTrue()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			SegmentObservableCollection SegmentObservableCollection1 = null;

			var expected = true;

			SegmentObservableCollection SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1 == SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							"operation !=. Null")]
		public void TestEquals_IsNotEqualsOperationNullFalse()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			SegmentObservableCollection SegmentObservableCollection1 = null;

			var expected = false;

			SegmentObservableCollection SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1 != SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object")]
		public void TestEquals_IsEqualsObject()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = true;

			object SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object = null")]
		public void TestEquals_IsEqualsObjectNull()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			object SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object different type")]
		public void TestEquals_IsEqualsObjectOtherType()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = false;

			int SegmentObservableCollection2 = 12;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object the same object")]
		public void TestEquals_IsEqualsObjectSame()
		{
			var segments = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};

			var SegmentObservableCollection1 = segments;

			var expected = true;

			object SegmentObservableCollection2 = SegmentObservableCollection1;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}
	}
}
