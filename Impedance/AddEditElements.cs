using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Impedance
{
	public partial class AddEditElements : Form
	{
		public string Name = null;
		public double? ElementValue = null;
		public AddEditElements()
		{
			InitializeComponent();
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if (NameTextBox.Text.Length != 0 &&
				ValueTextBox.Text.Length != 0)
			{
				Name = NameTextBox.Text;
				try
				{
					ElementValue = double.Parse(ValueTextBox.Text);
					DialogResult = DialogResult.OK;
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
			else
			{
				MessageBox.Show("Enter Value", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AddEditElements_Load(object sender, EventArgs e)
		{
			if(Name != null && ElementValue != null)
			{
				NameTextBox.Text = Name;
				ValueTextBox.Text = ElementValue.ToString();
			}
		}
	}
}
