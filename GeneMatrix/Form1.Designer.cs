﻿namespace GeneMatrix
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataSource = new System.Windows.Forms.Label();
            this.chkFolder = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.btnBasicData = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnImportSteps = new System.Windows.Forms.Button();
            this.tv2 = new System.Windows.Forms.TreeView();
            this.btnSaveSteps = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkIgnoreEmptySequence = new System.Windows.Forms.CheckBox();
            this.rboBoth = new System.Windows.Forms.RadioButton();
            this.rboProtein = new System.Windows.Forms.RadioButton();
            this.rboDNA = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkGBlocks = new System.Windows.Forms.CheckBox();
            this.chkKeepCommandFile = new System.Windows.Forms.CheckBox();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnMAFFT = new System.Windows.Forms.Button();
            this.btnPrank = new System.Windows.Forms.Button();
            this.chkAggregate = new System.Windows.Forms.CheckBox();
            this.chkResetPrograms = new System.Windows.Forms.CheckBox();
            this.btnMuscle = new System.Windows.Forms.Button();
            this.chkShowCMD = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClustalW = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRunPartitionFinder = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMakePartitionFinderFiles = new System.Windows.Forms.Button();
            this.chkExtend = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkExtend);
            this.groupBox1.Controls.Add(this.lblDataSource);
            this.groupBox1.Controls.Add(this.chkFolder);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import data";
            // 
            // lblDataSource
            // 
            this.lblDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataSource.Location = new System.Drawing.Point(6, 64);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(431, 18);
            this.lblDataSource.TabIndex = 3;
            this.lblDataSource.Text = "Not set";
            // 
            // chkFolder
            // 
            this.chkFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFolder.AutoSize = true;
            this.chkFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFolder.Location = new System.Drawing.Point(533, 63);
            this.chkFolder.Name = "chkFolder";
            this.chkFolder.Size = new System.Drawing.Size(55, 17);
            this.chkFolder.TabIndex = 1;
            this.chkFolder.Text = "Folder";
            this.chkFolder.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(593, 59);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(662, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuit.Location = new System.Drawing.Point(12, 642);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 15;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 256);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Combine features with different names";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer1.Panel1.Controls.Add(this.btnCompare);
            this.splitContainer1.Panel1.Controls.Add(this.btnGroup);
            this.splitContainer1.Panel1.Controls.Add(this.tv1);
            this.splitContainer1.Panel1.Controls.Add(this.btnBasicData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnReset);
            this.splitContainer1.Panel2.Controls.Add(this.btnImportSteps);
            this.splitContainer1.Panel2.Controls.Add(this.tv2);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveSteps);
            this.splitContainer1.Size = new System.Drawing.Size(668, 234);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(243, 208);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCompare.Location = new System.Drawing.Point(162, 208);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 8;
            this.btnCompare.Text = "Homology";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGroup.Location = new System.Drawing.Point(81, 208);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(75, 23);
            this.btnGroup.TabIndex = 10;
            this.btnGroup.Text = "Groupings";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // tv1
            // 
            this.tv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv1.Location = new System.Drawing.Point(0, 0);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(322, 202);
            this.tv1.TabIndex = 3;
            this.tv1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv1_NodeMouseClick);
            // 
            // btnBasicData
            // 
            this.btnBasicData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBasicData.Location = new System.Drawing.Point(0, 208);
            this.btnBasicData.Name = "btnBasicData";
            this.btnBasicData.Size = new System.Drawing.Size(75, 23);
            this.btnBasicData.TabIndex = 9;
            this.btnBasicData.Text = "Sets";
            this.btnBasicData.UseVisualStyleBackColor = true;
            this.btnBasicData.Click += new System.EventHandler(this.btnBasicData_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(263, 208);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnImportSteps
            // 
            this.btnImportSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImportSteps.Enabled = false;
            this.btnImportSteps.Location = new System.Drawing.Point(84, 208);
            this.btnImportSteps.Name = "btnImportSteps";
            this.btnImportSteps.Size = new System.Drawing.Size(75, 23);
            this.btnImportSteps.TabIndex = 7;
            this.btnImportSteps.Text = "Import steps";
            this.btnImportSteps.UseVisualStyleBackColor = true;
            this.btnImportSteps.Click += new System.EventHandler(this.btnImportSteps_Click);
            // 
            // tv2
            // 
            this.tv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv2.Location = new System.Drawing.Point(0, 0);
            this.tv2.Name = "tv2";
            this.tv2.Size = new System.Drawing.Size(342, 202);
            this.tv2.TabIndex = 4;
            this.tv2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv2_AfterSelect);
            this.tv2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv2_NodeMouseClick);
            this.tv2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv2_MouseDown);
            // 
            // btnSaveSteps
            // 
            this.btnSaveSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSteps.Enabled = false;
            this.btnSaveSteps.Location = new System.Drawing.Point(3, 208);
            this.btnSaveSteps.Name = "btnSaveSteps";
            this.btnSaveSteps.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSteps.TabIndex = 6;
            this.btnSaveSteps.Text = "Save steps";
            this.btnSaveSteps.UseVisualStyleBackColor = true;
            this.btnSaveSteps.Click += new System.EventHandler(this.btnSaveSteps_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkIgnoreEmptySequence);
            this.groupBox3.Controls.Add(this.rboBoth);
            this.groupBox3.Controls.Add(this.rboProtein);
            this.groupBox3.Controls.Add(this.rboDNA);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(674, 72);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save sequences";
            // 
            // chkIgnoreEmptySequence
            // 
            this.chkIgnoreEmptySequence.AutoSize = true;
            this.chkIgnoreEmptySequence.Location = new System.Drawing.Point(424, 46);
            this.chkIgnoreEmptySequence.Name = "chkIgnoreEmptySequence";
            this.chkIgnoreEmptySequence.Size = new System.Drawing.Size(142, 17);
            this.chkIgnoreEmptySequence.TabIndex = 10;
            this.chkIgnoreEmptySequence.Text = "Ignore empty sequences";
            this.chkIgnoreEmptySequence.UseVisualStyleBackColor = true;
            // 
            // rboBoth
            // 
            this.rboBoth.AutoSize = true;
            this.rboBoth.Location = new System.Drawing.Point(280, 46);
            this.rboBoth.Name = "rboBoth";
            this.rboBoth.Size = new System.Drawing.Size(137, 17);
            this.rboBoth.TabIndex = 8;
            this.rboBoth.Text = "Both types of sequence";
            this.rboBoth.UseVisualStyleBackColor = true;
            // 
            // rboProtein
            // 
            this.rboProtein.AutoSize = true;
            this.rboProtein.Location = new System.Drawing.Point(140, 46);
            this.rboProtein.Name = "rboProtein";
            this.rboProtein.Size = new System.Drawing.Size(134, 17);
            this.rboProtein.TabIndex = 7;
            this.rboProtein.Text = "Just protein sequences";
            this.rboProtein.UseVisualStyleBackColor = true;
            // 
            // rboDNA
            // 
            this.rboDNA.AutoSize = true;
            this.rboDNA.Checked = true;
            this.rboDNA.Location = new System.Drawing.Point(9, 46);
            this.rboDNA.Name = "rboDNA";
            this.rboDNA.Size = new System.Drawing.Size(125, 17);
            this.rboDNA.TabIndex = 6;
            this.rboDNA.TabStop = true;
            this.rboDNA.Text = "Just DNA sequences";
            this.rboDNA.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(593, 43);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(566, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "To save the sequences, select whether you which to save DNA, protein or both type" +
    "s and then press the Save button.";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chkGBlocks);
            this.groupBox4.Controls.Add(this.chkKeepCommandFile);
            this.groupBox4.Controls.Add(this.btnModify);
            this.groupBox4.Controls.Add(this.btnAll);
            this.groupBox4.Controls.Add(this.btnMAFFT);
            this.groupBox4.Controls.Add(this.btnPrank);
            this.groupBox4.Controls.Add(this.chkAggregate);
            this.groupBox4.Controls.Add(this.chkResetPrograms);
            this.groupBox4.Controls.Add(this.btnMuscle);
            this.groupBox4.Controls.Add(this.chkShowCMD);
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnClustalW);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 450);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(674, 115);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Align individual features";
            // 
            // chkGBlocks
            // 
            this.chkGBlocks.AutoSize = true;
            this.chkGBlocks.Location = new System.Drawing.Point(533, 63);
            this.chkGBlocks.Name = "chkGBlocks";
            this.chkGBlocks.Size = new System.Drawing.Size(118, 17);
            this.chkGBlocks.TabIndex = 21;
            this.chkGBlocks.Text = "Clean with GBlocks";
            this.chkGBlocks.UseVisualStyleBackColor = true;
            this.chkGBlocks.CheckedChanged += new System.EventHandler(this.chkGBlocks_CheckedChanged);
            // 
            // chkKeepCommandFile
            // 
            this.chkKeepCommandFile.AutoSize = true;
            this.chkKeepCommandFile.Location = new System.Drawing.Point(283, 63);
            this.chkKeepCommandFile.Name = "chkKeepCommandFile";
            this.chkKeepCommandFile.Size = new System.Drawing.Size(108, 17);
            this.chkKeepCommandFile.TabIndex = 19;
            this.chkKeepCommandFile.Text = "Retain batch files";
            this.chkKeepCommandFile.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(158, 86);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 18;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(270, 86);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 17;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnMAFFT
            // 
            this.btnMAFFT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMAFFT.Location = new System.Drawing.Point(351, 86);
            this.btnMAFFT.Name = "btnMAFFT";
            this.btnMAFFT.Size = new System.Drawing.Size(75, 23);
            this.btnMAFFT.TabIndex = 16;
            this.btnMAFFT.Text = "MAFFT";
            this.btnMAFFT.UseVisualStyleBackColor = true;
            this.btnMAFFT.Click += new System.EventHandler(this.btnMAFFT_Click);
            // 
            // btnPrank
            // 
            this.btnPrank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrank.Location = new System.Drawing.Point(432, 86);
            this.btnPrank.Name = "btnPrank";
            this.btnPrank.Size = new System.Drawing.Size(75, 23);
            this.btnPrank.TabIndex = 15;
            this.btnPrank.Text = "PRANK";
            this.btnPrank.UseVisualStyleBackColor = true;
            this.btnPrank.Click += new System.EventHandler(this.btnPrank_Click);
            // 
            // chkAggregate
            // 
            this.chkAggregate.AutoSize = true;
            this.chkAggregate.Location = new System.Drawing.Point(397, 63);
            this.chkAggregate.Name = "chkAggregate";
            this.chkAggregate.Size = new System.Drawing.Size(133, 17);
            this.chkAggregate.TabIndex = 12;
            this.chkAggregate.Text = "Combine all alignments";
            this.chkAggregate.UseVisualStyleBackColor = true;
            // 
            // chkResetPrograms
            // 
            this.chkResetPrograms.AutoSize = true;
            this.chkResetPrograms.Location = new System.Drawing.Point(12, 63);
            this.chkResetPrograms.Name = "chkResetPrograms";
            this.chkResetPrograms.Size = new System.Drawing.Size(114, 17);
            this.chkResetPrograms.TabIndex = 10;
            this.chkResetPrograms.Text = "Reselect programs";
            this.chkResetPrograms.UseVisualStyleBackColor = true;
            this.chkResetPrograms.CheckedChanged += new System.EventHandler(this.chkResetPrograms_CheckedChanged);
            // 
            // btnMuscle
            // 
            this.btnMuscle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMuscle.Location = new System.Drawing.Point(513, 86);
            this.btnMuscle.Name = "btnMuscle";
            this.btnMuscle.Size = new System.Drawing.Size(75, 23);
            this.btnMuscle.TabIndex = 13;
            this.btnMuscle.Text = "Muscle";
            this.btnMuscle.UseVisualStyleBackColor = true;
            this.btnMuscle.Click += new System.EventHandler(this.btnMuscle_Click);
            // 
            // chkShowCMD
            // 
            this.chkShowCMD.AutoSize = true;
            this.chkShowCMD.Location = new System.Drawing.Point(136, 63);
            this.chkShowCMD.Name = "chkShowCMD";
            this.chkShowCMD.Size = new System.Drawing.Size(141, 17);
            this.chkShowCMD.TabIndex = 11;
            this.chkShowCMD.Text = "Show command window";
            this.chkShowCMD.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(9, 47);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(607, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // btnClustalW
            // 
            this.btnClustalW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClustalW.Location = new System.Drawing.Point(593, 86);
            this.btnClustalW.Name = "btnClustalW";
            this.btnClustalW.Size = new System.Drawing.Size(75, 23);
            this.btnClustalW.TabIndex = 14;
            this.btnClustalW.Text = "ClustalW";
            this.btnClustalW.UseVisualStyleBackColor = true;
            this.btnClustalW.Click += new System.EventHandler(this.btnClustalW_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Modify command line options";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnRunPartitionFinder);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnMakePartitionFinderFiles);
            this.groupBox5.Location = new System.Drawing.Point(15, 571);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(674, 65);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PartitionFinder2";
            // 
            // btnRunPartitionFinder
            // 
            this.btnRunPartitionFinder.Location = new System.Drawing.Point(590, 39);
            this.btnRunPartitionFinder.Name = "btnRunPartitionFinder";
            this.btnRunPartitionFinder.Size = new System.Drawing.Size(75, 23);
            this.btnRunPartitionFinder.TabIndex = 3;
            this.btnRunPartitionFinder.Text = "Run";
            this.btnRunPartitionFinder.UseVisualStyleBackColor = true;
            this.btnRunPartitionFinder.Click += new System.EventHandler(this.btnRunPartitionFinder_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(339, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "To run PartitionFinder2 using premade input files press the \'Run\' button";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(565, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "To create a PartitionFinder2 config file and a phylip alignment file from anignme" +
    "nts in a fatsa file press the \'Make\' button";
            // 
            // btnMakePartitionFinderFiles
            // 
            this.btnMakePartitionFinderFiles.Location = new System.Drawing.Point(590, 11);
            this.btnMakePartitionFinderFiles.Name = "btnMakePartitionFinderFiles";
            this.btnMakePartitionFinderFiles.Size = new System.Drawing.Size(75, 23);
            this.btnMakePartitionFinderFiles.TabIndex = 0;
            this.btnMakePartitionFinderFiles.Text = "Make";
            this.btnMakePartitionFinderFiles.UseVisualStyleBackColor = true;
            this.btnMakePartitionFinderFiles.Click += new System.EventHandler(this.btnMakePartitionFinderFiles_Click);
            // 
            // chkExtend
            // 
            this.chkExtend.AutoSize = true;
            this.chkExtend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkExtend.Checked = true;
            this.chkExtend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExtend.Location = new System.Drawing.Point(443, 63);
            this.chkExtend.Name = "chkExtend";
            this.chkExtend.Size = new System.Drawing.Size(84, 17);
            this.chkExtend.TabIndex = 4;
            this.chkExtend.Text = "Extend CDS";
            this.chkExtend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 677);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(709, 588);
            this.Name = "Form1";
            this.Text = "GeneMatrix";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkFolder;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.TreeView tv2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rboBoth;
        private System.Windows.Forms.RadioButton rboProtein;
        private System.Windows.Forms.RadioButton rboDNA;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClustalW;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkShowCMD;
        private System.Windows.Forms.Button btnMuscle;
        private System.Windows.Forms.CheckBox chkAggregate;
        private System.Windows.Forms.CheckBox chkResetPrograms;
        private System.Windows.Forms.Button btnPrank;
        private System.Windows.Forms.Button btnMAFFT;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.CheckBox chkKeepCommandFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkGBlocks;
        private System.Windows.Forms.CheckBox chkIgnoreEmptySequence;
        private System.Windows.Forms.Button btnSaveSteps;
        private System.Windows.Forms.Button btnImportSteps;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnMakePartitionFinderFiles;
        private System.Windows.Forms.Button btnRunPartitionFinder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnBasicData;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox chkExtend;
    }
}

