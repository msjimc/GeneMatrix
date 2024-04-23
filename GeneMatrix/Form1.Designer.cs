namespace GeneMatrix
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
            this.btnReset = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.tv2 = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rboBoth = new System.Windows.Forms.RadioButton();
            this.rboProtein = new System.Windows.Forms.RadioButton();
            this.rboDNA = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDataSource);
            this.groupBox1.Controls.Add(this.chkFolder);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 23);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(1348, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import data";
            // 
            // lblDataSource
            // 
            this.lblDataSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataSource.Location = new System.Drawing.Point(12, 123);
            this.lblDataSource.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDataSource.Name = "lblDataSource";
            this.lblDataSource.Size = new System.Drawing.Size(1058, 35);
            this.lblDataSource.TabIndex = 3;
            this.lblDataSource.Text = "Not set";
            // 
            // chkFolder
            // 
            this.chkFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFolder.AutoSize = true;
            this.chkFolder.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFolder.Location = new System.Drawing.Point(1071, 121);
            this.chkFolder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkFolder.Name = "chkFolder";
            this.chkFolder.Size = new System.Drawing.Size(105, 29);
            this.chkFolder.TabIndex = 1;
            this.chkFolder.Text = "Folder";
            this.chkFolder.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(1186, 113);
            this.btnImport.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 44);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1324, 92);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuit.Location = new System.Drawing.Point(24, 1102);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(150, 44);
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
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.splitContainer1);
            this.groupBox2.Location = new System.Drawing.Point(24, 212);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(1348, 471);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Combine features with different names";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(1186, 410);
            this.btnReset.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(150, 44);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 31);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tv2);
            this.splitContainer1.Size = new System.Drawing.Size(1336, 367);
            this.splitContainer1.SplitterDistance = 644;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // tv1
            // 
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.Location = new System.Drawing.Point(0, 0);
            this.tv1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(644, 367);
            this.tv1.TabIndex = 3;
            this.tv1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv1_NodeMouseClick);
            // 
            // tv2
            // 
            this.tv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv2.Location = new System.Drawing.Point(0, 0);
            this.tv2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tv2.Name = "tv2";
            this.tv2.Size = new System.Drawing.Size(684, 367);
            this.tv2.TabIndex = 4;
            this.tv2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv2_AfterSelect);
            this.tv2.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv2_NodeMouseClick);
            this.tv2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv2_MouseDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rboBoth);
            this.groupBox3.Controls.Add(this.rboProtein);
            this.groupBox3.Controls.Add(this.rboDNA);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(30, 694);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(1348, 138);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save sequences";
            // 
            // rboBoth
            // 
            this.rboBoth.AutoSize = true;
            this.rboBoth.Location = new System.Drawing.Point(560, 88);
            this.rboBoth.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rboBoth.Name = "rboBoth";
            this.rboBoth.Size = new System.Drawing.Size(269, 29);
            this.rboBoth.TabIndex = 8;
            this.rboBoth.Text = "Both types of sequence";
            this.rboBoth.UseVisualStyleBackColor = true;
            // 
            // rboProtein
            // 
            this.rboProtein.AutoSize = true;
            this.rboProtein.Location = new System.Drawing.Point(280, 88);
            this.rboProtein.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rboProtein.Name = "rboProtein";
            this.rboProtein.Size = new System.Drawing.Size(266, 29);
            this.rboProtein.TabIndex = 7;
            this.rboProtein.Text = "Just protein sequences";
            this.rboProtein.UseVisualStyleBackColor = true;
            // 
            // rboDNA
            // 
            this.rboDNA.AutoSize = true;
            this.rboDNA.Checked = true;
            this.rboDNA.Location = new System.Drawing.Point(18, 88);
            this.rboDNA.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rboDNA.Name = "rboDNA";
            this.rboDNA.Size = new System.Drawing.Size(244, 29);
            this.rboDNA.TabIndex = 6;
            this.rboDNA.TabStop = true;
            this.rboDNA.Text = "Just DNA sequences";
            this.rboDNA.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(1186, 83);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 44);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1136, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "To save the sequences, select whether you which to save DNA, protein or both type" +
    "s and then press the Save button.";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox4.Location = new System.Drawing.Point(24, 844);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox4.Size = new System.Drawing.Size(1348, 221);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Align individual features";
            // 
            // chkKeepCommandFile
            // 
            this.chkKeepCommandFile.AutoSize = true;
            this.chkKeepCommandFile.Location = new System.Drawing.Point(566, 121);
            this.chkKeepCommandFile.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkKeepCommandFile.Name = "chkKeepCommandFile";
            this.chkKeepCommandFile.Size = new System.Drawing.Size(210, 29);
            this.chkKeepCommandFile.TabIndex = 19;
            this.chkKeepCommandFile.Text = "Retain batch files";
            this.chkKeepCommandFile.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(316, 165);
            this.btnModify.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(150, 44);
            this.btnModify.TabIndex = 18;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(540, 165);
            this.btnAll.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(150, 44);
            this.btnAll.TabIndex = 17;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnMAFFT
            // 
            this.btnMAFFT.Location = new System.Drawing.Point(702, 165);
            this.btnMAFFT.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMAFFT.Name = "btnMAFFT";
            this.btnMAFFT.Size = new System.Drawing.Size(150, 44);
            this.btnMAFFT.TabIndex = 16;
            this.btnMAFFT.Text = "MAFFT";
            this.btnMAFFT.UseVisualStyleBackColor = true;
            this.btnMAFFT.Click += new System.EventHandler(this.btnMAFFT_Click);
            // 
            // btnPrank
            // 
            this.btnPrank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrank.Location = new System.Drawing.Point(864, 165);
            this.btnPrank.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPrank.Name = "btnPrank";
            this.btnPrank.Size = new System.Drawing.Size(150, 44);
            this.btnPrank.TabIndex = 15;
            this.btnPrank.Text = "PRANK";
            this.btnPrank.UseVisualStyleBackColor = true;
            this.btnPrank.Click += new System.EventHandler(this.btnPrank_Click);
            // 
            // chkAggregate
            // 
            this.chkAggregate.AutoSize = true;
            this.chkAggregate.Location = new System.Drawing.Point(794, 121);
            this.chkAggregate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkAggregate.Name = "chkAggregate";
            this.chkAggregate.Size = new System.Drawing.Size(267, 29);
            this.chkAggregate.TabIndex = 12;
            this.chkAggregate.Text = "Combine all alignments";
            this.chkAggregate.UseVisualStyleBackColor = true;
            // 
            // chkResetPrograms
            // 
            this.chkResetPrograms.AutoSize = true;
            this.chkResetPrograms.Location = new System.Drawing.Point(24, 121);
            this.chkResetPrograms.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkResetPrograms.Name = "chkResetPrograms";
            this.chkResetPrograms.Size = new System.Drawing.Size(224, 29);
            this.chkResetPrograms.TabIndex = 10;
            this.chkResetPrograms.Text = "Reselect programs";
            this.chkResetPrograms.UseVisualStyleBackColor = true;
            // 
            // btnMuscle
            // 
            this.btnMuscle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMuscle.Location = new System.Drawing.Point(1026, 165);
            this.btnMuscle.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMuscle.Name = "btnMuscle";
            this.btnMuscle.Size = new System.Drawing.Size(150, 44);
            this.btnMuscle.TabIndex = 13;
            this.btnMuscle.Text = "Muscle";
            this.btnMuscle.UseVisualStyleBackColor = true;
            this.btnMuscle.Click += new System.EventHandler(this.btnMuscle_Click);
            // 
            // chkShowCMD
            // 
            this.chkShowCMD.AutoSize = true;
            this.chkShowCMD.Location = new System.Drawing.Point(280, 121);
            this.chkShowCMD.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.chkShowCMD.Name = "chkShowCMD";
            this.chkShowCMD.Size = new System.Drawing.Size(273, 29);
            this.chkShowCMD.TabIndex = 11;
            this.chkShowCMD.Text = "Show command window";
            this.chkShowCMD.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 90);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 25);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1214, 50);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // btnClustalW
            // 
            this.btnClustalW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClustalW.Location = new System.Drawing.Point(1186, 165);
            this.btnClustalW.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnClustalW.Name = "btnClustalW";
            this.btnClustalW.Size = new System.Drawing.Size(150, 44);
            this.btnClustalW.TabIndex = 14;
            this.btnClustalW.Text = "ClustalW";
            this.btnClustalW.UseVisualStyleBackColor = true;
            this.btnClustalW.Click += new System.EventHandler(this.btnClustalW_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Modify command line options";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 1169);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1402, 1094);
            this.Name = "Form1";
            this.Text = "Gene matrix";
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
    }
}

