using System;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditFrequenciesForm : Form
	{
		public double? Frequencie { get; set; } = null;
		public AddEditFrequenciesForm()
		{
			InitializeComponent();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if(FrequenciesTextBox.Text.Length != 0)
			{
				try
				{
					Frequencie = double.Parse(FrequenciesTextBox.Text);
					this.DialogResult = DialogResult.OK;
				}
				catch(FormatException exception)
				{
					MessageBox.Show(exception.Message,"Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Write frequencies", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddEditFrequencies_Load(object sender, EventArgs e)
		{
			if (Frequencie != null)
			{
				FrequenciesTextBox.Text = Frequencie.ToString();
			}
		}
	}
}
