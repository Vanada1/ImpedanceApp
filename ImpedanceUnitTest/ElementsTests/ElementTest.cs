using System;
using NUnit.Framework;
using ImpedanceApp;

namespace ImpedanceUnitTest
{
	[TestFixture]
	public class ElementTest
	{
		private Element CreateElement()
		{
			return new Resistor("Test", 1.0);
		}

		[Test(Description = "Positive test of the Name getter")]
		public void TestNameGet_CorrectValue()
		{
			string expected = "C";

			Element element = CreateElement();
			element.Name = expected;

			string actual = element.Name;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Assignment of the Name is not empty")]
		public void TestNameSet_ArgumentException()
		{
			string wrongName = "";
			string message = "If the name is empty, an exception should be thrown.";
			Element element = CreateElement();
			Assert.Throws<ArgumentException>(
				() => { element.Name = wrongName; },
				message);
		}

		[Test(Description = "Positive test of the Name setter")]
		public void TestNameSet_CorrectValue()
		{
			string name = "Test";
			string message = "Positive test of the Name setter not passed";
			Element element = CreateElement();
			Assert.DoesNotThrow(
				() => { element.Name = name; },
				message);
		}

		[Test(Description = "Positive test of the Value getter")]
		public void TestValueGet_CorrectValue()
		{
			double expected = 30.0;

			Element element = CreateElement();
			element.Value = expected;

			double actual = element.Value;

			Assert.AreEqual(expected, actual,
				"Getter Value returns incorrect value");
		}

		[Test(Description = "Assignment of the Value is not negative")]
		public void TestValueSet_ArgumentException()
		{
			double wrongValue = -1.0;
			string message = "If the value is negative, an exception should be thrown.";
			Element element = CreateElement();
			Assert.Throws<ArgumentException>(
				() => { element.Value = wrongValue; },
				message);
		}

		[Test(Description = "Positive test of the Value setter")]
		public void TestValueSet_CorrectValue()
		{
			double value = 30.0;
			string message = "Positive test of the Value setter not passed";
			Element element = CreateElement();
			Assert.DoesNotThrow(
				() => { element.Value = value; },
				message);
		}

		[Test(Description = "Test event SegmentChanged")]
		public void TestValueSet_SegmentChangedEvent()
		{
			bool wasCalled = false;
			Element element = CreateElement();
			element.SegmentChanged += (o, e) => wasCalled = true;
			double value = 30.0;
			element.Value = value;
			Assert.IsTrue(wasCalled);
		}

		[Test(Description = "Test SubSegment property on null")]
		public void TestSubSegmentsGet_Null()
		{
			Element element = CreateElement();
			SegmentObservableCollection expected = null;
			var actual = element.SubSegments;
			Assert.AreEqual(expected, actual, 
				"SubSegments getter return not null");
		}

		[Test(Description = "Test of the Resistor Clone")]
		public void TestClone()
		{
			var expected = new Resistor("Test", 1.0);

			var actual = expected.Clone() as Resistor;

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment equals")]
		public void TestEquals_IsEquals()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = true;

			var element2 = new Resistor("Test", 1.0);

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment not equals")]
		public void TestEquals_IsNotEquals()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			var element2 = new Resistor("Test1", 2.0);

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment other name")]
		public void TestEquals_OtherName()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			var element2 = new Resistor("Test1", 1.0);

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment other value")]
		public void TestEquals_OtherValue()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			var element2 = new Resistor("Test", 2.0);

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment one is null")]
		public void TestEquals_Null()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			Resistor element2 = null;

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment one is null")]
		public void TestEquals_NullISsegment()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			ISegment element2 = null;

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment the same object")]
		public void TestEquals_SameObject()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = true;

			Element element2 = element1;

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment equals " +
							"operation ==")]
		public void TestEquals_IsEqualsOperationTrue()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = true;

			var element2 = new Resistor("Test", 1.0);

			var actual = element1 == element2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment is not equals " +
							"operation ==")]
		public void TestEquals_IsEqualsOperationFalse()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			var element2 = new Resistor("Test1", 1.0);

			var actual = element1 == element2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment not equals" +
							"operation !=")]
		public void TestEquals_IsNotEqualsOperationTrue()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = true;

			var element2 = new Resistor("Test", 2.0);

			var actual = element1 != element2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment equals" +
							"operation !=")]
		public void TestEquals_IsNotEqualsOperationFalse()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			var element2 = new Resistor("Test", 1.0);

			var actual = element1 != element2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment equals " +
							"operation ==. Null")]
		public void TestEquals_IsEqualsOperationNullTrue()
		{
			Resistor element1 = null;

			var expected = true;

			Resistor element2 = null;

			var actual = element1 == element2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment equals" +
							"operation !=. Null")]
		public void TestEquals_IsNotEqualsOperationNullFalse()
		{
			Resistor element1 = null;

			var expected = false;

			Resistor element2 = null;

			var actual = element1 != element2;
			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}

		[Test(Description = "Test of the Resistor Equals ISegment equals" +
							" with object")]
		public void TestEquals_IsEqualsObject()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = true;

			object element2 = new Resistor("Test", 1.0);

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the Resistor Equals ISegment equals" +
							" with object = null")]
		public void TestEquals_IsEqualsObjectNull()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			object element2 = null;

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the Resistor Equals ISegment equals" +
							" with object different type")]
		public void TestEquals_IsEqualsObjectOtherType()
		{
			var element1 = new Resistor("Test", 1.0);

			var expected = false;

			int element2 = 12;

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}


		[Test(Description = "Test of the Resistor Equals ISegment equals" +
							" with object the same object")]
		public void TestEquals_IsEqualsObjectSame()
		{

			var element1 = new Resistor("Test", 1.0);

			var expected = true;

			object element2 = element1;

			var actual = element1.Equals(element2);

			Assert.AreEqual(expected, actual,
				"Invalid copying of elements");
		}
	}
}
