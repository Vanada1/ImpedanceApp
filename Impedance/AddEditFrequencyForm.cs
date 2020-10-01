using System;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditFrequencyForm : Form
	{
		/// <summary>
		/// Set and return <see cref="Frequency"/>
		/// </summary>
		public double? Frequency { get; set; } = null;
		public AddEditFrequencyForm()
		{
			InitializeComponent();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if(FrequenciesTextBox.Text.Length != 0)
			{
				try
				{
					Frequency = double.Parse(FrequenciesTextBox.Text);
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
			if (Frequency != null)
			{
				FrequenciesTextBox.Text = Frequency.ToString();
			}
		}

        private void CancelButton_Click(object sender, EventArgs e)
        {
			DialogResult = DialogResult.Cancel;
        }
    }
}
