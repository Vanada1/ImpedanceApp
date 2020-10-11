using Impedance;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddElementForm : Form
	{
		/// <summary>
		/// Field for working with element
		/// </summary>
		private Element _element = null;

		/// <summary>
		/// Set and return current segment for chenged
		/// </summary>
		public ISegment Segment { get; set; } = null;

		/// <summary>
		/// Set and return that stores all used net names
		/// </summary>
		public List<string> NameSegments { get; set; } = null;

		/// <summary>
		/// Create a new segment for the circuit
		/// </summary>
		/// <param name="name">Name of segment</param>
		/// <param name="value">Value of segment if it is
		/// <see cref="Impedance.Element"/></param>
		private void CreateNewSegment(string name, double value)
		{
			if (SegmentType.TryParse(SegmentsComboBox.Text,
				out Impedance.SegmentType segment))
			{
				switch (segment)
				{
					case Impedance.SegmentType.Capacitor:
						{
							Segment = new Capacitor(name, value);
							break;
						}

					case Impedance.SegmentType.Inductor:
						{
							Segment = new Inductor(name, value);

							break;
						}

					case Impedance.SegmentType.Resistor:
						{
							Segment = new Resistor(name, value);
							break;
						}

					default:
						{
							DialogResult = DialogResult.None;
							MessageBox.Show("Strange type", "Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						}
				}
			}
			else
			{
				MessageBox.Show("Select the segment", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
			}
		}

		public AddElementForm()
		{
			InitializeComponent();
		}

		private void AddElement_Load(object sender, EventArgs e)
		{
			List<string> typeSegments = new List<string>
			{
				"",
				nameof(Impedance.SegmentType.Resistor),
				nameof(Impedance.SegmentType.Capacitor),
				nameof(Impedance.SegmentType.Inductor)
			};

			SegmentsComboBox.DataSource = typeSegments;
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if (SegmentsComboBox.SelectedIndex == 0)
			{
				MessageBox.Show("Choose the segment",
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
					_element = Segment as Element;
					try
					{
						_element.Name = name;
						_element.Value = value;
						Segment = _element;
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
			else if (NameTextBox.Text.Length != 0 &&
					 !(Segment is Element))
			{
				string name = NameTextBox.Text;
				DialogResult = DialogResult.OK;
				CreateNewSegment(name, -1);
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
			if (Impedance.SegmentType.TryParse(SegmentsComboBox.Text,
				out Impedance.SegmentType segment))
			{
				switch (segment)
				{
					case Impedance.SegmentType.Capacitor:
						{
							ValueTextBox.Enabled = true;
							break;
						}
					case Impedance.SegmentType.Inductor:
						{
							ValueTextBox.Enabled = true;
							break;
						}
					case Impedance.SegmentType.Resistor:
						{
							ValueTextBox.Enabled = true;
							break;
						}
					default:
						{
							DialogResult = DialogResult.None;
							MessageBox.Show("Strange type", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
							break;
						}
				}
			}

		}
	}
}
