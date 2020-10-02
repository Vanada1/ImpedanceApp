using System.Collections.Generic;
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
		public List<IElement> CircuitElements { get; set; } = new List<IElement>();

		/// <summary>
		/// Set and return all segments name
		/// </summary>
		public List<string> NameSegments { get; set; } = new List<string>();

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
			AllExamples.Add(new Circuit("First example", segment));

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
						new Resistor("R7", 40.0),

						new SerialCircuit("Test",
							new SegmentObservableCollection
							{
								new ParallelCircuit("Parallel Circuit",
									new SegmentObservableCollection
									{
										new Resistor("R3", 20.0), 
										new Resistor("R4", 20.0)
									}),

								new ParallelCircuit("Parallel Circuit", 
									new SegmentObservableCollection
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
				new Resistor("R", 40.0),
				new Capacitor("C1", 0.002),
				new Capacitor("C2", 0.002)
			};
			AllExamples.Add(new Circuit("Third example", segment));

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
			AllExamples.Add(new Circuit("Fourth example", segment));

			segment = new SegmentObservableCollection
			{
				new ParallelCircuit(_name, new SegmentObservableCollection
				{
					new Resistor("R", 5.0),
					new Inductor("L1", 0.05)
				}),
				new Capacitor("C1", 0.01)
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
		/// Recursively Find all <see cref="IElement"/> in the <see cref="ISegment.SubSegments"/>
		/// </summary>
		/// <param name="segment"> of the <see cref="Circuit"/></param>
		public void FindAllElements(ISegment segment)
		{
			if (segment == CurrentCircuit)
			{
				CircuitElements = new List<IElement>();
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

		/// <summary>
		/// Recursively find a segment by name
		/// </summary>
		/// <param name="name"> is segment name</param>
		/// <param name="segment">  segment in which the search takes place.
		/// If <see cref="segment"/> is null, then <see cref="CurrentCircuit"/> is taken</param>
		/// <returns>The <see cref="ISegment"/> element .Null if no element is found by name</returns>
		public ISegment FindSegment(string name, ISegment segment = null)
		{
			ISegment result = null;
			if (segment == null)
			{
				segment = CurrentCircuit;
			}

			if (segment.Name == name)
			{
				return segment;
			}

			foreach (var subSegment in segment.SubSegments)
			{
				if(result != null) break;

				if (subSegment.Name == name)
				{
					return subSegment;
				}

				if (!(subSegment is IElement))
				{
					result = FindSegment(name, subSegment);
				}
			}

			return result;
		}

		/// <summary>
		/// Recursively creates a list of the names of all the <see cref="ISegment"/> in the circuit
		/// </summary>
		/// <param name="segment">the <see cref="ISegment"/> in which the items are written to the list</param>
		public void CreateNameSegments(ISegment segment)
		{
			if (segment == CurrentCircuit)
			{
				NameSegments = new List<string>();
			}

			NameSegments.Add(segment.Name);

			foreach (var subSegment in segment.SubSegments)
			{
				if (subSegment is IElement)
				{
					NameSegments.Add(subSegment.Name);
				}
				else
				{
					CreateNameSegments(subSegment);
				}
			}
		}
	}
}
