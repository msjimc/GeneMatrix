using System;

namespace GeneMatrix
{
    partial class PartitionFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartitionFinder));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.cboExtension = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCreateConfigFile = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cblCodingSequences = new System.Windows.Forms.CheckedListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBlockSelect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSchemes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rdoProtein = new System.Windows.Forms.RadioButton();
            this.rdoDNA = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rboUnlinked = new System.Windows.Forms.RadioButton();
            this.rboLinked = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAlignmentFile = new System.Windows.Forms.TextBox();
            this.btnAlignmentFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboSelectionModel = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.cboExtension);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Phylip file";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(488, 63);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(366, 68);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(44, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Count: -";
            // 
            // cboExtension
            // 
            this.cboExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboExtension.FormattingEnabled = true;
            this.cboExtension.Items.AddRange(new object[] {
            "Select",
            "*.fasta",
            "*.fa",
            "*.fas",
            "*.fna",
            "*.txt"});
            this.cboExtension.Location = new System.Drawing.Point(90, 65);
            this.cboExtension.Name = "cboExtension";
            this.cboExtension.Size = new System.Drawing.Size(270, 21);
            this.cboExtension.TabIndex = 2;
            this.cboExtension.SelectedIndexChanged += new System.EventHandler(this.cboExtension_SelectedIndexChanged);
            this.cboExtension.TextChanged += new System.EventHandler(this.cboExtension_TextChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(9, 63);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Folder";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cboSelectionModel);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.btnCreateConfigFile);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cblCodingSequences);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnBlockSelect);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboSchemes);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboModel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAlignmentFile);
            this.groupBox2.Controls.Add(this.btnAlignmentFile);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(569, 361);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PartitionFinder2 config file creation";
            // 
            // btnCreateConfigFile
            // 
            this.btnCreateConfigFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateConfigFile.Enabled = false;
            this.btnCreateConfigFile.Location = new System.Drawing.Point(488, 332);
            this.btnCreateConfigFile.Name = "btnCreateConfigFile";
            this.btnCreateConfigFile.Size = new System.Drawing.Size(75, 23);
            this.btnCreateConfigFile.TabIndex = 24;
            this.btnCreateConfigFile.Text = "Create";
            this.btnCreateConfigFile.UseVisualStyleBackColor = true;
            this.btnCreateConfigFile.Click += new System.EventHandler(this.btnCreateConfigFile_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(211, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Create the partitionFinder2 configuration file";
            // 
            // cblCodingSequences
            // 
            this.cblCodingSequences.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblCodingSequences.CheckOnClick = true;
            this.cblCodingSequences.FormattingEnabled = true;
            this.cblCodingSequences.Location = new System.Drawing.Point(236, 233);
            this.cblCodingSequences.Name = "cblCodingSequences";
            this.cblCodingSequences.Size = new System.Drawing.Size(327, 94);
            this.cblCodingSequences.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(233, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Select coding sequences";
            // 
            // btnBlockSelect
            // 
            this.btnBlockSelect.Location = new System.Drawing.Point(155, 209);
            this.btnBlockSelect.Name = "btnBlockSelect";
            this.btnBlockSelect.Size = new System.Drawing.Size(75, 23);
            this.btnBlockSelect.TabIndex = 20;
            this.btnBlockSelect.Text = "Select";
            this.btnBlockSelect.UseVisualStyleBackColor = true;
            this.btnBlockSelect.Click += new System.EventHandler(this.btnBlockSelect_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 36);
            this.label7.TabIndex = 19;
            this.label7.Text = "Blocks data (Select the Block file created above)";
            // 
            // cboSchemes
            // 
            this.cboSchemes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSchemes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchemes.FormattingEnabled = true;
            this.cboSchemes.Items.AddRange(new object[] {
            "Select",
            "All",
            "User",
            "Greedy",
            "R-Cluster",
            "R-Cluster-F",
            "H-Cluster",
            "K-means"});
            this.cboSchemes.Location = new System.Drawing.Point(236, 155);
            this.cboSchemes.Name = "cboSchemes";
            this.cboSchemes.Size = new System.Drawing.Size(327, 21);
            this.cboSchemes.TabIndex = 18;
            this.cboSchemes.SelectedIndexChanged += new System.EventHandler(this.cboSchemes_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Schemes";
            // 
            // checkBox6
            // 
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(500, 132);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(66, 17);
            this.checkBox6.TabIndex = 16;
            this.checkBox6.Text = "GTR+G";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(432, 132);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(66, 17);
            this.checkBox5.TabIndex = 15;
            this.checkBox5.Text = "WAG+G";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(360, 132);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 17);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.Text = "HKY+G";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(288, 132);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "LG+G+F";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(218, 132);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(52, 17);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "JC+G";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(155, 132);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(38, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "JC";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // rdoProtein
            // 
            this.rdoProtein.AutoSize = true;
            this.rdoProtein.Enabled = false;
            this.rdoProtein.Location = new System.Drawing.Point(205, 5);
            this.rdoProtein.Name = "rdoProtein";
            this.rdoProtein.Size = new System.Drawing.Size(127, 17);
            this.rdoProtein.TabIndex = 10;
            this.rdoProtein.Text = "Amino acid sequence";
            this.rdoProtein.UseVisualStyleBackColor = true;
            this.rdoProtein.CheckedChanged += new System.EventHandler(this.rdoDNA_Protein_CheckedChanged);
            // 
            // rdoDNA
            // 
            this.rdoDNA.AutoSize = true;
            this.rdoDNA.Enabled = false;
            this.rdoDNA.Location = new System.Drawing.Point(3, 5);
            this.rdoDNA.Name = "rdoDNA";
            this.rdoDNA.Size = new System.Drawing.Size(126, 17);
            this.rdoDNA.TabIndex = 9;
            this.rdoDNA.Text = "Nucleotide sequence";
            this.rdoDNA.UseVisualStyleBackColor = true;
            this.rdoDNA.CheckedChanged += new System.EventHandler(this.rdoDNA_Protein_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Model list options";
            // 
            // cboModel
            // 
            this.cboModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Items.AddRange(new object[] {
            "Select",
            "All",
            "Allx",
            "Beast",
            "MrBayes",
            "Gamma",
            "Gammai",
            "List"});
            this.cboModel.Location = new System.Drawing.Point(155, 77);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(408, 21);
            this.cboModel.TabIndex = 7;
            this.cboModel.SelectedIndexChanged += new System.EventHandler(this.cboModel_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Model of evolution";
            // 
            // rboUnlinked
            // 
            this.rboUnlinked.AutoSize = true;
            this.rboUnlinked.Location = new System.Drawing.Point(205, 1);
            this.rboUnlinked.Name = "rboUnlinked";
            this.rboUnlinked.Size = new System.Drawing.Size(154, 17);
            this.rboUnlinked.TabIndex = 5;
            this.rboUnlinked.Text = "Unlinked (individual values)";
            this.rboUnlinked.UseVisualStyleBackColor = true;
            this.rboUnlinked.CheckedChanged += new System.EventHandler(this.rboLinked_unlinked_CheckedChanged);
            // 
            // rboLinked
            // 
            this.rboLinked.AutoSize = true;
            this.rboLinked.Location = new System.Drawing.Point(3, 1);
            this.rboLinked.Name = "rboLinked";
            this.rboLinked.Size = new System.Drawing.Size(154, 17);
            this.rboLinked.TabIndex = 4;
            this.rboLinked.Text = "Linked (universal value set)";
            this.rboLinked.UseVisualStyleBackColor = true;
            this.rboLinked.CheckedChanged += new System.EventHandler(this.rboLinked_unlinked_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Branch lengths";
            // 
            // txtAlignmentFile
            // 
            this.txtAlignmentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlignmentFile.Location = new System.Drawing.Point(236, 23);
            this.txtAlignmentFile.Name = "txtAlignmentFile";
            this.txtAlignmentFile.Size = new System.Drawing.Size(327, 20);
            this.txtAlignmentFile.TabIndex = 2;
            this.txtAlignmentFile.TextChanged += new System.EventHandler(this.txtAlignmentFile_TextChanged);
            // 
            // btnAlignmentFile
            // 
            this.btnAlignmentFile.Location = new System.Drawing.Point(155, 23);
            this.btnAlignmentFile.Name = "btnAlignmentFile";
            this.btnAlignmentFile.Size = new System.Drawing.Size(75, 23);
            this.btnAlignmentFile.TabIndex = 1;
            this.btnAlignmentFile.Text = "Select";
            this.btnAlignmentFile.UseVisualStyleBackColor = true;
            this.btnAlignmentFile.Click += new System.EventHandler(this.btnAlignmentFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phylip formated alignment file";
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuit.Location = new System.Drawing.Point(12, 481);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Close";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rboLinked);
            this.panel1.Controls.Add(this.rboUnlinked);
            this.panel1.Location = new System.Drawing.Point(155, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 22);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.rdoProtein);
            this.panel2.Controls.Add(this.rdoDNA);
            this.panel2.Location = new System.Drawing.Point(155, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 24);
            this.panel2.TabIndex = 26;
            // 
            // cboSelectionModel
            // 
            this.cboSelectionModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectionModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectionModel.FormattingEnabled = true;
            this.cboSelectionModel.Items.AddRange(new object[] {
            "Select",
            "AIC",
            "AICc",
            "BIC "});
            this.cboSelectionModel.Location = new System.Drawing.Point(236, 182);
            this.cboSelectionModel.Name = "cboSelectionModel";
            this.cboSelectionModel.Size = new System.Drawing.Size(327, 21);
            this.cboSelectionModel.TabIndex = 28;
            this.cboSelectionModel.SelectedIndexChanged += new System.EventHandler(this.cboSelectionModel_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Model of selection";
            // 
            // PartitionFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 516);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PartitionFinder";
            this.Text = "PartitionFinder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cboExtension;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox txtAlignmentFile;
        private System.Windows.Forms.Button btnAlignmentFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rboUnlinked;
        private System.Windows.Forms.RadioButton rboLinked;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton rdoProtein;
        private System.Windows.Forms.RadioButton rdoDNA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSchemes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox cblCodingSequences;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBlockSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCreateConfigFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboSelectionModel;
        private System.Windows.Forms.Label label10;
    }
}