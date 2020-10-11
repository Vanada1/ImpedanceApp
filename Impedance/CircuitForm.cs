using Impedance;
using System;
using System.Windows.Forms;

namespace ImpedanceApp
{
	public partial class CircuitForm : Form
	{
		public Circuit Circuit { get; set; }

		public CircuitForm()
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
			if (CircuitTextBox.Text.Length == 0)
			{
				MessageBox.Show(@"Enter circuit name",
					@"Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			var name = CircuitTextBox.Text;
			Circuit = new Circuit(name,
				new SegmentObservableCollection());
			DialogResult = DialogResult.OK;
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
