using System;
using NUnit.Framework;
using ImpedanceApp;
using System.Numerics;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace ImpedanceUnitTest
{
	[TestFixture]
	class ProjectTest
	{
		private SegmentObservableCollection CreateCircuit()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			return segment;
		}

		[Test(Description = "Test Frequencies constructor")]
		public void TestProjectConstructor_CorrectValue()
		{
			Assert.DoesNotThrow(
				() => { Project inductor = new Project(); },
				"Constructor test not passed");
		}

		[Test(Description = "Positive test of the Frequencies getter")]
		public void TestFrequenciesGet_CorrectValue()
		{
			List<double> expected = new List<double>();

			Project project = new Project();
			project.Frequencies = expected;

			List<double> actual = project.Frequencies;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the Frequencies setter")]
		public void TestFrequenciesSet_CorrectValue()
		{
			List<double> frequencies = new List<double>();
			string message = "Positive test of the Name setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.Frequencies = frequencies; },
				message);
		}

		[Test(Description = "Positive test of the Results getter")]
		public void TestResultsGet_CorrectValue()
		{
			List<Complex> expected = new List<Complex>();

			Project project = new Project();
			project.Results = expected;

			List<Complex> actual = project.Results;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the Results setter")]
		public void TestResultsSet_CorrectValue()
		{
			List<Complex> results = new List<Complex>();
			string message = "Positive test of the Name setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.Results = results; },
				message);
		}

		[Test(Description = "Positive test of the AllExamples getter")]
		public void TestAllExamplesGet_CorrectValue()
		{
			List<Circuit> expected = new List<Circuit>();

			Project project = new Project();
			project.AllExamples = expected;

			List<Circuit> actual = project.AllExamples;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the AllExamples setter")]
		public void TestAllExamplesSet_CorrectValue()
		{
			List<Circuit> circuits = new List<Circuit>();
			string message = "Positive test of the Name setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.AllExamples = circuits; },
				message);
		}

		[Test(Description = "Positive test of the ResultsString getter")]
		public void TestResultsStringGet_CorrectValue()
		{
			List<string> expected = new List<string>();

			Project project = new Project();
			project.ResultsString = expected;

			List<string> actual = project.ResultsString;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the ResultsString setter")]
		public void TestResultsStringSet_CorrectValue()
		{
			List<string> resultsString = new List<string>();
			string message = "Positive test of the Name setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.ResultsString = resultsString; },
				message);
		}

		[Test(Description = "Positive test of the CircuitElements getter")]
		public void TestCircuitElementsGet_CorrectValue()
		{
			List<IElement> expected = new List<IElement>();

			Project project = new Project();
			project.CircuitElements = expected;

			List<IElement> actual = project.CircuitElements;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the CircuitElements setter")]
		public void TestCircuitElementsSet_CorrectValue()
		{
			List<IElement> segments = new List<IElement>();
			string message = "Positive test of the Name setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.CircuitElements = segments; },
				message);
		}
		[Test(Description = "Positive test of the CurrentCircuit getter")]
		public void TestCurrentCircuitGet_CorrectValue()
		{
			Circuit expected = new Circuit();

			Project project = new Project();
			project.CurrentCircuit = expected;

			Circuit actual = project.CurrentCircuit;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the CurrentCircuit setter")]
		public void TestCurrentCircuitSet_CorrectValue()
		{
			Circuit circuit = new Circuit();
			string message = "Positive test of the Name setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.CurrentCircuit = circuit; },
				message);
		}

		[Test(Description = "Test FindAllElements")]
		public void TestFindAllElements()
		{
			List<IElement> expected = new List<IElement>()
			{
				new Resistor("R", 5.0),
				new Inductor("L1", 0.05),
				new Capacitor("C1", 0.01)
			};

			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", CreateCircuit());
			project.FindAllElements(project.CurrentCircuit);
			List<IElement> actual = project.CircuitElements;

			for (int i = 0; i < project.CircuitElements.Count; i++)
			{
				Assert.AreEqual(expected[i].Name, actual[i].Name,
					"FindAllElements method found wrong elements");
			}
		}

		[Test(Description = "Test FindAllElements start not from the beginning")]
		public void TestFindAllElements_NotBeginning()
		{
			List<IElement> expected = new List<IElement>()
			{
				new Resistor("R", 5.0),
				new Inductor("L1", 0.05)
			};

			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", CreateCircuit());
			project.FindAllElements(project.CurrentCircuit.SubSegments[0]);
			List<IElement> actual = project.CircuitElements;

			for (int i = 0; i < project.CircuitElements.Count; i++)
			{
				Assert.AreEqual(expected[i].Name, actual[i].Name,
					"FindAllElements method found wrong elements");
			}
		}

		[Test(Description = "Positive test of the NameSegments getter")]
		public void TestNameSegmentsGet_CorrectValue()
		{
			List<string> expected = new List<string>();

			Project project = new Project();
			project.NameSegments = expected;

			List<string> actual = project.NameSegments;

			Assert.AreEqual(expected, actual,
				"Getter Name returns incorrect value");
		}

		[Test(Description = "Positive test of the NameSegments setter")]
		public void TestNameSegmentsSet_CorrectValue()
		{
			List<string> nameSegments = new List<string>();
			string message = "Positive test of the Name setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.NameSegments = nameSegments; },
				message);
		}

		[Test(Description = "Test of the FindSegment method without inital segment")]
		public void TestFindSegment_WithoutInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", segment);

			ISegment expected = project.CurrentCircuit.SubSegments[0].SubSegments[1];

			ISegment actual = project.FindSegment("L1");

			Assert.AreEqual(expected, actual,
				"Finds the item incorrectly");
		}

		[Test(Description = "Test of the FindSegment method with inital segment")]
		public void TestFindSegment_WithInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", segment);

			ISegment expected = project.CurrentCircuit.SubSegments[0].SubSegments[1];

			ISegment actual = project.FindSegment("L1", project.CurrentCircuit.SubSegments[0]);

			Assert.AreEqual(expected, actual,
				"Finds the item incorrectly");
		}

		[Test(Description = "Test of the CreateNameSegments method without inital segment")]
		public void TestCreateNameSegments_WithoutInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", segment);

			List<string> expected = new List<string>
			{
				"Test", "Test","R", "L1", "C1"
			};

			project.CreateNameSegments(project.CurrentCircuit);
			List<string> actual = project.NameSegments;

			Assert.AreEqual(expected, actual,
				"Finds the item incorrectly");
		}

		[Test(Description = "Test of the CreateNameSegments method with inital segment")]
		public void TestCreateNameSegments_WithInitalSegment()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit("Test", new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
			};
			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", segment);

			List<string> expected = new List<string>
			{
				"Test", "R", "L1"
			};

			project.CreateNameSegments(project.CurrentCircuit.SubSegments[0]);
			List<string> actual = project.NameSegments;

			Assert.AreEqual(expected, actual,
				"Finds the item incorrectly");
		}
	}
}
