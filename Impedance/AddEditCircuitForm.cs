using Impedance;
using System;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditCircuitForm : Form
	{
		public Circuit Circuit { get; set; } = null;

		public AddEditCircuitForm()
		{
			InitializeComponent();
		}

		private void AddEditCircuit_Load(object sender, EventArgs e)
		{
			if (Circuit != null)
			{
				CircuitTextBox.Text = Circuit.Name;
			}
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if (CircuitTextBox.Text.Length != 0)
			{
				string name = CircuitTextBox.Text;
				Circuit = new Circuit(name,
					new SegmentObservableCollection());
				DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("Write circuit name",
					"Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
