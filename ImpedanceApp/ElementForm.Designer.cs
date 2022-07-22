namespace ImpedanceApp
{
	partial class ElementForm
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
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.SegmentsComboBox = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.ValueTextBox = new System.Windows.Forms.TextBox();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(3, 10);
			this.NameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(38, 13);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Name:";
			// 
			// OKButton
			// 
			this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OKButton.Location = new System.Drawing.Point(2, 2);
			this.OKButton.Margin = new System.Windows.Forms.Padding(2);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(71, 24);
			this.OKButton.TabIndex = 2;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelButton.Location = new System.Drawing.Point(77, 2);
			this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(71, 24);
			this.CancelButton.TabIndex = 3;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// NameTextBox
			// 
			this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.NameTextBox.Location = new System.Drawing.Point(45, 7);
			this.NameTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(240, 20);
			this.NameTextBox.TabIndex = 4;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.TypeLabel, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.NameTextBox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.SegmentsComboBox, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.ValueTextBox, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.ValueLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 11);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(287, 103);
			this.tableLayoutPanel1.TabIndex = 6;
			// 
			// SegmentsComboBox
			// 
			this.SegmentsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.SegmentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SegmentsComboBox.FormattingEnabled = true;
			this.SegmentsComboBox.Location = new System.Drawing.Point(45, 75);
			this.SegmentsComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.SegmentsComboBox.Name = "SegmentsComboBox";
			this.SegmentsComboBox.Size = new System.Drawing.Size(240, 21);
			this.SegmentsComboBox.TabIndex = 7;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.OKButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.CancelButton, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(148, 117);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(150, 28);
			this.tableLayoutPanel2.TabIndex = 8;
			// 
			// ValueLabel
			// 
			this.ValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.ValueLabel.AutoSize = true;
			this.ValueLabel.Location = new System.Drawing.Point(4, 44);
			this.ValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.ValueLabel.Name = "ValueLabel";
			this.ValueLabel.Size = new System.Drawing.Size(37, 13);
			this.ValueLabel.TabIndex = 1;
			this.ValueLabel.Text = "Value:";
			// 
			// ValueTextBox
			// 
			this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ValueTextBox.Location = new System.Drawing.Point(45, 41);
			this.ValueTextBox.Margin = new System.Windows.Forms.Padding(2);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.Size = new System.Drawing.Size(240, 20);
			this.ValueTextBox.TabIndex = 5;
			// 
			// TypeLabel
			// 
			this.TypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.TypeLabel.AutoSize = true;
			this.TypeLabel.Location = new System.Drawing.Point(7, 79);
			this.TypeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.TypeLabel.Name = "TypeLabel";
			this.TypeLabel.Size = new System.Drawing.Size(34, 13);
			this.TypeLabel.TabIndex = 8;
			this.TypeLabel.Text = "Type:";
			// 
			// ElementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(309, 151);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "ElementForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Add Elements";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.AddElement_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Button OKButton;
		private new System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ComboBox SegmentsComboBox;
		private System.Windows.Forms.Label TypeLabel;
		private System.Windows.Forms.TextBox ValueTextBox;
		private System.Windows.Forms.Label ValueLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	}
}