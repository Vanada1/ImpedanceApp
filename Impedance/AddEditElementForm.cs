using ImpedanceApp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditElementForm : Form
	{
		private IElement _element = null;

		public IElement Segment = null;

		public List<string> NameSegments = null;

		public AddEditElementForm()
		{
			InitializeComponent();
		}
		private void AddEditElements_Load(object sender, EventArgs e)
		{
			if (Segment != null)
			{
				ValueTextBox.Enabled = false;
				NameTextBox.Text = Segment.Name;
				if (Segment is IElement _element)
				{
					ValueTextBox.Text = _element.Value.ToString();

					if (Segment is Resistor)
					{
						ResistorRadioButton.Checked = true;
					}
					else if (Segment is Inductor)
					{
						InductorRadioButton.Checked = true;
					}
					else if (Segment is Capacitor)
					{
						CapacitorRadioButton.Checked = true;
					}

					ValueTextBox.Enabled = true;
				}
			}
			else
			{
				RadioButtonsTableLayoutPanel.Enabled = true;
			}
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

					if(Segment == null)
					{
						if (ResistorRadioButton.Checked)
						{
							Segment = new Resistor(name, value);
						}
						else if (InductorRadioButton.Checked)
						{
							Segment = new Inductor(name, value);
						}
						else if (CapacitorRadioButton.Checked)
						{
							Segment = new Capacitor(name, value);
						}
						else
						{
							MessageBox.Show("Choose element", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
							DialogResult = DialogResult.None;
						}
					}
					else
					{
						string oldName = Segment.Name;
						double oldValue = Segment.Value;

						if(oldName != name || oldValue!=value)
						{
							try
							{
								Segment.Name = name;
								Segment.Value = value;
							}
							catch(ArgumentOutOfRangeException exception)
                            {
								MessageBox.Show(exception.Message,
									"Error", MessageBoxButtons.OK,
									MessageBoxIcon.Error);
								DialogResult = DialogResult.None;
							}
						}
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
        }
    }
}
