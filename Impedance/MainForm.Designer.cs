﻿namespace ImpedanceForms
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.FrequenciesListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AddFrequenciesButton = new System.Windows.Forms.Button();
            this.EditFrequenciesButton = new System.Windows.Forms.Button();
            this.RemoveFrequenciesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.ImpedanceListBox = new System.Windows.Forms.ListBox();
            this.FrequenciesLabel = new System.Windows.Forms.Label();
            this.ImpedanceLabel = new System.Windows.Forms.Label();
            this.ElementsListBox = new System.Windows.Forms.ListBox();
            this.ElementsLabel = new System.Windows.Forms.Label();
            this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
            this.CircuitLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.AddElementButton = new System.Windows.Forms.Button();
            this.EditElementButton = new System.Windows.Forms.Button();
            this.RemoveElementButton = new System.Windows.Forms.Button();
            EventLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrequenciesListBox
            // 
            this.FrequenciesListBox.FormattingEnabled = true;
            this.FrequenciesListBox.ItemHeight = 15;
            this.FrequenciesListBox.Location = new System.Drawing.Point(10, 39);
            this.FrequenciesListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FrequenciesListBox.Name = "FrequenciesListBox";
            this.FrequenciesListBox.ScrollAlwaysVisible = true;
            this.FrequenciesListBox.Size = new System.Drawing.Size(208, 304);
            this.FrequenciesListBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.AddFrequenciesButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EditFrequenciesButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RemoveFrequenciesButton, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 353);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(207, 44);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // AddFrequenciesButton
            // 
            this.AddFrequenciesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddFrequenciesButton.Location = new System.Drawing.Point(3, 2);
            this.AddFrequenciesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddFrequenciesButton.Name = "AddFrequenciesButton";
            this.AddFrequenciesButton.Size = new System.Drawing.Size(63, 40);
            this.AddFrequenciesButton.TabIndex = 0;
            this.AddFrequenciesButton.Text = "Add";
            this.AddFrequenciesButton.UseVisualStyleBackColor = true;
            this.AddFrequenciesButton.Click += new System.EventHandler(this.AddFrequenciesButton_Click);
            // 
            // EditFrequenciesButton
            // 
            this.EditFrequenciesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditFrequenciesButton.Location = new System.Drawing.Point(72, 2);
            this.EditFrequenciesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditFrequenciesButton.Name = "EditFrequenciesButton";
            this.EditFrequenciesButton.Size = new System.Drawing.Size(63, 40);
            this.EditFrequenciesButton.TabIndex = 1;
            this.EditFrequenciesButton.Text = "Edit";
            this.EditFrequenciesButton.UseVisualStyleBackColor = true;
            this.EditFrequenciesButton.Click += new System.EventHandler(this.EditFrequenciesButton_Click);
            // 
            // RemoveFrequenciesButton
            // 
            this.RemoveFrequenciesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveFrequenciesButton.Location = new System.Drawing.Point(141, 2);
            this.RemoveFrequenciesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveFrequenciesButton.Name = "RemoveFrequenciesButton";
            this.RemoveFrequenciesButton.Size = new System.Drawing.Size(63, 40);
            this.RemoveFrequenciesButton.TabIndex = 2;
            this.RemoveFrequenciesButton.Text = "Remove";
            this.RemoveFrequenciesButton.UseVisualStyleBackColor = true;
            this.RemoveFrequenciesButton.Click += new System.EventHandler(this.RemoveFrequenciesButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.radioButton1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButton2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioButton3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.radioButton4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.radioButton5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.radioButton6, 0, 5);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(444, 39);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(126, 163);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 4);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 19);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1st example";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 31);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(93, 19);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2nd example";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 58);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(90, 19);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "3rd example";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(3, 85);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(90, 19);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "4th example";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.RadioButton4CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(3, 112);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(90, 19);
            this.radioButton5.TabIndex = 7;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "5th example";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.RadioButton5CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(3, 139);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(90, 19);
            this.radioButton6.TabIndex = 8;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "My example";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.RadioButton6CheckedChanged);
            // 
            // ImpedanceListBox
            // 
            this.ImpedanceListBox.Enabled = false;
            this.ImpedanceListBox.FormattingEnabled = true;
            this.ImpedanceListBox.ItemHeight = 15;
            this.ImpedanceListBox.Location = new System.Drawing.Point(223, 39);
            this.ImpedanceListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImpedanceListBox.Name = "ImpedanceListBox";
            this.ImpedanceListBox.ScrollAlwaysVisible = true;
            this.ImpedanceListBox.Size = new System.Drawing.Size(208, 304);
            this.ImpedanceListBox.TabIndex = 0;
            // 
            // FrequenciesLabel
            // 
            this.FrequenciesLabel.AutoSize = true;
            this.FrequenciesLabel.Location = new System.Drawing.Point(10, 22);
            this.FrequenciesLabel.Name = "FrequenciesLabel";
            this.FrequenciesLabel.Size = new System.Drawing.Size(73, 15);
            this.FrequenciesLabel.TabIndex = 3;
            this.FrequenciesLabel.Text = "Frequencies:";
            // 
            // ImpedanceLabel
            // 
            this.ImpedanceLabel.AutoSize = true;
            this.ImpedanceLabel.Location = new System.Drawing.Point(223, 22);
            this.ImpedanceLabel.Name = "ImpedanceLabel";
            this.ImpedanceLabel.Size = new System.Drawing.Size(69, 15);
            this.ImpedanceLabel.TabIndex = 4;
            this.ImpedanceLabel.Text = "Impedance:";
            // 
            // ElementsListBox
            // 
            this.ElementsListBox.FormattingEnabled = true;
            this.ElementsListBox.ItemHeight = 15;
            this.ElementsListBox.Location = new System.Drawing.Point(593, 34);
            this.ElementsListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ElementsListBox.Name = "ElementsListBox";
            this.ElementsListBox.ScrollAlwaysVisible = true;
            this.ElementsListBox.Size = new System.Drawing.Size(208, 169);
            this.ElementsListBox.TabIndex = 0;
            // 
            // ElementsLabel
            // 
            this.ElementsLabel.AutoSize = true;
            this.ElementsLabel.Location = new System.Drawing.Point(593, 16);
            this.ElementsLabel.Name = "ElementsLabel";
            this.ElementsLabel.Size = new System.Drawing.Size(58, 15);
            this.ElementsLabel.TabIndex = 5;
            this.ElementsLabel.Text = "Elements:";
            // 
            // CircuitPictureBox
            // 
            this.CircuitPictureBox.Location = new System.Drawing.Point(445, 224);
            this.CircuitPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CircuitPictureBox.Name = "CircuitPictureBox";
            this.CircuitPictureBox.Size = new System.Drawing.Size(446, 172);
            this.CircuitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CircuitPictureBox.TabIndex = 6;
            this.CircuitPictureBox.TabStop = false;
            // 
            // CircuitLabel
            // 
            this.CircuitLabel.AutoSize = true;
            this.CircuitLabel.Location = new System.Drawing.Point(445, 207);
            this.CircuitLabel.Name = "CircuitLabel";
            this.CircuitLabel.Size = new System.Drawing.Size(45, 15);
            this.CircuitLabel.TabIndex = 7;
            this.CircuitLabel.Text = "Circuit:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel3.Controls.Add(this.AddElementButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.EditElementButton, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.RemoveElementButton, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(821, 39);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(72, 158);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // AddElementButton
            // 
            this.AddElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddElementButton.Enabled = false;
            this.AddElementButton.Location = new System.Drawing.Point(3, 2);
            this.AddElementButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddElementButton.Name = "AddElementButton";
            this.AddElementButton.Size = new System.Drawing.Size(66, 48);
            this.AddElementButton.TabIndex = 0;
            this.AddElementButton.Text = "Add";
            this.AddElementButton.UseVisualStyleBackColor = true;
            this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
            // 
            // EditElementButton
            // 
            this.EditElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditElementButton.Location = new System.Drawing.Point(3, 54);
            this.EditElementButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditElementButton.Name = "EditElementButton";
            this.EditElementButton.Size = new System.Drawing.Size(66, 48);
            this.EditElementButton.TabIndex = 1;
            this.EditElementButton.Text = "Edit";
            this.EditElementButton.UseVisualStyleBackColor = true;
            this.EditElementButton.Click += new System.EventHandler(this.EditElementsButton_Click);
            // 
            // RemoveElementButton
            // 
            this.RemoveElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveElementButton.Enabled = false;
            this.RemoveElementButton.Location = new System.Drawing.Point(3, 106);
            this.RemoveElementButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RemoveElementButton.Name = "RemoveElementButton";
            this.RemoveElementButton.Size = new System.Drawing.Size(66, 50);
            this.RemoveElementButton.TabIndex = 2;
            this.RemoveElementButton.Text = "Remove";
            this.RemoveElementButton.UseVisualStyleBackColor = true;
            this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
            // 
            // EventLabel
            // 
            EventLabel.AutoSize = true;
            EventLabel.Location = new System.Drawing.Point(224, 353);
            EventLabel.Name = "EventLabel";
            EventLabel.Size = new System.Drawing.Size(38, 15);
            EventLabel.TabIndex = 9;
            EventLabel.Text = "label1";
            EventLabel.Click += new System.EventHandler(this.EventLabel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 413);
            this.Controls.Add(EventLabel);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.CircuitLabel);
            this.Controls.Add(this.CircuitPictureBox);
            this.Controls.Add(this.ElementsLabel);
            this.Controls.Add(this.ElementsListBox);
            this.Controls.Add(this.ImpedanceLabel);
            this.Controls.Add(this.FrequenciesLabel);
            this.Controls.Add(this.ImpedanceListBox);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.FrequenciesListBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(921, 452);
            this.MinimumSize = new System.Drawing.Size(921, 452);
            this.Name = "MainForm";
            this.Text = "ImpedanceApp";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox FrequenciesListBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button AddFrequenciesButton;
		private System.Windows.Forms.Button RemoveFrequenciesButton;
		private System.Windows.Forms.Button EditFrequenciesButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.Label FrequenciesLabel;
		private System.Windows.Forms.Label ImpedanceLabel;
		private System.Windows.Forms.ListBox ElementsListBox;
		private System.Windows.Forms.Label ElementsLabel;
		private System.Windows.Forms.PictureBox CircuitPictureBox;
		private System.Windows.Forms.Label CircuitLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button AddElementButton;
		private System.Windows.Forms.Button EditElementButton;
		private System.Windows.Forms.Button RemoveElementButton;
        private static System.Windows.Forms.Label EventLabel;
    }
}

