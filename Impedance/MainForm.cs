using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Numerics;
using ImpedanceApp;
using Impedance;
using Microsoft.VisualBasic.CompilerServices;
using System.Reflection;

namespace ImpedanceForms
{
	public partial class MainForm : Form
	{
		private List<double> _frequencies = new List<double>();
		private List<Complex> _results = new List<Complex>();
		private List<Circuit> _allExample = new List<Circuit>();

		private Circuit _circuit = new Circuit();
		List<string> resultString = new List<string>();


		private static void CircuitCollectionChanged(
			object sender, object e)
		{
			MessageBox.Show("Circuit was changed", "Alert",
				MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void UpdateListBoxes()
		{
			FrequenciesListBox.DataSource = null;
			FrequenciesListBox.DataSource = _frequencies;

			_results = _circuit.CalculateZ(_frequencies);
			ImpedanceListBox.DataSource = null;
			resultString = new List<string>();
			foreach (var result in _results)
			{
				resultString.Add($"{result.Real} + {result.Imaginary}i");
			}
			ImpedanceListBox.DataSource = resultString;
			ImpedanceListBox.ClearSelected();

			ElementsListBox.DataSource = null;
			ElementsListBox.DataSource = _circuit.Elements;
		}


		public MainForm()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			UpdateListBoxes();

			ElementObservableCollection<IElement> elements =
				new ElementObservableCollection<IElement>
				{
					new Resistor("R", 100),
					new Inductor("L", 10),
					new Capacitor("C", 0.002)
				};
			_allExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement>
			{
				new Resistor("R1", 40.0),
				new Resistor("R2", 40.0),
				new Inductor("L", 10)
			};
			_allExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement>
			{
				new Resistor("R", 40.0),
				new Capacitor("C1", 0.002),
				new Capacitor("C2", 0.002)
			};
			_allExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement> 
			{
				new Resistor("R1", 40.0),
				new Resistor("R2", 40.0),
				new Capacitor("C", 0.002)
			};
			_allExample.Add(new Circuit(elements));

			elements = new ElementObservableCollection<IElement>
			{
				new Resistor("R", 40.0),
				new Inductor("L1", 10),
				new Inductor("L2", 10)
			};
			_allExample.Add(new Circuit(elements));


			_allExample.Add(new Circuit());

			foreach(var example in _allExample)
			{
				example.Elements.CircuitChanged += CircuitCollectionChanged;
			}
			
		}

		private void AddFrequenciesButton_Click(object sender, EventArgs e)
		{
			var addFrorm = new AddEditFrequenciesForm();
			addFrorm.ShowDialog();
			if(addFrorm.DialogResult == DialogResult.OK)
			{
				_frequencies.Add((double)addFrorm.Frequencie);
			}
			UpdateListBoxes();
		}

		private void EditFrequenciesButton_Click(object sender, EventArgs e)
		{
			var index = FrequenciesListBox.SelectedIndex;
			var editFrorm = new AddEditFrequenciesForm();
			if(index >=0)
			{
				editFrorm.Frequencie = _frequencies[index];
				editFrorm.ShowDialog();
				if(editFrorm.DialogResult == DialogResult.OK)
				{
					_frequencies[index] = (double)editFrorm.Frequencie;
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
		}

		private void RemoveFrequenciesButton_Click(object sender, EventArgs e)
		{
			var index = FrequenciesListBox.SelectedIndex;
			if (index >= 0)
			{
				var remove = MessageBox.Show("Remove?", "Remove?",
					MessageBoxButtons.YesNo);
				if (remove == DialogResult.Yes)
				{
					_frequencies.RemoveAt(index);
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			_circuit = _allExample[0];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FirstExample;
			UpdateListBoxes();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			_circuit = _allExample[1];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.SecondExample;
			UpdateListBoxes();
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			_circuit = _allExample[2];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.ThirdExample;
			UpdateListBoxes();
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			_circuit = _allExample[3];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FourthExample;
			UpdateListBoxes();
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			_circuit = _allExample[4];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FirstExample;
			UpdateListBoxes();
		}

		private void radioButton6_CheckedChanged(object sender, EventArgs e)
		{
			_circuit = _allExample[5];
			AddElementButton.Enabled = true;
			RemoveElementButton.Enabled = true;
			CircuitPictureBox.Image = null;
			UpdateListBoxes();
		}

		private void EditElementsButton_Click(object sender, EventArgs e)
		{
			var index = ElementsListBox.SelectedIndex;
			if (index >= 0)
			{
				var editFrorm = new AddEditElementsForm();
				editFrorm.Element = _circuit.Elements[index];
				editFrorm.ShowDialog();
				if (editFrorm.DialogResult == DialogResult.OK)
				{
					_circuit.Elements[index] = editFrorm.Element;
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddElementButton_Click(object sender, EventArgs e)
		{
			var addFrorm = new AddEditElementsForm();
			addFrorm.ShowDialog();
			if (addFrorm.DialogResult == DialogResult.OK)
			{
				_circuit.Elements.Add(addFrorm.Element);
			}
			UpdateListBoxes();
		}

		private void RemoveElementButton_Click(object sender, EventArgs e)
		{
			var index = ElementsListBox.SelectedIndex;
			if (index >= 0)
			{
				var remove = MessageBox.Show("Remove?", "Remove?",
					MessageBoxButtons.YesNo);
				if (remove == DialogResult.Yes)
				{
					_circuit.Elements.RemoveAt(index);
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
