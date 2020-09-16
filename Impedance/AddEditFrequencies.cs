using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditFrequencies : Form
	{
		public double? Frequencie = null;
		public AddEditFrequencies()
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
