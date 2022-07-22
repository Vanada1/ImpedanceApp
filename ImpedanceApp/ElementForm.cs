using Impedance;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImpedanceApp
{
	public partial class ElementForm : Form
	{
		/// <summary>
		/// Set and return current segment for changed
		/// </summary>
		public ISegment Segment { get; set; }

		public ElementForm()
		{
			InitializeComponent();
		}

		private void AddElement_Load(object sender, EventArgs e)
		{
			SegmentsComboBox.DataSource = StringValidator.GetSegmentEnum(
				new Capacitor("temp", 0));
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if (!Enum.TryParse(SegmentsComboBox.Text, out SegmentType segmentType))
			{
				MessageBox.Show(@"Incorrect segment type", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (!double.TryParse(ValueTextBox.Text, out var value))
			{
				MessageBox.Show(@"Incorrect value. Enter the number.", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var name = NameTextBox.Text;
			try
			{
				Segment = CircuitValidator.CreateNewSegment(segmentType, name, value,
					null);
				DialogResult = DialogResult.OK;
			}
			catch (ArgumentException exception)
			{
				MessageBox.Show(exception.Message, @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
