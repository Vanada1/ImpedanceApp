namespace Impedance
{
	partial class AddEditCircuitForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CircuitNameLabel = new System.Windows.Forms.Label();
			this.CircuitTextBox = new System.Windows.Forms.TextBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CircuitNameLabel
			// 
			this.CircuitNameLabel.AutoSize = true;
			this.CircuitNameLabel.Location = new System.Drawing.Point(12, 32);
			this.CircuitNameLabel.Name = "CircuitNameLabel";
			this.CircuitNameLabel.Size = new System.Drawing.Size(92, 17);
			this.CircuitNameLabel.TabIndex = 0;
			this.CircuitNameLabel.Text = "Circuit Name:";
			// 
			// CircuitTextBox
			// 
			this.CircuitTextBox.Location = new System.Drawing.Point(110, 29);
			this.CircuitTextBox.Name = "CircuitTextBox";
			this.CircuitTextBox.Size = new System.Drawing.Size(218, 22);
			this.CircuitTextBox.TabIndex = 1;
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(134, 68);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(94, 24);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Location = new System.Drawing.Point(234, 68);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(94, 24);
			this.CancelButton.TabIndex = 3;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// AddEditCircuit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(340, 104);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.CircuitTextBox);
			this.Controls.Add(this.CircuitNameLabel);
			this.Name = "AddEditCircuit";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.AddEditCircuit_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label CircuitNameLabel;
		private System.Windows.Forms.TextBox CircuitTextBox;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
	}
}