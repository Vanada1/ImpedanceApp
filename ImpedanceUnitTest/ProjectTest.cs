using Impedance;
using NUnit.Framework;
using System.Collections.Generic;
using System.Numerics;
using Impedance.Elements;
using Impedance.Segments;

namespace ImpedanceUnitTest
{
	[TestFixture]
	class ProjectTest
	{
		private SegmentObservableCollection CreateCircuit()
		{
			var segment = new SegmentObservableCollection
			{
				new ParallelCircuit( new SegmentObservableCollection
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
				"Getter Frequencies returns incorrect value");
		}

		[Test(Description = "Positive test of the Frequencies setter")]
		public void TestFrequenciesSet_CorrectValue()
		{
			List<double> frequencies = new List<double>();
			string message = "Positive test of the Frequencies setter not passed";
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
				"Getter Results returns incorrect value");
		}

		[Test(Description = "Positive test of the Results setter")]
		public void TestResultsSet_CorrectValue()
		{
			List<Complex> results = new List<Complex>();
			string message = "Positive test of the Results setter not passed";
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
				"Getter AllExamples returns incorrect value");
		}

		[Test(Description = "Positive test of the AllExamples setter")]
		public void TestAllExamplesSet_CorrectValue()
		{
			List<Circuit> circuits = new List<Circuit>();
			string message = "Positive test of the AllExamples setter not passed";
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
				"Getter ResultsString returns incorrect value");
		}

		[Test(Description = "Positive test of the ResultsString setter")]
		public void TestResultsStringSet_CorrectValue()
		{
			List<string> resultsString = new List<string>();
			string message = "Positive test of the ResultsString setter not passed";
			Project element = new Project();
			Assert.DoesNotThrow(
				() => { element.ResultsString = resultsString; },
				message);
		}

		[Test(Description = "Positive test of the CircuitElements getter")]
		public void TestCircuitElementsGet_CorrectValue()
		{
			List<Element> expected = new List<Element>();

			Project project = new Project();
			project.CircuitElements = expected;

			List<Element> actual = project.CircuitElements;

			Assert.AreEqual(expected, actual,
				"Getter CircuitElements returns incorrect value");
		}

		[Test(Description = "Positive test of the CircuitElements setter")]
		public void TestCircuitElementsSet_CorrectValue()
		{
			List<Element> segments = new List<Element>();
			string message = "Positive test of the CircuitElements setter not passed";
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
				"Getter CurrentCircuit returns incorrect value");
		}

		[Test(Description = "Positive test of the CurrentCircuit setter")]
		public void TestCurrentCircuitSet_CorrectValue()
		{
			Circuit circuit = new Circuit();
			string message = "Positive test of the CurrentCircuit setter not passed";
			Project element = new Project();

			Assert.DoesNotThrow(
				() => { element.CurrentCircuit = circuit; },
				message);
		}

		[Test(Description = "Test FindAllElements")]
		public void TestFindAllElements()
		{
			List<Element> expected = new List<Element>()
			{
				new Resistor("R", 5.0),
				new Inductor("L1", 0.05),
				new Capacitor("C1", 0.01)
			};

			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", CreateCircuit());
			project.FindAllElements(project.CurrentCircuit);

			List<Element> actual = project.CircuitElements;

			for (int i = 0; i < project.CircuitElements.Count; i++)
			{
				Assert.AreEqual(expected[i].Name, actual[i].Name,
					"FindAllElements method found wrong elements");
			}
		}

		[Test(Description = "Test FindAllElements start not from the beginning")]
		public void TestFindAllElements_NotBeginning()
		{
			List<Element> expected = new List<Element>()
			{
				new Resistor("R", 5.0),
				new Inductor("L1", 0.05)
			};

			Project project = new Project();
			project.CurrentCircuit = new Circuit("Test", CreateCircuit());
			project.FindAllElements(project.CurrentCircuit.SubSegments[0]);

			List<Element> actual = project.CircuitElements;

			for (int i = 0; i < project.CircuitElements.Count; i++)
			{
				Assert.AreEqual(expected[i].Name, actual[i].Name,
					"FindAllElements method found wrong elements");
			}
		}

	}
}
