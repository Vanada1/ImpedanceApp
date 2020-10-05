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
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.AddElementButton = new System.Windows.Forms.Button();
			this.EditElementButton = new System.Windows.Forms.Button();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.EventLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.AddCircuit = new System.Windows.Forms.Button();
			this.EditCircuit = new System.Windows.Forms.Button();
			this.RemoveCircuit = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.ElementsTreeView = new System.Windows.Forms.TreeView();
			this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// FrequenciesListBox
			// 
			this.FrequenciesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequenciesListBox.FormattingEnabled = true;
			this.FrequenciesListBox.Location = new System.Drawing.Point(3, 19);
			this.FrequenciesListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.FrequenciesListBox.Name = "FrequenciesListBox";
			this.FrequenciesListBox.ScrollAlwaysVisible = true;
			this.FrequenciesListBox.Size = new System.Drawing.Size(401, 82);
			this.FrequenciesListBox.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.AddFrequenciesButton, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.EditFrequenciesButton, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.RemoveFrequenciesButton, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 106);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 46);
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
			this.AddFrequenciesButton.Size = new System.Drawing.Size(127, 42);
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
			this.EditFrequenciesButton.Location = new System.Drawing.Point(136, 2);
			this.EditFrequenciesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.EditFrequenciesButton.Name = "EditFrequenciesButton";
			this.EditFrequenciesButton.Size = new System.Drawing.Size(127, 42);
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
			this.RemoveFrequenciesButton.Location = new System.Drawing.Point(269, 2);
			this.RemoveFrequenciesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RemoveFrequenciesButton.Name = "RemoveFrequenciesButton";
			this.RemoveFrequenciesButton.Size = new System.Drawing.Size(129, 42);
			this.RemoveFrequenciesButton.TabIndex = 2;
			this.RemoveFrequenciesButton.Text = "Remove";
			this.RemoveFrequenciesButton.UseVisualStyleBackColor = true;
			this.RemoveFrequenciesButton.Click += new System.EventHandler(this.RemoveFrequenciesButton_Click);
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImpedanceListBox.Enabled = false;
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.Location = new System.Drawing.Point(410, 19);
			this.ImpedanceListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.ScrollAlwaysVisible = true;
			this.ImpedanceListBox.Size = new System.Drawing.Size(401, 82);
			this.ImpedanceListBox.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.Controls.Add(this.AddElementButton, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.EditElementButton, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.RemoveElementButton, 2, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 546);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(277, 47);
			this.tableLayoutPanel3.TabIndex = 8;
			// 
			// AddElementButton
			// 
			this.AddElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddElementButton.Location = new System.Drawing.Point(3, 2);
			this.AddElementButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.AddElementButton.Name = "AddElementButton";
			this.AddElementButton.Size = new System.Drawing.Size(86, 43);
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
			this.EditElementButton.Location = new System.Drawing.Point(95, 2);
			this.EditElementButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.EditElementButton.Name = "EditElementButton";
			this.EditElementButton.Size = new System.Drawing.Size(86, 43);
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
			this.RemoveElementButton.Location = new System.Drawing.Point(187, 2);
			this.RemoveElementButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(87, 43);
			this.RemoveElementButton.TabIndex = 2;
			this.RemoveElementButton.Text = "Remove";
			this.RemoveElementButton.UseVisualStyleBackColor = true;
			this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
			// 
			// EventLabel
			// 
			this.EventLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EventLabel.AutoSize = true;
			this.EventLabel.Location = new System.Drawing.Point(410, 104);
			this.EventLabel.Name = "EventLabel";
			this.EventLabel.Size = new System.Drawing.Size(401, 50);
			this.EventLabel.TabIndex = 9;
			this.EventLabel.Text = "label1";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Controls.Add(this.ImpedanceListBox, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.FrequenciesListBox, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.EventLabel, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(291, 451);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(814, 154);
			this.tableLayoutPanel2.TabIndex = 12;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.ColumnCount = 3;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel6.Controls.Add(this.AddCircuit, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.EditCircuit, 1, 0);
			this.tableLayoutPanel6.Controls.Add(this.RemoveCircuit, 2, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 427);
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(279, 33);
			this.tableLayoutPanel6.TabIndex = 12;
			// 
			// AddCircuit
			// 
			this.AddCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddCircuit.Location = new System.Drawing.Point(2, 2);
			this.AddCircuit.Margin = new System.Windows.Forms.Padding(2);
			this.AddCircuit.Name = "AddCircuit";
			this.AddCircuit.Size = new System.Drawing.Size(89, 29);
			this.AddCircuit.TabIndex = 0;
			this.AddCircuit.Text = "Add circuit";
			this.AddCircuit.UseVisualStyleBackColor = true;
			this.AddCircuit.Click += new System.EventHandler(this.AddCircuit_Click);
			// 
			// EditCircuit
			// 
			this.EditCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EditCircuit.Location = new System.Drawing.Point(95, 2);
			this.EditCircuit.Margin = new System.Windows.Forms.Padding(2);
			this.EditCircuit.Name = "EditCircuit";
			this.EditCircuit.Size = new System.Drawing.Size(89, 29);
			this.EditCircuit.TabIndex = 1;
			this.EditCircuit.Text = "Edit";
			this.EditCircuit.UseVisualStyleBackColor = true;
			this.EditCircuit.Click += new System.EventHandler(this.EditCircuit_Click);
			// 
			// RemoveCircuit
			// 
			this.RemoveCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveCircuit.Location = new System.Drawing.Point(188, 2);
			this.RemoveCircuit.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveCircuit.Name = "RemoveCircuit";
			this.RemoveCircuit.Size = new System.Drawing.Size(89, 29);
			this.RemoveCircuit.TabIndex = 2;
			this.RemoveCircuit.Text = "Remove circuit";
			this.RemoveCircuit.UseVisualStyleBackColor = true;
			this.RemoveCircuit.Click += new System.EventHandler(this.RemoveCircuit_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Controls.Add(this.ElementsTreeView, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.CircuitsComboBox, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 3);
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(9, 10);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 4;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(283, 595);
			this.tableLayoutPanel4.TabIndex = 13;
			// 
			// ElementsTreeView
			// 
			this.ElementsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ElementsTreeView.Location = new System.Drawing.Point(3, 38);
			this.ElementsTreeView.Name = "ElementsTreeView";
			this.ElementsTreeView.Size = new System.Drawing.Size(277, 384);
			this.ElementsTreeView.TabIndex = 11;
			// 
			// CircuitsComboBox
			// 
			this.CircuitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitsComboBox.FormattingEnabled = true;
			this.CircuitsComboBox.Location = new System.Drawing.Point(3, 3);
			this.CircuitsComboBox.Name = "CircuitsComboBox";
			this.CircuitsComboBox.Size = new System.Drawing.Size(277, 21);
			this.CircuitsComboBox.TabIndex = 12;
			this.CircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsComboBox_SelectedIndexChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1115, 621);
			this.Controls.Add(this.tableLayoutPanel4);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(829, 531);
			this.Name = "MainForm";
			this.Text = "ImpedanceApp";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox FrequenciesListBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button AddFrequenciesButton;
		private System.Windows.Forms.Button RemoveFrequenciesButton;
		private System.Windows.Forms.Button EditFrequenciesButton;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button AddElementButton;
		private System.Windows.Forms.Button EditElementButton;
		private System.Windows.Forms.Button RemoveElementButton;
		private System.Windows.Forms.Label EventLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Button AddCircuit;
		private System.Windows.Forms.Button EditCircuit;
		private System.Windows.Forms.Button RemoveCircuit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ComboBox CircuitsComboBox;
		private System.Windows.Forms.TreeView ElementsTreeView;
	}
}

