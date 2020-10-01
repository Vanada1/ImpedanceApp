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

		private void CreateNewSegment(string name, double value)
		{
			if (ImpedanceApp.Segment.TryParse(SegmentsComboBox.Text,
				out ImpedanceApp.Segment segment))
			{
				switch (segment)
				{
					case ImpedanceApp.Segment.Capacitor:
						Segment = new Capacitor(name, value);
						break;
					case ImpedanceApp.Segment.Inductor:
						Segment = new Inductor(name, value);
						break;
					case ImpedanceApp.Segment.Resistor:
						Segment = new Resistor(name, value);
						break;
					case ImpedanceApp.Segment.SerialCircuit:
						Segment = new SerialCircuit(name, 
							new SegmentObservableCollection());
						break;
					case ImpedanceApp.Segment.ParallelCircuit:
						Segment = new ParallelCircuit(name, 
							new SegmentObservableCollection());
						break;
				}
			}
			else
			{
				MessageBox.Show("Select the segment", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public AddEditElementForm()
		{
			InitializeComponent();
		}
		private void AddEditElements_Load(object sender, EventArgs e)
		{
			List<string> typeSegments = new List<string>
			{
				"",
				nameof(ImpedanceApp.Segment.Resistor),
				nameof(ImpedanceApp.Segment.Capacitor),
				nameof(ImpedanceApp.Segment.Inductor),
				nameof(ImpedanceApp.Segment.SerialCircuit),
				nameof(ImpedanceApp.Segment.ParallelCircuit),
			};
			SegmentsComboBox.DataSource = typeSegments;

			if (Segment != null)
			{
				ValueTextBox.Enabled = false;
				ValueTextBox.Text = null;
				NameTextBox.Text = Segment.Name;
				_element = Segment as IElement;
				if (_element != null)
				{
					ValueTextBox.Text = _element.Value.ToString();

					
					ValueTextBox.Enabled = true;
				}
			}
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if (SearchName(NameTextBox.Text))
			{
				MessageBox.Show("An object already exists with" +
				                " the same name",
					"Error", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
			}
			else if (NameTextBox.Text.Length != 0 &&
			    ValueTextBox.Text.Length != 0 &&
			    ValueTextBox.Enabled)
			{
				string name = NameTextBox.Text;
				try
				{
					var value = double.Parse(ValueTextBox.Text);
					DialogResult = DialogResult.OK;
					CreateNewSegment(name, value);
					_element = Segment as IElement;
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
				catch (FormatException exception)
				{
					MessageBox.Show(exception.Message, "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else if (NameTextBox.Text.Length != 0  &&
			         !(Segment is IElement))
			{
				string name = NameTextBox.Text;
				CreateNewSegment(name, -1);
				DialogResult = DialogResult.OK;
			}
			else if (NameTextBox.Text.Length == 0)
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

		private void SegmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ImpedanceApp.Segment.TryParse(SegmentsComboBox.Text,
				out ImpedanceApp.Segment segment))
			{
				switch (segment)
				{
					case ImpedanceApp.Segment.Capacitor:
						ValueTextBox.Enabled = true;
						break;
					case ImpedanceApp.Segment.Inductor:
						ValueTextBox.Enabled = true;
						break;
					case ImpedanceApp.Segment.Resistor:
						ValueTextBox.Enabled = true;
						break;
					case ImpedanceApp.Segment.SerialCircuit:
						ValueTextBox.Enabled = false;
						break;
					case ImpedanceApp.Segment.ParallelCircuit:
						ValueTextBox.Enabled = false;
						break;
				}
			}

		}
	}
}
