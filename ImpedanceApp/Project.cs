using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceApp
{
   public class Project
    {
		/// <summary>
		/// List of the frequencies
		/// </summary>
		public List<double> Frequencies = new List<double>();

		/// <summary>
		/// List of the results
		/// </summary>
		public List<Complex> Results = new List<Complex>();

		/// <summary>
		/// List of the all example with circuit
		/// </summary>
		public List<Circuit> AllExample = new List<Circuit>();

		/// <summary>
		/// Current circuit
		/// </summary>
		public Circuit Circuit = new Circuit();

		/// <summary>
		/// Result string
		/// </summary>
		public List<string> ResultString = new List<string>();

		/// <summary>
		/// Constructor project
		/// </summary>
		public Project()
        {
			ElementObservableCollection<IElement> elements =
	new ElementObservableCollection<IElement>
	{
					new Resistor("R", 100),
					new Inductor("L", 10),
					new Capacitor("C", 0.002)
	};
			AllExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement>
			{
				new Resistor("R1", 40.0),
				new Resistor("R2", 40.0),
				new Inductor("L", 10)
			};
			AllExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement>
			{
				new Resistor("R", 40.0),
				new Capacitor("C1", 0.002),
				new Capacitor("C2", 0.002)
			};
			AllExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement>
			{
				new Resistor("R1", 40.0),
				new Resistor("R2", 40.0),
				new Capacitor("C", 0.002)
			};
			AllExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement>
			{
				new Resistor("R", 40.0),
				new Inductor("L1", 10),
				new Inductor("L2", 10)
			};
			AllExample.Add(new Circuit(elements));


			AllExample.Add(new Circuit());
		}
	}
}
