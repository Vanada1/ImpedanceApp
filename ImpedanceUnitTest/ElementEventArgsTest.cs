using System;
using NUnit.Framework;
using ImpedanceApp;


namespace ImpedanceUnitTest
{
	/// <summary>
	/// Summary description for ElementEventArgs
	/// </summary>
	[TestFixture]
	public class ElementEventArgsTest
	{
		private ElementEventArgs CreateElementEventArgs()
		{
			return new ElementEventArgs("message");
		}

		[Test(Description = "Positive test of the Message getter")]
		public void TestMessageGet_CorrectValue()
		{
			string expected = "message";

			ElementEventArgs element = CreateElementEventArgs();

			string actual = element.Message;

			Assert.AreEqual(expected, actual,
				"Getter Message returns incorrect value");
		}
	}
}
