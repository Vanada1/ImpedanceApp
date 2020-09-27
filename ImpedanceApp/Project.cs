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
		/// List of the <see cref="Frequencies"/> property
		/// </summary>
		public List<double> Frequencies { get; set; } =
			new List<double>();

		/// <summary>
		/// List of the <see cref="Results"/> property
		/// </summary>
		public List<Complex> Results { get; set; }
			= new List<Complex>();

		/// <summary>
		/// List of the all example with circuit
		/// </summary>
		public List<Circuit> AllExample { get; set; }
			= new List<Circuit>();

		/// <summary>
		/// Current circuit property
		/// </summary>
		public Circuit CurrentCircuit { get; set; } = new Circuit();

		/// <summary>
		/// Result string property 
		/// </summary>
		public List<string> ResultString { get; set; } 
			= new List<string>();

		/// <summary>
		/// Property all <see cref="IElement"/> of the <see cref="Circuit"/>
		/// </summary>
		public SegmentObservableCollection<IElement> CircuitElements { get; set; } = null;

		/// <summary>
		/// Constructor <see cref="Project"/>
		/// </summary>
		public Project()
		{
			SegmentObservableCollection<ISegment> segment =
			new SegmentObservableCollection<ISegment>
			{
				new Resistor("R", 100),
				new ParallelCircuit("Parallel Circuit",
					new SegmentObservableCollection<ISegment>
					{
						new Capacitor("C", 0.002),
						new Inductor("L", 10)
					})
			};
			AllExample.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection<ISegment>
			{
				new ParallelCircuit("Parallel Circuit",
					new SegmentObservableCollection<ISegment>
					{
						new SerialCircuit("Test",
						new SegmentObservableCollection<ISegment>
						{
							new Resistor("R1", 20.0),
							new Resistor("R2", 20.0)
						}
						),
						new Resistor("R3", 40.0)
					}),
				new Inductor("L", 10)
			};
			AllExample.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection<ISegment>
			{
				new Resistor("R", 40.0),
				new Capacitor("C1", 0.002),
				new Capacitor("C2", 0.002)
			};
			AllExample.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection<ISegment>
			{
				new Resistor("R1", 40.0),
				new ParallelCircuit("Parallel Circuit",
					new SegmentObservableCollection<ISegment>
					{
						new Resistor("R2", 40.0),
						new Capacitor("C", 0.002) 
					})
			};
			AllExample.Add(new Circuit(_name, segment));

			segment = new SegmentObservableCollection<ISegment>
			{
				new Resistor("R", 40.0),
				new Inductor("L1", 10),
				new Inductor("L2", 10)
			};
			AllExample.Add(new Circuit(_name, segment));


			AllExample.Add(new Circuit(_name, 
				new SegmentObservableCollection<ISegment>()));
		}

		/// <summary>
		/// Find all <see cref="IElement"/> in the <see cref="ISegment.SubSegments"/>
		/// </summary>
		/// <param name="segment"> of the <see cref="Circuit"/></param>
		public void FindAllElements(ISegment segment)
		{
			if (segment == CurrentCircuit)
			{
				CircuitElements = new SegmentObservableCollection<IElement>();
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
