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
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.RemoveElementButton = new System.Windows.Forms.Button();
			this.EditElementButton = new System.Windows.Forms.Button();
			this.AddElementButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.NameLabel = new System.Windows.Forms.Label();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.TypeComboBox = new System.Windows.Forms.ComboBox();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.ValueTextBox = new System.Windows.Forms.TextBox();
			this.EventLabel = new System.Windows.Forms.Label();
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
			this.addElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CircuitGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ImpedancesDataGridView = new System.Windows.Forms.DataGridView();
			this.ImpedancesGroupBox = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.AddFrequencyButton = new System.Windows.Forms.Button();
			this.CircuitPictureGroupBox = new System.Windows.Forms.GroupBox();
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.ElementGroupBox.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
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
			this.CircuitPictureGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// ElementGroupBox
			// 
			this.ElementGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ElementGroupBox.Controls.Add(this.tableLayoutPanel3);
			this.ElementGroupBox.Controls.Add(this.tableLayoutPanel5);
			this.ElementGroupBox.Location = new System.Drawing.Point(16, 564);
			this.ElementGroupBox.Margin = new System.Windows.Forms.Padding(4);
			this.ElementGroupBox.Name = "ElementGroupBox";
			this.ElementGroupBox.Padding = new System.Windows.Forms.Padding(4);
			this.ElementGroupBox.Size = new System.Drawing.Size(540, 203);
			this.ElementGroupBox.TabIndex = 13;
			this.ElementGroupBox.TabStop = false;
			this.ElementGroupBox.Text = "Current Element";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel3.Controls.Add(this.RemoveElementButton, 2, 0);
			this.tableLayoutPanel3.Controls.Add(this.EditElementButton, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.AddElementButton, 0, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(383, 150);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(149, 46);
			this.tableLayoutPanel3.TabIndex = 18;
			// 
			// RemoveElementButton
			// 
			this.RemoveElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveElementButton.BackgroundImage = global::ImpedanceApp.Properties.Resources.remove;
			this.RemoveElementButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.RemoveElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RemoveElementButton.ForeColor = System.Drawing.SystemColors.Control;
			this.RemoveElementButton.Location = new System.Drawing.Point(102, 4);
			this.RemoveElementButton.Margin = new System.Windows.Forms.Padding(4);
			this.RemoveElementButton.Name = "RemoveElementButton";
			this.RemoveElementButton.Size = new System.Drawing.Size(43, 38);
			this.RemoveElementButton.TabIndex = 9;
			this.RemoveElementButton.UseVisualStyleBackColor = true;
			this.RemoveElementButton.Click += new System.EventHandler(this.RemoveElementButton_Click);
			// 
			// EditElementButton
			// 
			this.EditElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EditElementButton.BackgroundImage = global::ImpedanceApp.Properties.Resources.edit1;
			this.EditElementButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.EditElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EditElementButton.ForeColor = System.Drawing.SystemColors.Control;
			this.EditElementButton.Location = new System.Drawing.Point(53, 4);
			this.EditElementButton.Margin = new System.Windows.Forms.Padding(4);
			this.EditElementButton.Name = "EditElementButton";
			this.EditElementButton.Size = new System.Drawing.Size(41, 38);
			this.EditElementButton.TabIndex = 8;
			this.EditElementButton.UseVisualStyleBackColor = true;
			this.EditElementButton.Click += new System.EventHandler(this.EditElementButton_Click);
			// 
			// AddElementButton
			// 
			this.AddElementButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddElementButton.BackgroundImage = global::ImpedanceApp.Properties.Resources.add;
			this.AddElementButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AddElementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddElementButton.ForeColor = System.Drawing.SystemColors.Control;
			this.AddElementButton.Location = new System.Drawing.Point(4, 4);
			this.AddElementButton.Margin = new System.Windows.Forms.Padding(4);
			this.AddElementButton.Name = "AddElementButton";
			this.AddElementButton.Size = new System.Drawing.Size(41, 38);
			this.AddElementButton.TabIndex = 7;
			this.AddElementButton.UseVisualStyleBackColor = true;
			this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.ColumnCount = 2;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.82796F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.8855F));
			this.tableLayoutPanel5.Controls.Add(this.NameLabel, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.ValueLabel, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.TypeComboBox, 1, 2);
			this.tableLayoutPanel5.Controls.Add(this.TypeLabel, 0, 2);
			this.tableLayoutPanel5.Controls.Add(this.NameTextBox, 1, 0);
			this.tableLayoutPanel5.Controls.Add(this.ValueTextBox, 1, 1);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(8, 23);
			this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 3;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(524, 128);
			this.tableLayoutPanel5.TabIndex = 14;
			// 
			// NameLabel
			// 
			this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(27, 0);
			this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(49, 42);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Name:";
			this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ValueLabel
			// 
			this.ValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ValueLabel.AutoSize = true;
			this.ValueLabel.Location = new System.Drawing.Point(28, 42);
			this.ValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ValueLabel.Name = "ValueLabel";
			this.ValueLabel.Size = new System.Drawing.Size(48, 42);
			this.ValueLabel.TabIndex = 1;
			this.ValueLabel.Text = "Value:";
			this.ValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// TypeComboBox
			// 
			this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TypeComboBox.FormattingEnabled = true;
			this.TypeComboBox.Location = new System.Drawing.Point(84, 93);
			this.TypeComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.TypeComboBox.Name = "TypeComboBox";
			this.TypeComboBox.Size = new System.Drawing.Size(436, 24);
			this.TypeComboBox.TabIndex = 10;
			// 
			// TypeLabel
			// 
			this.TypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TypeLabel.AutoSize = true;
			this.TypeLabel.Location = new System.Drawing.Point(32, 84);
			this.TypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.TypeLabel.Name = "TypeLabel";
			this.TypeLabel.Size = new System.Drawing.Size(44, 44);
			this.TypeLabel.TabIndex = 2;
			this.TypeLabel.Text = "Type:";
			this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.NameTextBox.Location = new System.Drawing.Point(84, 10);
			this.NameTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(436, 22);
			this.NameTextBox.TabIndex = 3;
			// 
			// ValueTextBox
			// 
			this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.ValueTextBox.Location = new System.Drawing.Point(84, 52);
			this.ValueTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.Size = new System.Drawing.Size(436, 22);
			this.ValueTextBox.TabIndex = 4;
			// 
			// EventLabel
			// 
			this.EventLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.EventLabel.AutoSize = true;
			this.EventLabel.Location = new System.Drawing.Point(4, 14);
			this.EventLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.EventLabel.Name = "EventLabel";
			this.EventLabel.Size = new System.Drawing.Size(46, 17);
			this.EventLabel.TabIndex = 9;
			this.EventLabel.Text = "label1";
			this.EventLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RemoveFrequencyButton
			// 
			this.RemoveFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveFrequencyButton.BackgroundImage = global::ImpedanceApp.Properties.Resources.remove;
			this.RemoveFrequencyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.RemoveFrequencyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RemoveFrequencyButton.ForeColor = System.Drawing.SystemColors.Control;
			this.RemoveFrequencyButton.Location = new System.Drawing.Point(624, 4);
			this.RemoveFrequencyButton.Margin = new System.Windows.Forms.Padding(4);
			this.RemoveFrequencyButton.Name = "RemoveFrequencyButton";
			this.RemoveFrequencyButton.Size = new System.Drawing.Size(41, 38);
			this.RemoveFrequencyButton.TabIndex = 17;
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
			this.tableLayoutPanel9.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel9.Name = "tableLayoutPanel9";
			this.tableLayoutPanel9.RowCount = 1;
			this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel9.Size = new System.Drawing.Size(563, 38);
			this.tableLayoutPanel9.TabIndex = 0;
			// 
			// FrequencyTextBox
			// 
			this.FrequencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.FrequencyTextBox.Location = new System.Drawing.Point(125, 8);
			this.FrequencyTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.FrequencyTextBox.Name = "FrequencyTextBox";
			this.FrequencyTextBox.Size = new System.Drawing.Size(434, 22);
			this.FrequencyTextBox.TabIndex = 15;
			// 
			// FrequencyLabel
			// 
			this.FrequencyLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.FrequencyLabel.AutoSize = true;
			this.FrequencyLabel.Location = new System.Drawing.Point(38, 10);
			this.FrequencyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.FrequencyLabel.Name = "FrequencyLabel";
			this.FrequencyLabel.Size = new System.Drawing.Size(79, 17);
			this.FrequencyLabel.TabIndex = 14;
			this.FrequencyLabel.Text = "Frequency:";
			this.FrequencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.ColumnCount = 4;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.99813F));
			this.tableLayoutPanel6.Controls.Add(this.AddCircuit, 0, 0);
			this.tableLayoutPanel6.Controls.Add(this.EditCircuit, 1, 0);
			this.tableLayoutPanel6.Controls.Add(this.RemoveCircuit, 2, 0);
			this.tableLayoutPanel6.Controls.Add(this.AddSegment, 3, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(263, 35);
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(187, 43);
			this.tableLayoutPanel6.TabIndex = 12;
			// 
			// AddCircuit
			// 
			this.AddCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddCircuit.BackgroundImage = global::ImpedanceApp.Properties.Resources.add;
			this.AddCircuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AddCircuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddCircuit.ForeColor = System.Drawing.SystemColors.Control;
			this.AddCircuit.Location = new System.Drawing.Point(3, 2);
			this.AddCircuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.AddCircuit.Name = "AddCircuit";
			this.AddCircuit.Size = new System.Drawing.Size(40, 39);
			this.AddCircuit.TabIndex = 0;
			this.AddCircuit.UseVisualStyleBackColor = true;
			this.AddCircuit.Click += new System.EventHandler(this.AddCircuit_Click);
			// 
			// EditCircuit
			// 
			this.EditCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EditCircuit.BackgroundImage = global::ImpedanceApp.Properties.Resources.edit1;
			this.EditCircuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.EditCircuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EditCircuit.ForeColor = System.Drawing.SystemColors.Control;
			this.EditCircuit.Location = new System.Drawing.Point(49, 2);
			this.EditCircuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.EditCircuit.Name = "EditCircuit";
			this.EditCircuit.Size = new System.Drawing.Size(40, 39);
			this.EditCircuit.TabIndex = 1;
			this.EditCircuit.UseVisualStyleBackColor = true;
			this.EditCircuit.Click += new System.EventHandler(this.EditCircuit_Click);
			// 
			// RemoveCircuit
			// 
			this.RemoveCircuit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveCircuit.BackgroundImage = global::ImpedanceApp.Properties.Resources.remove;
			this.RemoveCircuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.RemoveCircuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.RemoveCircuit.ForeColor = System.Drawing.SystemColors.Control;
			this.RemoveCircuit.Location = new System.Drawing.Point(95, 2);
			this.RemoveCircuit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RemoveCircuit.Name = "RemoveCircuit";
			this.RemoveCircuit.Size = new System.Drawing.Size(40, 39);
			this.RemoveCircuit.TabIndex = 2;
			this.RemoveCircuit.UseVisualStyleBackColor = true;
			this.RemoveCircuit.Click += new System.EventHandler(this.RemoveCircuit_Click);
			// 
			// AddSegment
			// 
			this.AddSegment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddSegment.BackgroundImage = global::ImpedanceApp.Properties.Resources.AddCircuit;
			this.AddSegment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AddSegment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddSegment.ForeColor = System.Drawing.SystemColors.Control;
			this.AddSegment.Location = new System.Drawing.Point(141, 2);
			this.AddSegment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.AddSegment.Name = "AddSegment";
			this.AddSegment.Size = new System.Drawing.Size(43, 39);
			this.AddSegment.TabIndex = 3;
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
			this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.CircuitsComboBox, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.ElementsTreeView, 0, 2);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(7, 16);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 3;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(453, 519);
			this.tableLayoutPanel4.TabIndex = 13;
			// 
			// CircuitsComboBox
			// 
			this.CircuitsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CircuitsComboBox.FormattingEnabled = true;
			this.CircuitsComboBox.Location = new System.Drawing.Point(4, 4);
			this.CircuitsComboBox.Margin = new System.Windows.Forms.Padding(4);
			this.CircuitsComboBox.Name = "CircuitsComboBox";
			this.CircuitsComboBox.Size = new System.Drawing.Size(445, 24);
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
			this.ElementsTreeView.Location = new System.Drawing.Point(4, 84);
			this.ElementsTreeView.Margin = new System.Windows.Forms.Padding(4);
			this.ElementsTreeView.Name = "ElementsTreeView";
			this.ElementsTreeView.Size = new System.Drawing.Size(445, 431);
			this.ElementsTreeView.TabIndex = 11;
			this.ElementsTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.ElementsTreeView_ItemDrag);
			this.ElementsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ElementsTreeView_AfterSelect);
			this.ElementsTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ElementsTreeView_DragDrop);
			this.ElementsTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.ElementsTreeView_DragEnter);
			// 
			// CircuitContextMenuStrip
			// 
			this.CircuitContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.CircuitContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addElementToolStripMenuItem,
            this.removeToolStripMenuItem});
			this.CircuitContextMenuStrip.Name = "CircuitContextMenuStrip";
			this.CircuitContextMenuStrip.Size = new System.Drawing.Size(165, 52);
			// 
			// addElementToolStripMenuItem
			// 
			this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
			this.addElementToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
			this.addElementToolStripMenuItem.Text = "Add element";
			this.addElementToolStripMenuItem.Click += new System.EventHandler(this.AddElementButton_Click);
			// 
			// removeToolStripMenuItem
			// 
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveElementButton_Click);
			// 
			// CircuitGroupBox
			// 
			this.CircuitGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.CircuitGroupBox.Controls.Add(this.tableLayoutPanel4);
			this.CircuitGroupBox.Location = new System.Drawing.Point(16, 15);
			this.CircuitGroupBox.Margin = new System.Windows.Forms.Padding(4);
			this.CircuitGroupBox.Name = "CircuitGroupBox";
			this.CircuitGroupBox.Padding = new System.Windows.Forms.Padding(4);
			this.CircuitGroupBox.Size = new System.Drawing.Size(467, 542);
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 774);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 46);
			this.tableLayoutPanel1.TabIndex = 15;
			// 
			// ImpedancesDataGridView
			// 
			this.ImpedancesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImpedancesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.ImpedancesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ImpedancesDataGridView.Location = new System.Drawing.Point(8, 23);
			this.ImpedancesDataGridView.Margin = new System.Windows.Forms.Padding(4);
			this.ImpedancesDataGridView.Name = "ImpedancesDataGridView";
			this.ImpedancesDataGridView.RowHeadersWidth = 51;
			this.ImpedancesDataGridView.Size = new System.Drawing.Size(916, 175);
			this.ImpedancesDataGridView.TabIndex = 16;
			this.ImpedancesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ImpedancesDataGridView_CellEndEdit);
			// 
			// ImpedancesGroupBox
			// 
			this.ImpedancesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ImpedancesGroupBox.Controls.Add(this.tableLayoutPanel2);
			this.ImpedancesGroupBox.Controls.Add(this.ImpedancesDataGridView);
			this.ImpedancesGroupBox.Location = new System.Drawing.Point(564, 564);
			this.ImpedancesGroupBox.Margin = new System.Windows.Forms.Padding(4);
			this.ImpedancesGroupBox.Name = "ImpedancesGroupBox";
			this.ImpedancesGroupBox.Padding = new System.Windows.Forms.Padding(4);
			this.ImpedancesGroupBox.Size = new System.Drawing.Size(932, 256);
			this.ImpedancesGroupBox.TabIndex = 17;
			this.ImpedancesGroupBox.TabStop = false;
			this.ImpedancesGroupBox.Text = "Impedances";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
			this.tableLayoutPanel2.Controls.Add(this.AddFrequencyButton, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.RemoveFrequencyButton, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel9, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(255, 206);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(669, 46);
			this.tableLayoutPanel2.TabIndex = 17;
			// 
			// AddFrequencyButton
			// 
			this.AddFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AddFrequencyButton.BackgroundImage = global::ImpedanceApp.Properties.Resources.add;
			this.AddFrequencyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.AddFrequencyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.AddFrequencyButton.ForeColor = System.Drawing.SystemColors.Control;
			this.AddFrequencyButton.Location = new System.Drawing.Point(575, 4);
			this.AddFrequencyButton.Margin = new System.Windows.Forms.Padding(4);
			this.AddFrequencyButton.Name = "AddFrequencyButton";
			this.AddFrequencyButton.Size = new System.Drawing.Size(41, 38);
			this.AddFrequencyButton.TabIndex = 18;
			this.AddFrequencyButton.UseVisualStyleBackColor = true;
			this.AddFrequencyButton.Click += new System.EventHandler(this.AddFrequenciesButton_Click);
			// 
			// CircuitPictureGroupBox
			// 
			this.CircuitPictureGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitPictureGroupBox.Controls.Add(this.CircuitPictureBox);
			this.CircuitPictureGroupBox.Location = new System.Drawing.Point(491, 15);
			this.CircuitPictureGroupBox.Margin = new System.Windows.Forms.Padding(4);
			this.CircuitPictureGroupBox.Name = "CircuitPictureGroupBox";
			this.CircuitPictureGroupBox.Padding = new System.Windows.Forms.Padding(4);
			this.CircuitPictureGroupBox.Size = new System.Drawing.Size(1005, 542);
			this.CircuitPictureGroupBox.TabIndex = 18;
			this.CircuitPictureGroupBox.TabStop = false;
			this.CircuitPictureGroupBox.Text = "Circuit Picture";
			// 
			// CircuitPictureBox
			// 
			this.CircuitPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitPictureBox.Location = new System.Drawing.Point(8, 23);
			this.CircuitPictureBox.Margin = new System.Windows.Forms.Padding(4);
			this.CircuitPictureBox.Name = "CircuitPictureBox";
			this.CircuitPictureBox.Size = new System.Drawing.Size(742, 415);
			this.CircuitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.CircuitPictureBox.TabIndex = 0;
			this.CircuitPictureBox.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1512, 834);
			this.Controls.Add(this.CircuitPictureGroupBox);
			this.Controls.Add(this.ImpedancesGroupBox);
			this.Controls.Add(this.ElementGroupBox);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.CircuitGroupBox);
			this.Icon = global::ImpedanceApp.Properties.Resources.Circuit;
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.MinimumSize = new System.Drawing.Size(1525, 744);
			this.Name = "MainForm";
			this.Text = "ImpedanceApp";
			this.Load += new System.EventHandler(this.Main_Load);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.ElementGroupBox.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
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
			this.CircuitPictureGroupBox.ResumeLayout(false);
			this.CircuitPictureGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.Button AddCircuit;
		private System.Windows.Forms.Button EditCircuit;
		private System.Windows.Forms.Button RemoveCircuit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ComboBox CircuitsComboBox;
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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
		private System.Windows.Forms.GroupBox CircuitGroupBox;
		private System.Windows.Forms.ContextMenuStrip CircuitContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem addElementToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
		private System.Windows.Forms.Button AddSegment;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView ImpedancesDataGridView;
		private System.Windows.Forms.GroupBox ImpedancesGroupBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button AddFrequencyButton;
		private System.Windows.Forms.TreeView ElementsTreeView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.GroupBox CircuitPictureGroupBox;
		private System.Windows.Forms.PictureBox CircuitPictureBox;
	}
}

