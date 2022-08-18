using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Impedance;
using Impedance.Elements;
using Impedance.Managers;
using Impedance.Segments;

namespace ImpedanceUnitTest.Validators
{
	[TestFixture]
	class CircuitValidatorTest
	{
		[Test(Description = "Positive test of the CreateNewSegment method where SegmentType is Capacitor")]
		public void TestCreateNewSegment_SegmentTypeIsCapacitor()
		{
			var expected = new Capacitor("Test", 3);

			var actual = CircuitManager.CreateNewSegment(SegmentType.Capacitor, "Test",
				3, new SegmentObservableCollection());

			Assert.AreEqual(expected, actual,
				"CreateNewSegment method incorrectly creates Segment");
		}

		[Test(Description = "Positive test of the CreateNewSegment method where SegmentType is Inductor")]
		public void TestCreateNewSegment_SegmentTypeIsInductor()
		{
			var expected = new Inductor("Test", 3);

			var actual = CircuitManager.CreateNewSegment(SegmentType.Inductor, "Test",
				3, new SegmentObservableCollection());

			Assert.AreEqual(expected, actual,
				"CreateNewSegment method incorrectly creates Segment");
		}

		[Test(Description = "Positive test of the CreateNewSegment method where SegmentType is Resistor")]
		public void TestCreateNewSegment_SegmentTypeIsResistor()
		{
			var expected = new Resistor("Test", 3);

			var actual = CircuitManager.CreateNewSegment(SegmentType.Resistor, "Test",
				3, new SegmentObservableCollection());

			Assert.AreEqual(expected, actual,
				"CreateNewSegment method incorrectly creates Segment");
		}

		[Test(Description = "Positive test of the CreateNewSegment method where SegmentType is ParallelCircuit")]
		public void TestCreateNewSegment_SegmentTypeIsParallelCircuit()
		{
			var expected = new ParallelCircuit(new SegmentObservableCollection
			{
				new Capacitor("Test", 3)
			});

			var actual = CircuitManager.CreateNewSegment(SegmentType.ParallelCircuit, "Test",
				3, new SegmentObservableCollection
				{
					new Capacitor("Test", 3)
				});

			Assert.AreEqual(expected, actual,
				"CreateNewSegment method incorrectly creates Segment");
		}

		[Test(Description = "Positive test of the CreateNewSegment method where SegmentType is SerialCircuit")]
		public void TestCreateNewSegment_SegmentTypeIsSerialCircuit()
		{
			var expected = new SerialCircuit(new SegmentObservableCollection
			{
				new Capacitor("Test", 3)
			});

			var actual = CircuitManager.CreateNewSegment(SegmentType.SerialCircuit, "Test",
				3, new SegmentObservableCollection
				{
					new Capacitor("Test", 3)
				});

			Assert.AreEqual(expected, actual,
				"CreateNewSegment method incorrectly creates Segment");
		}

		[Test(Description = "Positive test of the CreateNewSegment method where SegmentType is ParallelCircuit" +
			           "where collection is null")]
		public void TestCreateNewSegment_SegmentTypeIsParallelCircuitWithNullCollection()
		{
			var expected = new ParallelCircuit(new SegmentObservableCollection());

			var actual = CircuitManager.CreateNewSegment(SegmentType.ParallelCircuit, "Test",
				3, null);

			Assert.AreEqual(expected, actual,
				"CreateNewSegment method incorrectly creates Segment");
		}

		[Test(Description = "Positive test of the CreateNewSegment method where SegmentType is SerialCircuit" +
			           "where collection is null")]
		public void TestCreateNewSegment_SegmentTypeIsSerialCircuitWithNullCollection()
		{
			var expected = new SerialCircuit(new SegmentObservableCollection());

			var actual = CircuitManager.CreateNewSegment(SegmentType.SerialCircuit, "Test",
				3, null);

			Assert.AreEqual(expected, actual,
				"CreateNewSegment method incorrectly creates Segment");
		}
	}
}
