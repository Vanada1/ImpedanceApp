namespace Impedance
{
	partial class AddEditFrequenciesForm
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
			this.OKButton = new System.Windows.Forms.Button();
			this.CanselButton = new System.Windows.Forms.Button();
			this.FrequenciesLabel = new System.Windows.Forms.Label();
			this.FrequenciesTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(96, 87);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(94, 29);
			this.OKButton.TabIndex = 0;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// CanselButton
			// 
			this.CanselButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CanselButton.Location = new System.Drawing.Point(196, 87);
			this.CanselButton.Name = "CanselButton";
			this.CanselButton.Size = new System.Drawing.Size(94, 29);
			this.CanselButton.TabIndex = 1;
			this.CanselButton.Text = "Cansel";
			this.CanselButton.UseVisualStyleBackColor = true;
			// 
			// FrequenciesLabel
			// 
			this.FrequenciesLabel.AutoSize = true;
			this.FrequenciesLabel.Location = new System.Drawing.Point(2, 40);
			this.FrequenciesLabel.Name = "FrequenciesLabel";
			this.FrequenciesLabel.Size = new System.Drawing.Size(90, 20);
			this.FrequenciesLabel.TabIndex = 2;
			this.FrequenciesLabel.Text = "Frequencies:";
			// 
			// FrequenciesTextBox
			// 
			this.FrequenciesTextBox.Location = new System.Drawing.Point(96, 37);
			this.FrequenciesTextBox.Name = "FrequenciesTextBox";
			this.FrequenciesTextBox.Size = new System.Drawing.Size(194, 27);
			this.FrequenciesTextBox.TabIndex = 3;
			// 
			// AddEditFrequencies
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(302, 128);
			this.Controls.Add(this.FrequenciesTextBox);
			this.Controls.Add(this.FrequenciesLabel);
			this.Controls.Add(this.CanselButton);
			this.Controls.Add(this.OKButton);
			this.MaximumSize = new System.Drawing.Size(320, 175);
			this.MinimumSize = new System.Drawing.Size(320, 175);
			this.Name = "AddEditFrequencies";
			this.Text = "AddEditFrequencies";
			this.Load += new System.EventHandler(this.AddEditFrequencies_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CansleButton;
		private System.Windows.Forms.Label FrequenciesLabel;
		private System.Windows.Forms.TextBox FrequenciesTextBox;
		private System.Windows.Forms.Button Cansle;
		private System.Windows.Forms.Button CanselButton;
	}
}