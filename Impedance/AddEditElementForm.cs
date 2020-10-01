using ImpedanceApp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditElementForm : Form
	{
		private IElement _element = null;

		public ISegment Segment = null;

		public List<string> NameSegments = null;

		private bool SearchName(string nameSegment)
		{
			NameSegments.Remove(Segment.Name);
			if (NameSegments == null)
			{
				throw new ArgumentException(
					"There should be a list of names, " +
					"but it isn't");
			}

			foreach (var name in NameSegments)
			{
				if (name == nameSegment)
				{
					return true;
				}
			}

			return false;
		}

		public AddEditElementForm()
		{
			InitializeComponent();
		}
		private void AddEditElements_Load(object sender, EventArgs e)
		{
			if (Segment != null)
			{
				ValueTextBox.Enabled = false;
				ValueTextBox.Text = null;
				NameTextBox.Text = Segment.Name;
				_element = Segment as IElement;
				if (_element != null)
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
			    ValueTextBox.Text.Length != 0 &&
			   !SearchName(NameTextBox.Text))
			{
				string name = NameTextBox.Text;
				try
				{
					var value = double.Parse(ValueTextBox.Text);
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
						try
						{
							_element.Name = name;
							_element.Value = value;
						}
						catch (ArgumentOutOfRangeException exception)
						{
							MessageBox.Show(exception.Message,
								"Error", MessageBoxButtons.OK,
								MessageBoxIcon.Error);
							DialogResult = DialogResult.None;
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
			else if (NameTextBox.Text.Length != 0  &&
			         !(Segment is IElement) && 
			         !SearchName(NameTextBox.Text))
			{
				string name = NameTextBox.Text;
				Segment.Name = name;
				DialogResult = DialogResult.OK;
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
