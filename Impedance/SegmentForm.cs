using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Impedance;

namespace ImpedanceApp
{
	public partial class SegmentForm : Form
	{
		/// <summary>
		/// Set and return current segment for changed
		/// </summary>
		public ISegment Segment { get; set; }

		public SegmentForm()
		{
			InitializeComponent();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			if (SerialRadioButton.Checked)
			{
				Segment = new SerialCircuit(new SegmentObservableCollection());
			}
			else if (ParallelRadioButton.Checked)
			{
				Segment = new ParallelCircuit(new SegmentObservableCollection());
			}
			else
			{
				MessageBox.Show(@"No segment type selected", @"Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				DialogResult = DialogResult.None;
			}
		}
	}
}
