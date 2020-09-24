using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
   public class Project
    {
		private static readonly string _name = "Main Circuit";

		/// <summary>
		/// List of the frequencies
		/// </summary>
		public List<double> Frequencies { get; set; } =
			new List<double>();

		/// <summary>
		/// List of the results
		/// </summary>
		public List<Complex> Results { get; set; }
			= new List<Complex>();

		/// <summary>
		/// List of the all example with circuit
		/// </summary>
		public List<Circuit> AllExample { get; set; }
			= new List<Circuit>();

		/// <summary>
		/// Current circuit
		/// </summary>
		public Circuit CurrentCircuit { get; set; } 
			= new SerialCircuit(_name, new SegmentObservableCollection<ISegment>());

		/// <summary>
		/// Result string
		/// </summary>
		public List<string> ResultString { get; set; } 
			= new List<string>();

		public List<IElement> CircuitElements = null;

		/// <summary>
		/// Constructor project
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
			AllExample.Add(new SerialCircuit(_name, segment));

			segment = new SegmentObservableCollection<ISegment>
			{
				new ParallelCircuit("Parallel Circuit",
					new SegmentObservableCollection<ISegment>
					{
						new Resistor("R1", 40.0),
						new Resistor("R2", 40.0)
					}),
				new Inductor("L", 10)
			};
			AllExample.Add(new SerialCircuit(_name, segment));

			segment = new SegmentObservableCollection<ISegment>
			{
				new Resistor("R", 40.0),
				new Capacitor("C1", 0.002),
				new Capacitor("C2", 0.002)
			};
			AllExample.Add(new SerialCircuit(_name, segment));

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
			AllExample.Add(new SerialCircuit(_name, segment));

			segment = new SegmentObservableCollection<ISegment>
			{
				new Resistor("R", 40.0),
				new Inductor("L1", 10),
				new Inductor("L2", 10)
			};
			AllExample.Add(new SerialCircuit(_name, segment));


			AllExample.Add(new SerialCircuit(_name, 
				new SegmentObservableCollection<ISegment>()));
		}

		public void FindAllElements(ISegment segment)
		{
			if (segment == CurrentCircuit)
			{
				CircuitElements = new List<IElement>();
			}

			foreach(var element in segment.SubSegment)
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
