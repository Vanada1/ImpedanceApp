using System.Collections.Generic;
using System.Numerics;

namespace Impedance
{
	/// <summary>
	///     Class <see cref="Project" /> contain all data of program
	/// </summary>
	public class Project
	{
		/// <summary>
		///     <see cref="Project" /> constructor
		/// </summary>
		public Project()
		{
			var segment =
				new SegmentObservableCollection
				{
					new SerialCircuit(new SegmentObservableCollection
					{
						new Inductor("jng5", 56.0),
						new Resistor("fr4tt", 32.6),
						new ParallelCircuit(new SegmentObservableCollection()
						{
							new Capacitor("th", 24.6),
							new SerialCircuit(new SegmentObservableCollection()
							{
								new Resistor("g55", 43.6),
								new Resistor("shf7", 21),
							})
						})
					}),
					new ParallelCircuit(new SegmentObservableCollection
					{
						new Resistor("g56", 7.8),
						new Capacitor("duj", 22.6)
					}),
				};
			AllExamples.Add(new Circuit("First example", segment));

			segment = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
					{
						new SerialCircuit(new SegmentObservableCollection
							{
								new Resistor("R1", 20.0),
								new Resistor("R2", 20.0)
							}
						),
						new Resistor("R7", 40.0),

						new SerialCircuit(new SegmentObservableCollection
							{
								new ParallelCircuit(new SegmentObservableCollection
									{
										new Resistor("R3", 20.0),
										new Resistor("R4", 20.0)
									}),

								new ParallelCircuit(new SegmentObservableCollection
									{
										new Resistor("R5", 20.0),
										new Resistor("R6", 20.0)
									})
							})
					}),
				new Inductor("L", 10)
			};
			AllExamples.Add(new Circuit("Second example", segment));

			segment = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("bb7", 11.3),
					new Resistor("ji9", 81.0),
					new Capacitor("trg", 43.2),
					new SerialCircuit(new SegmentObservableCollection()
					{
						new Resistor("asf", 54),
						new Resistor("efe3", 32.8),
					})
				}),
				new ParallelCircuit(new SegmentObservableCollection
				{
					new Inductor("dfg4", 55.8),
					new Inductor("gg6", 89.3),
				}),
				new SerialCircuit(new SegmentObservableCollection
				{
					new Capacitor("j55t", 32.5),
					new Resistor("sct", 4.6)
				})
			};
			AllExamples.Add(new Circuit("Third example", segment));

			segment = new SegmentObservableCollection
			{
				new ParallelCircuit(new SegmentObservableCollection
				{
					new SerialCircuit(new SegmentObservableCollection
					{
						new Resistor("dht5", 32.9),
						new Resistor("ret3", 33.7),
					}),
					new SerialCircuit(new SegmentObservableCollection
					{
						new Inductor("fhj7", 43.9),
						new Capacitor("lop8", 11.2),
						new Resistor("rte3", 66.9),
					}),
					new Inductor("ff5", 7.8)
				}),
				new SerialCircuit(new SegmentObservableCollection
				{
					new Inductor("nh78", 57.8),
					new Capacitor("d45t", 90.4),
					new Capacitor("rgr", 41.2),
					new Capacitor("rdg5", 77.3),
				}),
			};
			AllExamples.Add(new Circuit("Fourth example", segment));

			segment = new SegmentObservableCollection
			{
				new SerialCircuit(new SegmentObservableCollection
				{
					new Resistor("h6j7", 32.5),
					new Resistor("s23", 4.6),
					new Resistor("rtr4", 54.8)
				}),
				new ParallelCircuit(new SegmentObservableCollection
				{
					new SerialCircuit(new SegmentObservableCollection
					{
						new Resistor("g5h6", 44.7),
						new Capacitor("a23", 1.9),
						new Capacitor("ty6k", 87.0)
					}),
					new SerialCircuit(new SegmentObservableCollection
					{
						new Resistor("f67", 55.2),
						new Capacitor("h89", 77.3),
					}),
					new Inductor("bb7", 11.3),
					new Inductor("d4t", 88.9),
				}),
			};
			AllExamples.Add(new Circuit("Fifth example", segment));


			AllExamples.Add(new Circuit("My example",
				new SegmentObservableCollection()));

			Frequencies = new List<double>
			{
				1000.0, 500.0, 300.0
			};
		}

		/// <summary>
		///     Set and return all <see cref="Frequencies" /> in the <see cref="Project" />
		/// </summary>
		public List<double> Frequencies { get; set; } =
			new List<double>();

		/// <summary>
		///     Set and return all <see cref="Results" /> in the <see cref="Project" />
		/// </summary>
		public List<Complex> Results { get; set; }
			= new List<Complex>();

		/// <summary>
		///     Set and return all examples in the <see cref="Project" />
		/// </summary>
		public List<Circuit> AllExamples { get; set; }
			= new List<Circuit>();

		/// <summary>
		///     Set and return current selected <see cref="Circuit" />
		/// </summary>
		public Circuit CurrentCircuit { get; set; } = new Circuit();

		/// <summary>
		///     Set and return all <see cref="ResultsString" /> results in some form
		/// </summary>
		public List<string> ResultsString { get; set; }
			= new List<string>();

		/// <summary>
		///     Set and return all <see cref="CircuitElements" /> selected <see cref="Circuit" />
		/// </summary>
		public List<Element> CircuitElements { get; set; } = new List<Element>();
		
		/// <summary>
		///     Recursively Find all <see cref="Element" /> in the <see cref="ISegment.SubSegments" />
		/// </summary>
		/// <param name="segment"> of the <see cref="Circuit" /></param>
		public void FindAllElements(ISegment segment)
		{
			if (segment != null && segment == CurrentCircuit) CircuitElements = new List<Element>();

			foreach (var element in segment.SubSegments)
				if (element is Element tempElement)
					CircuitElements.Add(tempElement);
				else
					FindAllElements(element);
		}
	}
}