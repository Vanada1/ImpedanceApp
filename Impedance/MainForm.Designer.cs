namespace ImpedanceForms
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
			this.ImpedanceListBox = new System.Windows.Forms.ListBox();
			this.FrequenciesLabel = new System.Windows.Forms.Label();
			this.ImpedanceLabel = new System.Windows.Forms.Label();
			this.ElementsLabel = new System.Windows.Forms.Label();
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.CircuitLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.AddElementButton = new System.Windows.Forms.Button();
			this.EditElementButton = new System.Windows.Forms.Button();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.EventLabel = new System.Windows.Forms.Label();
			this.CircuitsListBox = new System.Windows.Forms.ListBox();
			this.ElementsTreeView = new System.Windows.Forms.TreeView();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// FrequenciesListBox
			// 
			this.FrequenciesListBox.FormattingEnabled = true;
			this.FrequenciesListBox.ItemHeight = 16;
			this.FrequenciesListBox.Location = new System.Drawing.Point(12, 42);
			this.FrequenciesListBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.FrequenciesListBox.Name = "FrequenciesListBox";
			this.FrequenciesListBox.ScrollAlwaysVisible = true;
			this.FrequenciesListBox.Size = new System.Drawing.Size(237, 324);
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 375);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 47);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// AddFrequenciesButton
			// 
			this.AddFrequenciesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddFrequenciesButton.Location = new System.Drawing.Point(4, 2);
			this.AddFrequenciesButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.AddFrequenciesButton.Name = "AddFrequenciesButton";
			this.AddFrequenciesButton.Size = new System.Drawing.Size(75, 43);
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
			this.EditFrequenciesButton.Location = new System.Drawing.Point(87, 2);
			this.EditFrequenciesButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.EditFrequenciesButton.Name = "EditFrequenciesButton";
			this.EditFrequenciesButton.Size = new System.Drawing.Size(75, 43);
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
			this.RemoveFrequenciesButton.Location = new System.Drawing.Point(170, 2);
			this.RemoveFrequenciesButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.RemoveFrequenciesButton.Name = "RemoveFrequenciesButton";
			this.RemoveFrequenciesButton.Size = new System.Drawing.Size(75, 43);
			this.RemoveFrequenciesButton.TabIndex = 2;
			this.RemoveFrequenciesButton.Text = "Remove";
			this.RemoveFrequenciesButton.UseVisualStyleBackColor = true;
			this.RemoveFrequenciesButton.Click += new System.EventHandler(this.RemoveFrequenciesButton_Click);
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.Enabled = false;
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.ItemHeight = 16;
			this.ImpedanceListBox.Location = new System.Drawing.Point(255, 42);
			this.ImpedanceListBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.ScrollAlwaysVisible = true;
			this.ImpedanceListBox.Size = new System.Drawing.Size(237, 324);
			this.ImpedanceListBox.TabIndex = 0;
			// 
			// FrequenciesLabel
			// 
			this.FrequenciesLabel.AutoSize = true;
			this.FrequenciesLabel.Location = new System.Drawing.Point(12, 23);
			this.FrequenciesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.FrequenciesLabel.Name = "FrequenciesLabel";
			this.FrequenciesLabel.Size = new System.Drawing.Size(90, 17);
			this.FrequenciesLabel.TabIndex = 3;
			this.FrequenciesLabel.Text = "Frequencies:";
			// 
			// ImpedanceLabel
			// 
			this.ImpedanceLabel.AutoSize = true;
			this.ImpedanceLabel.Location = new System.Drawing.Point(255, 23);
			this.ImpedanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ImpedanceLabel.Name = "ImpedanceLabel";
			this.ImpedanceLabel.Size = new System.Drawing.Size(81, 17);
			this.ImpedanceLabel.TabIndex = 4;
			this.ImpedanceLabel.Text = "Impedance:";
			// 
			// ElementsLabel
			// 
			this.ElementsLabel.AutoSize = true;
			this.ElementsLabel.Location = new System.Drawing.Point(728, 23);
			this.ElementsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ElementsLabel.Name = "ElementsLabel";
			this.ElementsLabel.Size = new System.Drawing.Size(70, 17);
			this.ElementsLabel.TabIndex = 5;
			this.ElementsLabel.Text = "Elements:";
			// 
			// CircuitPictureBox
			// 
			this.CircuitPictureBox.Location = new System.Drawing.Point(508, 239);
			this.CircuitPictureBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.CircuitPictureBox.Name = "CircuitPictureBox";
			this.CircuitPictureBox.Size = new System.Drawing.Size(511, 183);
			this.CircuitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.CircuitPictureBox.TabIndex = 6;
			this.CircuitPictureBox.TabStop = false;
			// 
			// CircuitLabel
			// 
			this.CircuitLabel.AutoSize = true;
			this.CircuitLabel.Location = new System.Drawing.Point(508, 220);
			this.CircuitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.CircuitLabel.Name = "CircuitLabel";
			this.CircuitLabel.Size = new System.Drawing.Size(51, 17);
			this.CircuitLabel.TabIndex = 7;
			this.CircuitLabel.Text = "Circuit:";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Controls.Add(this.AddElementButton, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.EditElementButton, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.RemoveElementButton, 0, 2);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(936, 42);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 3;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(83, 169);
			this.tableLayoutPanel3.TabIndex = 8;
			// 
			// AddElementButton
			// 
			this.AddElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddElementButton.Location = new System.Drawing.Point(4, 2);
			this.AddElementButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.AddElementButton.Name = "AddElementButton";
			this.AddElementButton.Size = new System.Drawing.Size(75, 52);
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
			this.EditElementButton.Location = new System.Drawing.Point(4, 58);
			this.EditElementButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.EditElementButton.Name = "EditElementButton";
			this.EditElementButton.Size = new System.Drawing.Size(75, 52);
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
			this.RemoveElementButton.Location = new System.Drawing.Point(4, 114);
			this.RemoveElementButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(75, 53);
			this.RemoveElementButton.TabIndex = 2;
			this.RemoveElementButton.Text = "Remove";
			this.RemoveElementButton.UseVisualStyleBackColor = true;
			this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
			// 
			// EventLabel
			// 
			this.EventLabel.AutoSize = true;
			this.EventLabel.Location = new System.Drawing.Point(265, 375);
			this.EventLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.EventLabel.Name = "EventLabel";
			this.EventLabel.Size = new System.Drawing.Size(46, 17);
			this.EventLabel.TabIndex = 9;
			this.EventLabel.Text = "label1";
			// 
			// CircuitsListBox
			// 
			this.CircuitsListBox.FormattingEnabled = true;
			this.CircuitsListBox.ItemHeight = 16;
			this.CircuitsListBox.Location = new System.Drawing.Point(501, 42);
			this.CircuitsListBox.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.CircuitsListBox.Name = "CircuitsListBox";
			this.CircuitsListBox.ScrollAlwaysVisible = true;
			this.CircuitsListBox.Size = new System.Drawing.Size(221, 164);
			this.CircuitsListBox.TabIndex = 10;
			this.CircuitsListBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsListBox_SelectedIndexChanged);
			// 
			// ElementsTreeView
			// 
			this.ElementsTreeView.Location = new System.Drawing.Point(732, 42);
			this.ElementsTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ElementsTreeView.Name = "ElementsTreeView";
			this.ElementsTreeView.Size = new System.Drawing.Size(199, 164);
			this.ElementsTreeView.TabIndex = 11;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1032, 431);
			this.Controls.Add(this.ElementsTreeView);
			this.Controls.Add(this.CircuitsListBox);
			this.Controls.Add(this.EventLabel);
			this.Controls.Add(this.tableLayoutPanel3);
			this.Controls.Add(this.CircuitLabel);
			this.Controls.Add(this.CircuitPictureBox);
			this.Controls.Add(this.ElementsLabel);
			this.Controls.Add(this.ImpedanceLabel);
			this.Controls.Add(this.FrequenciesLabel);
			this.Controls.Add(this.ImpedanceListBox);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.FrequenciesListBox);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.MaximumSize = new System.Drawing.Size(1050, 478);
			this.MinimumSize = new System.Drawing.Size(1050, 478);
			this.Name = "MainForm";
			this.Text = "ImpedanceApp";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
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
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.Label FrequenciesLabel;
		private System.Windows.Forms.Label ImpedanceLabel;
		private System.Windows.Forms.Label ElementsLabel;
		private System.Windows.Forms.PictureBox CircuitPictureBox;
		private System.Windows.Forms.Label CircuitLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button AddElementButton;
		private System.Windows.Forms.Button EditElementButton;
		private System.Windows.Forms.Button RemoveElementButton;
		private System.Windows.Forms.ListBox CircuitsListBox;
		private System.Windows.Forms.Label EventLabel;
		private System.Windows.Forms.TreeView ElementsTreeView;
	}
}

