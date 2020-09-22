using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;
using ImpedanceApp;
using Impedance;

namespace ImpedanceForms
{
	public partial class MainForm : Form
	{
		private Project project = new Project();

		/// <summary>
		/// Event for collection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void CircuitCollectionChanged(
			object sender, object e)
		{
			MessageBox.Show("Circuit was changed", "Alert",
				MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// Update all list boxes
		/// </summary>
		private void UpdateListBoxes()
		{
			FrequenciesListBox.DataSource = null;
			FrequenciesListBox.DataSource = project.Frequencies;

			project.Results = project.Circuit.CalculateZ(
				project.Frequencies);
			ImpedanceListBox.DataSource = null;
			project.ResultString = new List<string>();
			foreach (var result in project.Results)
			{
				string sign = "+";
				if (result.Imaginary < 0)
				{
					sign = "";
				}
				project.ResultString.Add($"{result.Real} {sign} " +
					$"{result.Imaginary}i");
			}
			ImpedanceListBox.DataSource = project.ResultString;
			ImpedanceListBox.ClearSelected();

			ElementsListBox.DataSource = null;
			ElementsListBox.DataSource = project.Circuit.Elements;
		}


		public MainForm()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			UpdateListBoxes();

			foreach (var example in project.AllExample)
			{
				example.CircuitChanged += CircuitCollectionChanged;
			}
		}

		private void AddFrequenciesButton_Click(object sender, EventArgs e)
		{
			var addFrorm = new AddEditFrequenciesForm();
			addFrorm.ShowDialog();
			if(addFrorm.DialogResult == DialogResult.OK)
			{
				project.Frequencies.Add((double)addFrorm.Frequencie);
			}
			UpdateListBoxes();
		}

		private void EditFrequenciesButton_Click(object sender, EventArgs e)
		{
			var index = FrequenciesListBox.SelectedIndex;
			var editFrorm = new AddEditFrequenciesForm();
			if(index >=0)
			{
				editFrorm.Frequencie = project.Frequencies[index];
				editFrorm.ShowDialog();
				if(editFrorm.DialogResult == DialogResult.OK)
				{
					project.Frequencies[index] = (double)editFrorm.Frequencie;
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
					project.Frequencies.RemoveAt(index);
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
			project.Circuit = project.AllExample[0];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FirstExample;
			UpdateListBoxes();
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			project.Circuit = project.AllExample[1];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.SecondExample;
			UpdateListBoxes();
		}

		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			project.Circuit = project.AllExample[2];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.ThirdExample;
			UpdateListBoxes();
		}

		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			project.Circuit = project.AllExample[3];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FourthExample;
			UpdateListBoxes();
		}

		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			project.Circuit = project.AllExample[4];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FirstExample;
			UpdateListBoxes();
		}

		private void radioButton6_CheckedChanged(object sender, EventArgs e)
		{
			project.Circuit = project.AllExample[5];
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
				editFrorm.Element = project.Circuit.Elements[index];
				editFrorm.ShowDialog();
				if (editFrorm.DialogResult == DialogResult.OK)
				{
					project.Circuit.Elements[index] = editFrorm.Element;
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
				project.Circuit.Elements.Add(addFrorm.Element);
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
					project.Circuit.Elements.RemoveAt(index);
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
