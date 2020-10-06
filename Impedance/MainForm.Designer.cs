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
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.FrequenciesGroupBox = new System.Windows.Forms.GroupBox();
			this.ElementGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.NameLabel = new System.Windows.Forms.Label();
			this.AddSerialSegmentButton = new System.Windows.Forms.Button();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.AddElementButton = new System.Windows.Forms.Button();
			this.TypeComboBox = new System.Windows.Forms.ComboBox();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.ValueTextBox = new System.Windows.Forms.TextBox();
			this.AddParallelSegmentButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.EditElementButton = new System.Windows.Forms.Button();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.EventLabel = new System.Windows.Forms.Label();
			this.FrequencyGgroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.RemoveFrequencyButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.FrequencyLabel = new System.Windows.Forms.Label();
			this.FrequencyTextBox = new System.Windows.Forms.TextBox();
			this.AddFrequencyButton = new System.Windows.Forms.Button();
			this.ImpedancesGroupBox = new System.Windows.Forms.GroupBox();
			this.ImpedanceListBox = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.AddCircuit = new System.Windows.Forms.Button();
			this.EditCircuit = new System.Windows.Forms.Button();
			this.RemoveCircuit = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
			this.ElementsTreeView = new System.Windows.Forms.TreeView();
			this.CircuitGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2.SuspendLayout();
			this.FrequenciesGroupBox.SuspendLayout();
			this.ElementGroupBox.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.FrequencyGgroupBox.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			this.ImpedancesGroupBox.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.CircuitGroupBox.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// FrequenciesListBox
			// 
			this.FrequenciesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequenciesListBox.FormattingEnabled = true;
			this.FrequenciesListBox.Location = new System.Drawing.Point(6, 18);
			this.FrequenciesListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.FrequenciesListBox.Name = "FrequenciesListBox";
			this.FrequenciesListBox.ScrollAlwaysVisible = true;
			this.FrequenciesListBox.Size = new System.Drawing.Size(204, 147);
			this.FrequenciesListBox.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.78057F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.11151F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel2.Controls.Add(this.FrequenciesGroupBox, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.ElementGroupBox, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.FrequencyGgroupBox, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.ImpedancesGroupBox, 3, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 432);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(1112, 178);
			this.tableLayoutPanel2.TabIndex = 12;
			// 
			// FrequenciesGroupBox
			// 
			this.FrequenciesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequenciesGroupBox.Controls.Add(this.FrequenciesListBox);
			this.FrequenciesGroupBox.Location = new System.Drawing.Point(669, 3);
			this.FrequenciesGroupBox.Name = "FrequenciesGroupBox";
			this.FrequenciesGroupBox.Size = new System.Drawing.Size(216, 172);
			this.FrequenciesGroupBox.TabIndex = 14;
			this.FrequenciesGroupBox.TabStop = false;
			this.FrequenciesGroupBox.Text = "Frequencies";
			// 
			// ElementGroupBox
			// 
			this.ElementGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ElementGroupBox.Controls.Add(this.tableLayoutPanel1);
			this.ElementGroupBox.Controls.Add(this.tableLayoutPanel5);
			this.ElementGroupBox.Controls.Add(this.tableLayoutPanel7);
			this.ElementGroupBox.Location = new System.Drawing.Point(3, 3);
			this.ElementGroupBox.Name = "ElementGroupBox";
			this.ElementGroupBox.Size = new System.Drawing.Size(403, 172);
			this.ElementGroupBox.TabIndex = 13;
			this.ElementGroupBox.TabStop = false;
			this.ElementGroupBox.Text = "Current Element";
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.ColumnCount = 3;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.82796F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.66667F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.50537F));
			this.tableLayoutPanel5.Controls.Add(this.NameLabel, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.AddSerialSegmentButton, 2, 1);
			this.tableLayoutPanel5.Controls.Add(this.ValueLabel, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.AddElementButton, 2, 2);
			this.tableLayoutPanel5.Controls.Add(this.TypeComboBox, 1, 2);
			this.tableLayoutPanel5.Controls.Add(this.TypeLabel, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.NameTextBox, 1, 0);
			this.tableLayoutPanel5.Controls.Add(this.ValueTextBox, 1, 1);
			this.tableLayoutPanel5.Controls.Add(this.AddParallelSegmentButton, 2, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 3;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(391, 104);
			this.tableLayoutPanel5.TabIndex = 14;
			// 
			// NameLabel
			// 
			this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(8, 0);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(35, 34);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Name";
			this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// AddSerialSegmentButton
			// 
			this.AddSerialSegmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddSerialSegmentButton.Location = new System.Drawing.Point(211, 37);
			this.AddSerialSegmentButton.Name = "AddSerialSegmentButton";
			this.AddSerialSegmentButton.Size = new System.Drawing.Size(177, 28);
			this.AddSerialSegmentButton.TabIndex = 11;
			this.AddSerialSegmentButton.Text = "Add serial segment";
			this.AddSerialSegmentButton.UseVisualStyleBackColor = true;
			this.AddSerialSegmentButton.Click += new System.EventHandler(this.AddSerialSegmentButton_Click);
			// 
			// ValueLabel
			// 
			this.ValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ValueLabel.AutoSize = true;
			this.ValueLabel.Location = new System.Drawing.Point(9, 34);
			this.ValueLabel.Name = "ValueLabel";
			this.ValueLabel.Size = new System.Drawing.Size(34, 34);
			this.ValueLabel.TabIndex = 1;
			this.ValueLabel.Text = "Vlaue";
			this.ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// AddElementButton
			// 
			this.AddElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddElementButton.Location = new System.Drawing.Point(211, 71);
			this.AddElementButton.Name = "AddElementButton";
			this.AddElementButton.Size = new System.Drawing.Size(177, 30);
			this.AddElementButton.TabIndex = 7;
			this.AddElementButton.Text = "Add element";
			this.AddElementButton.UseVisualStyleBackColor = true;
			this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
			// 
			// TypeComboBox
			// 
			this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TypeComboBox.FormattingEnabled = true;
			this.TypeComboBox.Location = new System.Drawing.Point(49, 75);
			this.TypeComboBox.Name = "TypeComboBox";
			this.TypeComboBox.Size = new System.Drawing.Size(156, 21);
			this.TypeComboBox.TabIndex = 10;
			// 
			// TypeLabel
			// 
			this.TypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TypeLabel.AutoSize = true;
			this.TypeLabel.Location = new System.Drawing.Point(12, 68);
			this.TypeLabel.Name = "TypeLabel";
			this.TypeLabel.Size = new System.Drawing.Size(31, 36);
			this.TypeLabel.TabIndex = 2;
			this.TypeLabel.Text = "Type";
			this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.NameTextBox.Location = new System.Drawing.Point(49, 7);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(156, 20);
			this.NameTextBox.TabIndex = 3;
			// 
			// ValueTextBox
			// 
			this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ValueTextBox.Location = new System.Drawing.Point(49, 41);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.Size = new System.Drawing.Size(156, 20);
			this.ValueTextBox.TabIndex = 4;
			// 
			// AddParallelSegmentButton
			// 
			this.AddParallelSegmentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddParallelSegmentButton.Location = new System.Drawing.Point(211, 3);
			this.AddParallelSegmentButton.Name = "AddParallelSegmentButton";
			this.AddParallelSegmentButton.Size = new System.Drawing.Size(177, 28);
			this.AddParallelSegmentButton.TabIndex = 6;
			this.AddParallelSegmentButton.Text = "Add parallel segment";
			this.AddParallelSegmentButton.UseVisualStyleBackColor = true;
			this.AddParallelSegmentButton.Click += new System.EventHandler(this.AddParallelSegmentButton_Click);
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel7.ColumnCount = 2;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel7.Controls.Add(this.EditElementButton, 0, 0);
			this.tableLayoutPanel7.Controls.Add(this.RemoveElementButton, 1, 0);
			this.tableLayoutPanel7.Location = new System.Drawing.Point(214, 123);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(183, 33);
			this.tableLayoutPanel7.TabIndex = 12;
			// 
			// EditElementButton
			// 
			this.EditElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EditElementButton.Location = new System.Drawing.Point(3, 3);
			this.EditElementButton.Name = "EditElementButton";
			this.EditElementButton.Size = new System.Drawing.Size(85, 27);
			this.EditElementButton.TabIndex = 8;
			this.EditElementButton.Text = "Edit";
			this.EditElementButton.UseVisualStyleBackColor = true;
			this.EditElementButton.Click += new System.EventHandler(this.EditElementButton_Click);
			// 
			// RemoveElementButton
			// 
			this.RemoveElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveElementButton.Location = new System.Drawing.Point(94, 3);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(86, 27);
			this.RemoveElementButton.TabIndex = 9;
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
			this.EventLabel.Location = new System.Drawing.Point(3, 0);
			this.EventLabel.Name = "EventLabel";
			this.EventLabel.Size = new System.Drawing.Size(196, 37);
			this.EventLabel.TabIndex = 9;
			this.EventLabel.Text = "label1";
			this.EventLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FrequencyGgroupBox
			// 
			this.FrequencyGgroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequencyGgroupBox.Controls.Add(this.tableLayoutPanel8);
			this.FrequencyGgroupBox.Location = new System.Drawing.Point(412, 3);
			this.FrequencyGgroupBox.Name = "FrequencyGgroupBox";
			this.FrequencyGgroupBox.Size = new System.Drawing.Size(251, 172);
			this.FrequencyGgroupBox.TabIndex = 14;
			this.FrequencyGgroupBox.TabStop = false;
			this.FrequencyGgroupBox.Text = "Frequency";
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel8.ColumnCount = 1;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Controls.Add(this.RemoveFrequencyButton, 0, 2);
			this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 0);
			this.tableLayoutPanel8.Controls.Add(this.AddFrequencyButton, 0, 1);
			this.tableLayoutPanel8.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 3;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.44898F));
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.77551F));
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.77551F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(239, 147);
			this.tableLayoutPanel8.TabIndex = 14;
			// 
			// RemoveFrequencyButton
			// 
			this.RemoveFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveFrequencyButton.Location = new System.Drawing.Point(3, 92);
			this.RemoveFrequencyButton.Name = "RemoveFrequencyButton";
			this.RemoveFrequencyButton.Size = new System.Drawing.Size(233, 52);
			this.RemoveFrequencyButton.TabIndex = 17;
			this.RemoveFrequencyButton.Text = "Remove selected frequency";
			this.RemoveFrequencyButton.UseVisualStyleBackColor = true;
			this.RemoveFrequencyButton.Click += new System.EventHandler(this.RemoveFrequenciesButton_Click);
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel9.ColumnCount = 2;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.75537F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.24464F));
			this.tableLayoutPanel9.Controls.Add(this.FrequencyLabel, 0, 0);
			this.tableLayoutPanel9.Controls.Add(this.FrequencyTextBox, 1, 0);
			this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(233, 27);
			this.tableLayoutPanel9.TabIndex = 0;
			// 
			// FrequencyLabel
			// 
			this.FrequencyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequencyLabel.AutoSize = true;
			this.FrequencyLabel.Location = new System.Drawing.Point(7, 0);
			this.FrequencyLabel.Name = "FrequencyLabel";
			this.FrequencyLabel.Size = new System.Drawing.Size(57, 27);
			this.FrequencyLabel.TabIndex = 14;
			this.FrequencyLabel.Text = "Frequency";
			this.FrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FrequencyTextBox
			// 
			this.FrequencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequencyTextBox.Location = new System.Drawing.Point(70, 3);
			this.FrequencyTextBox.Name = "FrequencyTextBox";
			this.FrequencyTextBox.Size = new System.Drawing.Size(160, 20);
			this.FrequencyTextBox.TabIndex = 15;
			// 
			// AddFrequencyButton
			// 
			this.AddFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddFrequencyButton.Location = new System.Drawing.Point(3, 36);
			this.AddFrequencyButton.Name = "AddFrequencyButton";
			this.AddFrequencyButton.Size = new System.Drawing.Size(233, 50);
			this.AddFrequencyButton.TabIndex = 16;
			this.AddFrequencyButton.Text = "Add Frequency";
			this.AddFrequencyButton.UseVisualStyleBackColor = true;
			this.AddFrequencyButton.Click += new System.EventHandler(this.AddFrequenciesButton_Click);
			// 
			// ImpedancesGroupBox
			// 
			this.ImpedancesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImpedancesGroupBox.Controls.Add(this.ImpedanceListBox);
			this.ImpedancesGroupBox.Location = new System.Drawing.Point(891, 3);
			this.ImpedancesGroupBox.Name = "ImpedancesGroupBox";
			this.ImpedancesGroupBox.Size = new System.Drawing.Size(218, 172);
			this.ImpedancesGroupBox.TabIndex = 15;
			this.ImpedancesGroupBox.TabStop = false;
			this.ImpedancesGroupBox.Text = "Impedances";
			// 
			// ImpedanceListBox
			// 
			this.ImpedanceListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImpedanceListBox.Enabled = false;
			this.ImpedanceListBox.FormattingEnabled = true;
			this.ImpedanceListBox.Location = new System.Drawing.Point(6, 17);
			this.ImpedanceListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ImpedanceListBox.Name = "ImpedanceListBox";
			this.ImpedanceListBox.ScrollAlwaysVisible = true;
			this.ImpedanceListBox.Size = new System.Drawing.Size(206, 147);
			this.ImpedanceListBox.TabIndex = 0;
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
			this.tableLayoutPanel6.Location = new System.Drawing.Point(2, 368);
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(275, 29);
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
			this.AddCircuit.Size = new System.Drawing.Size(87, 25);
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
			this.EditCircuit.Location = new System.Drawing.Point(93, 2);
			this.EditCircuit.Margin = new System.Windows.Forms.Padding(2);
			this.EditCircuit.Name = "EditCircuit";
			this.EditCircuit.Size = new System.Drawing.Size(87, 25);
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
			this.RemoveCircuit.Location = new System.Drawing.Point(184, 2);
			this.RemoveCircuit.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveCircuit.Name = "RemoveCircuit";
			this.RemoveCircuit.Size = new System.Drawing.Size(89, 25);
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
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.CircuitsComboBox, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
			this.tableLayoutPanel4.Controls.Add(this.ElementsTreeView, 0, 1);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(8, 13);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.66666F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(279, 399);
			this.tableLayoutPanel4.TabIndex = 13;
			// 
			// CircuitsComboBox
			// 
			this.CircuitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitsComboBox.FormattingEnabled = true;
			this.CircuitsComboBox.Location = new System.Drawing.Point(3, 3);
			this.CircuitsComboBox.Name = "CircuitsComboBox";
			this.CircuitsComboBox.Size = new System.Drawing.Size(273, 21);
			this.CircuitsComboBox.TabIndex = 12;
			this.CircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsComboBox_SelectedIndexChanged);
			// 
			// ElementsTreeView
			// 
			this.ElementsTreeView.AllowDrop = true;
			this.ElementsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ElementsTreeView.Location = new System.Drawing.Point(3, 33);
			this.ElementsTreeView.Name = "ElementsTreeView";
			this.ElementsTreeView.Size = new System.Drawing.Size(273, 330);
			this.ElementsTreeView.TabIndex = 11;
			this.ElementsTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ElementsTreeView_ItemDrag);
			this.ElementsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ElementsTreeView_AfterSelect);
			this.ElementsTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ElementsTreeView_DragDrop);
			this.ElementsTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ElementsTreeView_DragEnter);
			// 
			// CircuitGroupBox
			// 
			this.CircuitGroupBox.Controls.Add(this.tableLayoutPanel4);
			this.CircuitGroupBox.Location = new System.Drawing.Point(12, 12);
			this.CircuitGroupBox.Name = "CircuitGroupBox";
			this.CircuitGroupBox.Size = new System.Drawing.Size(298, 417);
			this.CircuitGroupBox.TabIndex = 14;
			this.CircuitGroupBox.TabStop = false;
			this.CircuitGroupBox.Text = "Circuit";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.EventLabel, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 129);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(202, 37);
			this.tableLayoutPanel1.TabIndex = 15;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1134, 621);
			this.Controls.Add(this.CircuitGroupBox);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(1150, 660);
			this.Name = "MainForm";
			this.Text = "ImpedanceApp";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.FrequenciesGroupBox.ResumeLayout(false);
			this.ElementGroupBox.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.tableLayoutPanel7.ResumeLayout(false);
			this.FrequencyGgroupBox.ResumeLayout(false);
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.ImpedancesGroupBox.ResumeLayout(false);
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.CircuitGroupBox.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox FrequenciesListBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Button AddCircuit;
		private System.Windows.Forms.Button EditCircuit;
		private System.Windows.Forms.Button RemoveCircuit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ComboBox CircuitsComboBox;
		private System.Windows.Forms.TreeView ElementsTreeView;
		private System.Windows.Forms.ListBox ImpedanceListBox;
		private System.Windows.Forms.GroupBox ElementGroupBox;
		private System.Windows.Forms.Button AddSerialSegmentButton;
		private System.Windows.Forms.Button RemoveElementButton;
		private System.Windows.Forms.Button EditElementButton;
		private System.Windows.Forms.Button AddParallelSegmentButton;
		private System.Windows.Forms.TextBox ValueTextBox;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.Label ValueLabel;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.GroupBox FrequencyGgroupBox;
		private System.Windows.Forms.Button RemoveFrequencyButton;
		private System.Windows.Forms.Button AddFrequencyButton;
		private System.Windows.Forms.TextBox FrequencyTextBox;
		private System.Windows.Forms.Label FrequencyLabel;
		private System.Windows.Forms.Label EventLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Button AddElementButton;
		private System.Windows.Forms.ComboBox TypeComboBox;
		private System.Windows.Forms.Label TypeLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.GroupBox FrequenciesGroupBox;
		private System.Windows.Forms.GroupBox ImpedancesGroupBox;
		private System.Windows.Forms.GroupBox CircuitGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

