using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;
using ImpedanceApp;
using Impedance;

namespace ImpedanceForms
{
	public partial class MainForm : Form
	{
		private readonly Project _project = new Project();

        /// <summary>
        /// Event for collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCircuitCollectionChanged(
            object sender, EventArgs e)
        {
            if (e is ElementEventArgs elem)
            {
                EventLabel.Text = elem.Message;
				EventLabel.ForeColor = Color.Brown;
            }
        }

        /// <summary>
		/// Update all list boxes
		/// </summary>
		private void UpdateListBoxes()
		{
			FrequenciesListBox.DataSource = null;
			FrequenciesListBox.DataSource = _project.Frequencies;

			_project.Results = _project.CurrentCircuit.CalculateZ(
				_project.Frequencies);
			ImpedanceListBox.DataSource = null;
			_project.ResultsString = new List<string>();
			foreach (var result in _project.Results)
			{
				string sign = "+";
				if (result.Imaginary < 0)
				{
					sign = "";
				}
				_project.ResultsString.Add($"{result.Real} {sign} " +
					$"{result.Imaginary}i");
			}
			ImpedanceListBox.DataSource = _project.ResultsString;
			ImpedanceListBox.ClearSelected();
			_project.FindAllElements(_project.CurrentCircuit);
			ElementsListBox.DataSource = null;
			ElementsListBox.DataSource = _project.CircuitElements;
		}


		public MainForm()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{
			UpdateListBoxes();
            EventLabel.Text = "";

			foreach (Circuit example in _project.AllExamples)
			{
				example.SegmentChanged += OnCircuitCollectionChanged;
			}
			CircuitsListBox.DataSource = null;
			CircuitsListBox.DataSource = _project.AllExamples;
			CircuitsListBox.DisplayMember = "Name";
		}

		private void AddFrequenciesButton_Click(object sender, EventArgs e)
		{
			var addFrorm = new AddEditFrequenciesForm();
			addFrorm.ShowDialog();
			if(addFrorm.DialogResult == DialogResult.OK)
			{
				_project.Frequencies.Add((double)addFrorm.Frequencie);
			}
			UpdateListBoxes();
		}

		private void EditFrequenciesButton_Click(object sender, EventArgs e)
		{
			var index = FrequenciesListBox.SelectedIndex;
			var editForm = new AddEditFrequenciesForm();
			if (index >= 0)
			{
				editForm.Frequencie = _project.Frequencies[index];
				editForm.ShowDialog();
				if (editForm.DialogResult == DialogResult.OK)
				{
					_project.Frequencies[index] = (double)editForm.Frequencie;
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Frequency was not selected", "Error",
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
					_project.Frequencies.RemoveAt(index);
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show("Frequency was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void EditElementsButton_Click(object sender, EventArgs e)
		{
			var index = ElementsListBox.SelectedIndex;
			if (index >= 0)
			{
                AddEditElementsForm editForm = new AddEditElementsForm
                {
                    Element = _project.CircuitElements[index] as IElement
                };
                editForm.ShowDialog();
				if (editForm.DialogResult == DialogResult.OK)
				{
					_project.CircuitElements[index] = editForm.Element;
				}
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddElementButton_Click(object sender, EventArgs e)
		{
			var addFrorm = new AddEditElementsForm();
			addFrorm.ShowDialog();
			if (addFrorm.DialogResult == DialogResult.OK)
			{
				_project.CurrentCircuit.SubSegments.Add(addFrorm.Element);
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
					ISegment foundElement = _project.CircuitElements[index];
					_project.CurrentCircuit.RemoveElement(foundElement);
					UpdateListBoxes();
				}
			}
			else
			{
				MessageBox.Show(nameof(Element) + "was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CircuitsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			var index = CircuitsListBox.SelectedIndex;
			if (index >= 0)
			{
				_project.CurrentCircuit = _project.AllExamples[index];
				UpdateListBoxes();
			}
			else
			{
				MessageBox.Show(nameof(Circuit) + " was not selected", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			_project.CurrentCircuit = _project.AllExamples[0];
			AddElementButton.Enabled = false;
			RemoveElementButton.Enabled = false;
			CircuitPictureBox.Image = Impedance.Properties.Resources.FirstExample;
			UpdateListBoxes();
		}
	}
}
