﻿using ImpedanceApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditElements : Form
	{
		public IElement Element = null;
		public AddEditElements()
		{
			InitializeComponent();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if (NameTextBox.Text.Length != 0 &&
				ValueTextBox.Text.Length != 0)
			{
				string name = NameTextBox.Text;
				double value;
				try
				{
					value = double.Parse(ValueTextBox.Text);
					DialogResult = DialogResult.OK;
					if (ResistorRadioButton.Checked)
					{
						Element = new Resistor(name, value);
					}
					else if (InductorRadioButton.Checked)
					{
						Element = new Inductor(name, value);
					}
					else if (CapacitorRadioButton.Checked)
					{
						Element = new Capacitor(name, value);
					}
					else
					{
						MessageBox.Show("Choose element", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
						DialogResult = DialogResult.None;
					}
				}
				catch (FormatException exception)
				{
					MessageBox.Show(exception.Message, "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if(NameTextBox.Text.Length == 0)
			{
				MessageBox.Show("Enter Name", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show("Enter Value", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddEditElements_Load(object sender, EventArgs e)
		{
			if(Element != null)
			{
				NameTextBox.Text = Element.Name;
				ValueTextBox.Text = Element.Value.ToString();

				if(Element is Resistor)
				{
					ResistorRadioButton.Checked = true;
				}
				else if(Element is Inductor)
				{
					InductorRadioButton.Checked = true;
				}
				else if(Element is Capacitor)
				{
					CapacitorRadioButton.Checked = true;
				}
			}
			else
			{
				RadioButtonsTableLayoutPanel.Enabled = true;
			}
		}
	}
}
