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
			this.components = new System.ComponentModel.Container();
			this.ElementGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.NameLabel = new System.Windows.Forms.Label();
			this.EditElementButton = new System.Windows.Forms.Button();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.TypeComboBox = new System.Windows.Forms.ComboBox();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.ValueTextBox = new System.Windows.Forms.TextBox();
			this.AddElementButton = new System.Windows.Forms.Button();
			this.EventLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.RemoveFrequencyButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
			this.FrequencyTextBox = new System.Windows.Forms.TextBox();
			this.FrequencyLabel = new System.Windows.Forms.Label();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.AddCircuit = new System.Windows.Forms.Button();
			this.EditCircuit = new System.Windows.Forms.Button();
			this.RemoveCircuit = new System.Windows.Forms.Button();
			this.AddSegment = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.CircuitsComboBox = new System.Windows.Forms.ComboBox();
			this.ElementsTreeView = new System.Windows.Forms.TreeView();
			this.CircuitContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addParallelSegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addSerialSegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CircuitGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ImpedancesDataGridView = new System.Windows.Forms.DataGridView();
			this.ImpedancesGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.AddFrequencyButton = new System.Windows.Forms.Button();
			this.ElementGroupBox.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.tableLayoutPanel9.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.CircuitContextMenuStrip.SuspendLayout();
			this.CircuitGroupBox.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImpedancesDataGridView)).BeginInit();
			this.ImpedancesGroupBox.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ElementGroupBox
			// 
			this.ElementGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ElementGroupBox.Controls.Add(this.tableLayoutPanel5);
			this.ElementGroupBox.Location = new System.Drawing.Point(12, 357);
			this.ElementGroupBox.Name = "ElementGroupBox";
			this.ElementGroupBox.Size = new System.Drawing.Size(405, 134);
			this.ElementGroupBox.TabIndex = 13;
			this.ElementGroupBox.TabStop = false;
			this.ElementGroupBox.Text = "Current Element";
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.ColumnCount = 3;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.82796F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.31202F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.92327F));
			this.tableLayoutPanel5.Controls.Add(this.RemoveElementButton, 2, 2);
			this.tableLayoutPanel5.Controls.Add(this.NameLabel, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.EditElementButton, 2, 0);
			this.tableLayoutPanel5.Controls.Add(this.ValueLabel, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.TypeComboBox, 1, 2);
			this.tableLayoutPanel5.Controls.Add(this.TypeLabel, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.NameTextBox, 1, 0);
			this.tableLayoutPanel5.Controls.Add(this.ValueTextBox, 1, 1);
			this.tableLayoutPanel5.Controls.Add(this.AddElementButton, 2, 1);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 19);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 3;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(393, 104);
			this.tableLayoutPanel5.TabIndex = 14;
			// 
			// RemoveElementButton
			// 
			this.RemoveElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveElementButton.Location = new System.Drawing.Point(278, 71);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(112, 30);
			this.RemoveElementButton.TabIndex = 9;
			this.RemoveElementButton.Text = "Remove";
			this.RemoveElementButton.UseVisualStyleBackColor = true;
			this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
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
			// EditElementButton
			// 
			this.EditElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EditElementButton.Location = new System.Drawing.Point(278, 3);
			this.EditElementButton.Name = "EditElementButton";
			this.EditElementButton.Size = new System.Drawing.Size(112, 28);
			this.EditElementButton.TabIndex = 8;
			this.EditElementButton.Text = "Edit";
			this.EditElementButton.UseVisualStyleBackColor = true;
			this.EditElementButton.Click += new System.EventHandler(this.EditElementButton_Click);
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
			this.ValueLabel.Text = "Value";
			this.ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TypeComboBox
			// 
			this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeComboBox.FormattingEnabled = true;
			this.TypeComboBox.Location = new System.Drawing.Point(49, 75);
			this.TypeComboBox.Name = "TypeComboBox";
			this.TypeComboBox.Size = new System.Drawing.Size(223, 21);
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
			this.NameTextBox.Size = new System.Drawing.Size(223, 20);
			this.NameTextBox.TabIndex = 3;
			// 
			// ValueTextBox
			// 
			this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ValueTextBox.Location = new System.Drawing.Point(49, 41);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.Size = new System.Drawing.Size(223, 20);
			this.ValueTextBox.TabIndex = 4;
			// 
			// AddElementButton
			// 
			this.AddElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddElementButton.Location = new System.Drawing.Point(278, 37);
			this.AddElementButton.Name = "AddElementButton";
			this.AddElementButton.Size = new System.Drawing.Size(112, 28);
			this.AddElementButton.TabIndex = 7;
			this.AddElementButton.Text = "Add element";
			this.AddElementButton.UseVisualStyleBackColor = true;
			this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
			// 
			// EventLabel
			// 
			this.EventLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.EventLabel.AutoSize = true;
			this.EventLabel.Location = new System.Drawing.Point(3, 27);
			this.EventLabel.Name = "EventLabel";
			this.EventLabel.Size = new System.Drawing.Size(35, 13);
			this.EventLabel.TabIndex = 9;
			this.EventLabel.Text = "label1";
			this.EventLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel8.ColumnCount = 1;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.Location = new System.Drawing.Point(488, 165);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 3;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(239, 104);
			this.tableLayoutPanel8.TabIndex = 14;
			// 
			// RemoveFrequencyButton
			// 
			this.RemoveFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveFrequencyButton.Location = new System.Drawing.Point(406, 4);
			this.RemoveFrequencyButton.Name = "RemoveFrequencyButton";
			this.RemoveFrequencyButton.Size = new System.Drawing.Size(84, 28);
			this.RemoveFrequencyButton.TabIndex = 17;
			this.RemoveFrequencyButton.Text = "Remove";
			this.RemoveFrequencyButton.UseVisualStyleBackColor = true;
			this.RemoveFrequencyButton.Click += new System.EventHandler(this.RemoveFrequenciesButton_Click);
			// 
			// tableLayoutPanel9
			// 
			this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel9.ColumnCount = 2;
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.54341F));
			this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.45659F));
			this.tableLayoutPanel9.Controls.Add(this.FrequencyTextBox, 1, 0);
			this.tableLayoutPanel9.Controls.Add(this.FrequencyLabel, 0, 0);
			this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(311, 29);
			this.tableLayoutPanel9.TabIndex = 0;
			// 
			// FrequencyTextBox
			// 
			this.FrequencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequencyTextBox.Location = new System.Drawing.Point(70, 4);
			this.FrequencyTextBox.Name = "FrequencyTextBox";
			this.FrequencyTextBox.Size = new System.Drawing.Size(238, 20);
			this.FrequencyTextBox.TabIndex = 15;
			// 
			// FrequencyLabel
			// 
			this.FrequencyLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.FrequencyLabel.AutoSize = true;
			this.FrequencyLabel.Location = new System.Drawing.Point(7, 8);
			this.FrequencyLabel.Name = "FrequencyLabel";
			this.FrequencyLabel.Size = new System.Drawing.Size(57, 13);
			this.FrequencyLabel.TabIndex = 14;
			this.FrequencyLabel.Text = "Frequency";
			this.FrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.ColumnCount = 4;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
			this.tableLayoutPanel6.Controls.Add(this.AddCircuit, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.EditCircuit, 1, 0);
			this.tableLayoutPanel6.Controls.Add(this.RemoveCircuit, 2, 0);
			this.tableLayoutPanel6.Controls.Add(this.AddSegment, 3, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(8, 302);
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(331, 32);
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
			this.AddCircuit.Size = new System.Drawing.Size(78, 28);
			this.AddCircuit.TabIndex = 0;
			this.AddCircuit.Text = "Add";
			this.AddCircuit.UseVisualStyleBackColor = true;
			this.AddCircuit.Click += new System.EventHandler(this.AddCircuit_Click);
			// 
			// EditCircuit
			// 
			this.EditCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EditCircuit.Location = new System.Drawing.Point(84, 2);
			this.EditCircuit.Margin = new System.Windows.Forms.Padding(2);
			this.EditCircuit.Name = "EditCircuit";
			this.EditCircuit.Size = new System.Drawing.Size(78, 28);
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
			this.RemoveCircuit.Location = new System.Drawing.Point(166, 2);
			this.RemoveCircuit.Margin = new System.Windows.Forms.Padding(2);
			this.RemoveCircuit.Name = "RemoveCircuit";
			this.RemoveCircuit.Size = new System.Drawing.Size(78, 28);
			this.RemoveCircuit.TabIndex = 2;
			this.RemoveCircuit.Text = "Remove";
			this.RemoveCircuit.UseVisualStyleBackColor = true;
			this.RemoveCircuit.Click += new System.EventHandler(this.RemoveCircuit_Click);
			// 
			// AddSegment
			// 
			this.AddSegment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddSegment.Location = new System.Drawing.Point(248, 2);
			this.AddSegment.Margin = new System.Windows.Forms.Padding(2);
			this.AddSegment.Name = "AddSegment";
			this.AddSegment.Size = new System.Drawing.Size(81, 28);
			this.AddSegment.TabIndex = 3;
			this.AddSegment.Text = "Add Segment";
			this.AddSegment.UseVisualStyleBackColor = true;
			this.AddSegment.Click += new System.EventHandler(this.AddSegment_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.CircuitsComboBox, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.ElementsTreeView, 0, 1);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(8, 13);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.084469F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.91553F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(331, 287);
			this.tableLayoutPanel4.TabIndex = 13;
			// 
			// CircuitsComboBox
			// 
			this.CircuitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CircuitsComboBox.FormattingEnabled = true;
			this.CircuitsComboBox.Location = new System.Drawing.Point(3, 3);
			this.CircuitsComboBox.Name = "CircuitsComboBox";
			this.CircuitsComboBox.Size = new System.Drawing.Size(325, 21);
			this.CircuitsComboBox.TabIndex = 12;
			this.CircuitsComboBox.SelectedIndexChanged += new System.EventHandler(this.CircuitsComboBox_SelectedIndexChanged);
			// 
			// ElementsTreeView
			// 
			this.ElementsTreeView.AllowDrop = true;
			this.ElementsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ElementsTreeView.ContextMenuStrip = this.CircuitContextMenuStrip;
			this.ElementsTreeView.Location = new System.Drawing.Point(3, 23);
			this.ElementsTreeView.Name = "ElementsTreeView";
			this.ElementsTreeView.Size = new System.Drawing.Size(325, 261);
			this.ElementsTreeView.TabIndex = 11;
			this.ElementsTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ElementsTreeView_ItemDrag);
			this.ElementsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ElementsTreeView_AfterSelect);
			this.ElementsTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ElementsTreeView_DragDrop);
			this.ElementsTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ElementsTreeView_DragEnter);
			// 
			// CircuitContextMenuStrip
			// 
			this.CircuitContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addParallelSegmentToolStripMenuItem,
            this.addSerialSegmentToolStripMenuItem,
            this.addElementToolStripMenuItem,
            this.removeToolStripMenuItem});
			this.CircuitContextMenuStrip.Name = "CircuitContextMenuStrip";
			this.CircuitContextMenuStrip.Size = new System.Drawing.Size(143, 92);
			// 
			// addParallelSegmentToolStripMenuItem
			// 
			this.addParallelSegmentToolStripMenuItem.Name = "addParallelSegmentToolStripMenuItem";
			this.addParallelSegmentToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			// 
			// addSerialSegmentToolStripMenuItem
			// 
			this.addSerialSegmentToolStripMenuItem.Name = "addSerialSegmentToolStripMenuItem";
			this.addSerialSegmentToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			// 
			// addElementToolStripMenuItem
			// 
			this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
			this.addElementToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.addElementToolStripMenuItem.Text = "Add element";
			this.addElementToolStripMenuItem.Click += new System.EventHandler(this.AddElementButton_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveElementButton_Click);
			// 
			// CircuitGroupBox
			// 
			this.CircuitGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.CircuitGroupBox.Controls.Add(this.tableLayoutPanel6);
			this.CircuitGroupBox.Controls.Add(this.tableLayoutPanel4);
			this.CircuitGroupBox.Location = new System.Drawing.Point(12, 12);
			this.CircuitGroupBox.Name = "CircuitGroupBox";
			this.CircuitGroupBox.Size = new System.Drawing.Size(350, 337);
			this.CircuitGroupBox.TabIndex = 14;
			this.CircuitGroupBox.TabStop = false;
			this.CircuitGroupBox.Text = "Circuit";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.EventLabel, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 497);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 68);
			this.tableLayoutPanel1.TabIndex = 15;
			// 
			// ImpedancesDataGridView
			// 
			this.ImpedancesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.ImpedancesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ImpedancesDataGridView.Location = new System.Drawing.Point(6, 19);
			this.ImpedancesDataGridView.Name = "ImpedancesDataGridView";
			this.ImpedancesDataGridView.Size = new System.Drawing.Size(678, 142);
			this.ImpedancesDataGridView.TabIndex = 16;
			this.ImpedancesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ImpedancesDataGridView_CellEndEdit);
			// 
			// ImpedancesGroupBox
			// 
			this.ImpedancesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImpedancesGroupBox.Controls.Add(this.tableLayoutPanel2);
			this.ImpedancesGroupBox.Controls.Add(this.ImpedancesDataGridView);
			this.ImpedancesGroupBox.Location = new System.Drawing.Point(423, 357);
			this.ImpedancesGroupBox.Name = "ImpedancesGroupBox";
			this.ImpedancesGroupBox.Size = new System.Drawing.Size(699, 208);
			this.ImpedancesGroupBox.TabIndex = 17;
			this.ImpedancesGroupBox.TabStop = false;
			this.ImpedancesGroupBox.Text = "Impedances";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.18787F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61252F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.00391F));
			this.tableLayoutPanel2.Controls.Add(this.AddFrequencyButton, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.RemoveFrequencyButton, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(200, 167);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(493, 35);
			this.tableLayoutPanel2.TabIndex = 17;
			// 
			// AddFrequencyButton
			// 
			this.AddFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.AddFrequencyButton.Location = new System.Drawing.Point(320, 4);
			this.AddFrequencyButton.Name = "AddFrequencyButton";
			this.AddFrequencyButton.Size = new System.Drawing.Size(80, 28);
			this.AddFrequencyButton.TabIndex = 18;
			this.AddFrequencyButton.Text = "Add";
			this.AddFrequencyButton.UseVisualStyleBackColor = true;
			this.AddFrequencyButton.Click += new System.EventHandler(this.AddFrequenciesButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1134, 577);
			this.Controls.Add(this.tableLayoutPanel8);
			this.Controls.Add(this.ImpedancesGroupBox);
			this.Controls.Add(this.ElementGroupBox);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.CircuitGroupBox);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MinimumSize = new System.Drawing.Size(1150, 39);
			this.Name = "MainForm";
			this.Text = "ImpedanceApp";
			this.Load += new System.EventHandler(this.Main_Load);
			this.ElementGroupBox.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.tableLayoutPanel9.ResumeLayout(false);
			this.tableLayoutPanel9.PerformLayout();
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.CircuitContextMenuStrip.ResumeLayout(false);
			this.CircuitGroupBox.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImpedancesDataGridView)).EndInit();
			this.ImpedancesGroupBox.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Button AddCircuit;
		private System.Windows.Forms.Button EditCircuit;
		private System.Windows.Forms.Button RemoveCircuit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ComboBox CircuitsComboBox;
		private System.Windows.Forms.TreeView ElementsTreeView;
		private System.Windows.Forms.GroupBox ElementGroupBox;
		private System.Windows.Forms.Button RemoveElementButton;
		private System.Windows.Forms.Button EditElementButton;
		private System.Windows.Forms.TextBox ValueTextBox;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.Label ValueLabel;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Button RemoveFrequencyButton;
		private System.Windows.Forms.TextBox FrequencyTextBox;
		private System.Windows.Forms.Label FrequencyLabel;
		private System.Windows.Forms.Label EventLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.Button AddElementButton;
		private System.Windows.Forms.ComboBox TypeComboBox;
		private System.Windows.Forms.Label TypeLabel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.GroupBox CircuitGroupBox;
		private System.Windows.Forms.ContextMenuStrip CircuitContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addParallelSegmentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addSerialSegmentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addElementToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.Button AddSegment;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView ImpedancesDataGridView;
		private System.Windows.Forms.GroupBox ImpedancesGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button AddFrequencyButton;
	}
}

