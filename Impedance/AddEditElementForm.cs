using ImpedanceApp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditElementForm : Form
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
		/// Searches the list with the same name
		/// </summary>
		/// <param name="nameSegment">Name to search in the list</param>
		/// <returns>True - if found
		/// False - if not found</returns>
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

		/// <summary>
		/// Create a new segment for the circuit
		/// </summary>
		/// <param name="name">Name of segment</param>
		/// <param name="value">Value of segment if it is
		/// <see cref="ImpedanceApp.Element"/></param>
		private void CreateNewSegment(string name, double value)
		{
			if (SegmentType.TryParse(SegmentsComboBox.Text,
				out ImpedanceApp.SegmentType segment))
			{
				switch (segment)
				{
					case ImpedanceApp.SegmentType.Capacitor:
					{
						Segment = new Capacitor(name, value);
						break;
					}

					case ImpedanceApp.SegmentType.Inductor:
					{
						Segment = new Inductor(name, value);
					
						break;
					}

					case ImpedanceApp.SegmentType.Resistor:
					{
						Segment = new Resistor(name, value);
						break;
					}

					case ImpedanceApp.SegmentType.SerialCircuit:
					{
						SegmentObservableCollection subSegments;
						if (Segment == null &&!(Segment is Element))
						{
							subSegments = new SegmentObservableCollection();
						}
						else
						{
							subSegments = Segment.SubSegments;
						}
						Segment = new SerialCircuit(subSegments);
						break;
					}

					case ImpedanceApp.SegmentType.ParallelCircuit:
					{
						SegmentObservableCollection subSegments;
						if (Segment == null && !(Segment is Element))
						{
							subSegments = new SegmentObservableCollection();
						}
						else
						{
							subSegments = Segment.SubSegments;
						}
						Segment = new ParallelCircuit(subSegments);
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

		public AddEditElementForm()
		{
			InitializeComponent();
		}

		private void AddEditElements_Load(object sender, EventArgs e)
		{
			List<string> typeSegments = new List<string>
			{
				"",
				nameof(ImpedanceApp.SegmentType.Resistor),
				nameof(ImpedanceApp.SegmentType.Capacitor),
				nameof(ImpedanceApp.SegmentType.Inductor),
				nameof(ImpedanceApp.SegmentType.SerialCircuit),
				nameof(ImpedanceApp.SegmentType.ParallelCircuit),
			};

			if (Segment != null)
			{
				ValueTextBox.Enabled = false;
				ValueTextBox.Text = null;
				NameTextBox.Text = Segment.Name;
				SegmentsComboBox.Text = Segment.SegmentType.ToString();
				_element = Segment as Element;
				if (_element != null)
				{
					ValueTextBox.Text = _element.Value.ToString();
					ValueTextBox.Enabled = true;
				}

				if (Segment.SegmentType == SegmentType.ParallelCircuit ||
				    Segment.SegmentType == SegmentType.SerialCircuit)
				{
					typeSegments.RemoveRange(1,3);
				}
				else
				{
					typeSegments = typeSegments.GetRange(0, 4);
				}

			}
			SegmentsComboBox.DataSource = typeSegments;
			SegmentsComboBox.Text = Segment != null ?
				Segment.SegmentType.ToString() : "";
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
			else if (NameTextBox.Text.Length != 0  &&
			         !(Segment is Element))
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
			if (ImpedanceApp.SegmentType.TryParse(SegmentsComboBox.Text,
				out ImpedanceApp.SegmentType segment))
			{
				switch (segment)
				{
					case ImpedanceApp.SegmentType.Capacitor:
						ValueTextBox.Enabled = true;
						break;
					case ImpedanceApp.SegmentType.Inductor:
						ValueTextBox.Enabled = true;
						break;
					case ImpedanceApp.SegmentType.Resistor:
						ValueTextBox.Enabled = true;
						break;
					case ImpedanceApp.SegmentType.SerialCircuit:
						ValueTextBox.Enabled = false;
						break;
					case ImpedanceApp.SegmentType.ParallelCircuit:
						ValueTextBox.Enabled = false;
						break;
				}
			}

		}
	}
}
