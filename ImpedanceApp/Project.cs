﻿using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
	/// <summary>
	/// Class <see cref="Project"/> contain all data of program
	/// </summary>
	public class Project
	{
		/// <summary>
		/// <see cref="_name"/> for all <see cref="Circuit"/>
		/// </summary>
		private static readonly string _name = "Main Circuit";

		/// <summary>
		/// Set and return all <see cref="Frequencies"/> in the <see cref="Project"/>
		/// </summary>
		public List<double> Frequencies { get; set; } =
			new List<double>();

		/// <summary>
		/// Set and return all <see cref="Results"/> in the <see cref="Project"/>
		/// </summary>
		public List<Complex> Results { get; set; }
			= new List<Complex>();

		/// <summary>
		/// Set and return all examples in the <see cref="Project"/>
		/// </summary>
		public List<Circuit> AllExamples { get; set; }
			= new List<Circuit>();

		/// <summary>
		/// Set and return current selected <see cref="Circuit"/>
		/// </summary>
		public Circuit CurrentCircuit { get; set; } = new Circuit();

		/// <summary>
		/// Set and return all <see cref="ResultsString"/> results in some form
		/// </summary>
		public List<string> ResultsString { get; set; } 
			= new List<string>();

		/// <summary>
		/// Set and return all <see cref="CircuitElements"/> selected <see cref="Circuit"/>
		/// </summary>
		public SegmentObservableCollection CircuitElements { get; set; } = null;

		/// <summary>
		/// <see cref="Project"/> constructor 
		/// </summary>
		public Project()
		{
			SegmentObservableCollection segment =
			new SegmentObservableCollection
			{
				new Resistor("R", 100),
				new ParallelCircuit("Parallel Circuit",
					new SegmentObservableCollection
					{
						new Capacitor("C", 0.002),
						new Inductor("L", 10)
					})
			};
			AllExamples.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection
			{
				new ParallelCircuit("Parallel Circuit",
					new SegmentObservableCollection
					{
						new SerialCircuit("Test",
						new SegmentObservableCollection
						{
							new Resistor("R1", 20.0),
							new Resistor("R2", 20.0)
						}
						),
						new Resistor("R3", 40.0)
					}),
				new Inductor("L", 10)
			};
			AllExamples.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection
			{
				new Resistor("R", 40.0),
				new Capacitor("C1", 0.002),
				new Capacitor("C2", 0.002)
			};
			AllExamples.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection
			{
				new Resistor("R1", 40.0),
				new ParallelCircuit("Parallel Circuit",
					new SegmentObservableCollection
					{
						new Resistor("R2", 40.0),
						new Capacitor("C", 0.002) 
					})
			};
			AllExamples.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection
			{
				new Resistor("R", 40.0),
				new Inductor("L1", 10),
				new Inductor("L2", 10)
			};
			AllExamples.Add(new Circuit(_name, segment));


			AllExamples.Add(new Circuit(_name, 
				new SegmentObservableCollection()));
		}

		/// <summary>
		/// Find all <see cref="IElement"/> in the <see cref="ISegment.SubSegments"/>
		/// </summary>
		/// <param name="segment"> of the <see cref="Circuit"/></param>
		public void FindAllElements(ISegment segment)
		{
			if (segment == CurrentCircuit)
			{
				CircuitElements = new SegmentObservableCollection();
			}

			foreach(var element in segment.SubSegments)
			{
				if(element is IElement tempElement)
				{
					CircuitElements.Add(tempElement);
				}
				else
				{
					FindAllElements(element);
				}
			}
		}
	}
}
