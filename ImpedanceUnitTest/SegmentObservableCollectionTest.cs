﻿using Impedance;
using NUnit.Framework;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class SegmentObservableCollectionTest
	{
		[Test(Description = "Positive test InsertItem method by adding element")]
		public void TestInsertItem()
		{
			var collection = new SegmentObservableCollection();

			Assert.DoesNotThrow(
				() => collection.Add(new Capacitor("Test", 10)),
				"Add error");
		}

		[Test(Description = "Positive test RemoveItem method by removing element")]
		public void TestRemoveItem()
		{
			var capasitor = new Capacitor("Test", 10.0);
			var resistor1 = new Resistor("R1", 3.0);
			var resistor2 = new Resistor("R2", 3.0);
			var collection = new SegmentObservableCollection
			{
				resistor1, capasitor, resistor2
			};

			Assert.DoesNotThrow(() => collection.Remove(capasitor),
				"Remove error");
		}

		[Test(Description = "Positive test SetItem method by replacement element")]
		public void TestSetItem()
		{
			var capasitor = new Capacitor("Test", 10.0);
			var resistor1 = new Resistor("R1", 3.0);
			var resistor2 = new Resistor("R2", 3.0);
			var collection = new SegmentObservableCollection
			{
				resistor1, capasitor, resistor2
			};

			Assert.DoesNotThrow(() => collection[0] = capasitor,
				"Replacement error");
		}

		[Test(Description = "Positive test ClearItems method by remove all elements")]
		public void TestClearItems()
		{
			var capasitor = new Capacitor("Test", 10.0);
			var resistor1 = new Resistor("R1", 3.0);
			var resistor2 = new Resistor("R2", 3.0);
			var collection = new SegmentObservableCollection
			{
				resistor1, capasitor, resistor2
			};

			Assert.DoesNotThrow(() => collection.Clear(),
				"Clear items error");
		}

		[Test(Description = "Test of the SegmentObservableCollection Clone")]
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

			var expected = segments;

			var actual = expected.Clone() as SegmentObservableCollection;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals")]
		public void TestEquals_IsEquals()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment not equals")]
		public void TestEquals_IsNotEquals()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment other name")]
		public void TestEquals_OtherName()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment other collection")]
		public void TestEquals_OtherCollection()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment one is null")]
		public void TestEquals_Null()
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
			var SegmentObservableCollection1 = segments;
			SegmentObservableCollection SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection" +
							" Equals different values")]
		public void TestEquals_DifferentValues()
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
			var SegmentObservableCollection1 = segments;
			SegmentObservableCollection SegmentObservableCollection2 =
				new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
				{
					new Inductor("L1", 0.05)
				}),
				new Inductor("L1", 0.01)
			}; ;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment the same object")]
		public void TestEquals_SameObject()
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
			var SegmentObservableCollection1 = segments;
			SegmentObservableCollection SegmentObservableCollection2 = SegmentObservableCollection1;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals " +
							"operation ==")]
		public void TestEquals_IsEqualsOperationTrue()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1 == SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment is not equals " +
							"operation ==")]
		public void TestEquals_IsEqualsOperationFalse()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1 == SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment not equals" +
							"operation !=")]
		public void TestEquals_IsNotEqualsOperationTrue()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = new SegmentObservableCollection();

			var actual = SegmentObservableCollection1 != SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							"operation !=")]
		public void TestEquals_IsNotEqualsOperationFalse()
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
			var SegmentObservableCollection1 = segments;
			var SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1 != SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals " +
							"operation ==. Null")]
		public void TestEquals_IsEqualsOperationNullTrue()
		{
			var expected = true;

			SegmentObservableCollection SegmentObservableCollection1 = null;
			SegmentObservableCollection SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1 == SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							"operation !=. Null")]
		public void TestEquals_IsNotEqualsOperationNullFalse()
		{
			var expected = false;

			SegmentObservableCollection SegmentObservableCollection1 = null;
			SegmentObservableCollection SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1 != SegmentObservableCollection2;
			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}

		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object")]
		public void TestEquals_IsEqualsObject()
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
			var SegmentObservableCollection1 = segments;
			object SegmentObservableCollection2 = segments;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}


		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object = null")]
		public void TestEquals_IsEqualsObjectNull()
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
			var SegmentObservableCollection1 = segments;
			object SegmentObservableCollection2 = null;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}


		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object different type")]
		public void TestEquals_IsEqualsObjectOtherType()
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
			var SegmentObservableCollection1 = segments;
			int SegmentObservableCollection2 = 12;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are equal");
		}


		[Test(Description = "Test of the SegmentObservableCollection Equals ISegment equals" +
							" with object the same object")]
		public void TestEquals_IsEqualsObjectSame()
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
			var SegmentObservableCollection1 = segments;
			object SegmentObservableCollection2 = SegmentObservableCollection1;

			var actual = SegmentObservableCollection1.Equals(SegmentObservableCollection2);

			Assert.AreEqual(expected, actual,
				"Elements are not equal");
		}
	}
}
