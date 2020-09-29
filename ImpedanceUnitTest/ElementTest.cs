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

		[Test(Description = "Positive test of the Name getter")]
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
	}
}
