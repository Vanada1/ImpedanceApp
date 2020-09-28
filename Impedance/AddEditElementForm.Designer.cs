namespace Impedance
{
	partial class AddEditElementForm
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RadioButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ResistorRadioButton = new System.Windows.Forms.RadioButton();
            this.InductorRadioButton = new System.Windows.Forms.RadioButton();
            this.CapacitorRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.RadioButtonsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(19, 16);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(42, 15);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // ValueLabel
            // 
            this.ValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(23, 63);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(38, 15);
            this.ValueLabel.TabIndex = 1;
            this.ValueLabel.Text = "Value:";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(166, 110);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(82, 22);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(254, 110);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(82, 22);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cansel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(67, 12);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(253, 23);
            this.NameTextBox.TabIndex = 4;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTextBox.Location = new System.Drawing.Point(67, 59);
            this.ValueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(253, 23);
            this.ValueTextBox.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.NameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ValueTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ValueLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 9);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 94);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // RadioButtonsTableLayoutPanel
            // 
            this.RadioButtonsTableLayoutPanel.ColumnCount = 3;
            this.RadioButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioButtonsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.RadioButtonsTableLayoutPanel.Controls.Add(this.ResistorRadioButton, 0, 0);
            this.RadioButtonsTableLayoutPanel.Controls.Add(this.InductorRadioButton, 1, 0);
            this.RadioButtonsTableLayoutPanel.Controls.Add(this.CapacitorRadioButton, 2, 0);
            this.RadioButtonsTableLayoutPanel.Enabled = false;
            this.RadioButtonsTableLayoutPanel.Location = new System.Drawing.Point(10, 107);
            this.RadioButtonsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RadioButtonsTableLayoutPanel.Name = "RadioButtonsTableLayoutPanel";
            this.RadioButtonsTableLayoutPanel.RowCount = 1;
            this.RadioButtonsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RadioButtonsTableLayoutPanel.Size = new System.Drawing.Size(150, 24);
            this.RadioButtonsTableLayoutPanel.TabIndex = 7;
            // 
            // ResistorRadioButton
            // 
            this.ResistorRadioButton.AutoSize = true;
            this.ResistorRadioButton.Location = new System.Drawing.Point(3, 2);
            this.ResistorRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResistorRadioButton.Name = "ResistorRadioButton";
            this.ResistorRadioButton.Size = new System.Drawing.Size(32, 19);
            this.ResistorRadioButton.TabIndex = 0;
            this.ResistorRadioButton.TabStop = true;
            this.ResistorRadioButton.Text = "R";
            this.ResistorRadioButton.UseVisualStyleBackColor = true;
            // 
            // InductorRadioButton
            // 
            this.InductorRadioButton.AutoSize = true;
            this.InductorRadioButton.Location = new System.Drawing.Point(52, 2);
            this.InductorRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InductorRadioButton.Name = "InductorRadioButton";
            this.InductorRadioButton.Size = new System.Drawing.Size(31, 19);
            this.InductorRadioButton.TabIndex = 1;
            this.InductorRadioButton.TabStop = true;
            this.InductorRadioButton.Text = "L";
            this.InductorRadioButton.UseVisualStyleBackColor = true;
            // 
            // CapacitorRadioButton
            // 
            this.CapacitorRadioButton.AutoSize = true;
            this.CapacitorRadioButton.Location = new System.Drawing.Point(101, 2);
            this.CapacitorRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CapacitorRadioButton.Name = "CapacitorRadioButton";
            this.CapacitorRadioButton.Size = new System.Drawing.Size(33, 19);
            this.CapacitorRadioButton.TabIndex = 2;
            this.CapacitorRadioButton.TabStop = true;
            this.CapacitorRadioButton.Text = "C";
            this.CapacitorRadioButton.UseVisualStyleBackColor = true;
            // 
            // AddEditElementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 140);
            this.Controls.Add(this.RadioButtonsTableLayoutPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddEditElementsForm";
            this.Text = "AddEditElements";
            this.Load += new System.EventHandler(this.AddEditElements_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.RadioButtonsTableLayoutPanel.ResumeLayout(false);
            this.RadioButtonsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label ValueLabel;
		private System.Windows.Forms.Button OKButton;
		private new System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.TextBox ValueTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel RadioButtonsTableLayoutPanel;
		private System.Windows.Forms.RadioButton ResistorRadioButton;
		private System.Windows.Forms.RadioButton InductorRadioButton;
		private System.Windows.Forms.RadioButton CapacitorRadioButton;
	}
}