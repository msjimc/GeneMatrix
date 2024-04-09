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
            this.btnClustalW = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkShowCMD = new System.Windows.Forms.CheckBox();
            this.btnMuscle = new System.Windows.Forms.Button();
            this.chkResetPrograms = new System.Windows.Forms.CheckBox();
            this.chkAggregate = new System.Windows.Forms.CheckBox();
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
            this.lblDataSource.Size = new System.Drawing.Size(529, 18);
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
            this.chkFolder.TabIndex = 2;
            this.chkFolder.Text = "Folder";
            this.chkFolder.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(593, 59);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 1;
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
            this.btnQuit.Location = new System.Drawing.Point(12, 529);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
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
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 229);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Combine features with different names";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(593, 197);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.tv1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tv2);
            this.splitContainer1.Size = new System.Drawing.Size(668, 175);
            this.splitContainer1.SplitterDistance = 322;
            this.splitContainer1.TabIndex = 0;
            // 
            // tv1
            // 
            this.tv1.CheckBoxes = true;
            this.tv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv1.Location = new System.Drawing.Point(0, 0);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(322, 175);
            this.tv1.TabIndex = 0;
            this.tv1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv1_AfterSelect);
            // 
            // tv2
            // 
            this.tv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv2.Location = new System.Drawing.Point(0, 0);
            this.tv2.Name = "tv2";
            this.tv2.Size = new System.Drawing.Size(342, 175);
            this.tv2.TabIndex = 0;
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
            this.groupBox3.Location = new System.Drawing.Point(12, 356);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(674, 72);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save sequences";
            // 
            // rboBoth
            // 
            this.rboBoth.AutoSize = true;
            this.rboBoth.Location = new System.Drawing.Point(280, 46);
            this.rboBoth.Name = "rboBoth";
            this.rboBoth.Size = new System.Drawing.Size(137, 17);
            this.rboBoth.TabIndex = 4;
            this.rboBoth.Text = "Both types of sequence";
            this.rboBoth.UseVisualStyleBackColor = true;
            // 
            // rboProtein
            // 
            this.rboProtein.AutoSize = true;
            this.rboProtein.Location = new System.Drawing.Point(140, 46);
            this.rboProtein.Name = "rboProtein";
            this.rboProtein.Size = new System.Drawing.Size(134, 17);
            this.rboProtein.TabIndex = 3;
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
            this.rboDNA.TabIndex = 2;
            this.rboDNA.TabStop = true;
            this.rboDNA.Text = "Just DNA sequences";
            this.rboDNA.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(593, 43);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
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
            this.groupBox4.Controls.Add(this.chkAggregate);
            this.groupBox4.Controls.Add(this.chkResetPrograms);
            this.groupBox4.Controls.Add(this.btnMuscle);
            this.groupBox4.Controls.Add(this.chkShowCMD);
            this.groupBox4.Controls.Add(this.lblStatus);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnClustalW);
            this.groupBox4.Location = new System.Drawing.Point(12, 434);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(674, 89);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Align individual features";
            // 
            // btnClustalW
            // 
            this.btnClustalW.Location = new System.Drawing.Point(593, 60);
            this.btnClustalW.Name = "btnClustalW";
            this.btnClustalW.Size = new System.Drawing.Size(75, 23);
            this.btnClustalW.TabIndex = 0;
            this.btnClustalW.Text = "ClustalW";
            this.btnClustalW.UseVisualStyleBackColor = true;
            this.btnClustalW.Click += new System.EventHandler(this.btnClustalW_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(662, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(351, 42);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // chkShowCMD
            // 
            this.chkShowCMD.AutoSize = true;
            this.chkShowCMD.Location = new System.Drawing.Point(177, 64);
            this.chkShowCMD.Name = "chkShowCMD";
            this.chkShowCMD.Size = new System.Drawing.Size(141, 17);
            this.chkShowCMD.TabIndex = 3;
            this.chkShowCMD.Text = "Show command window";
            this.chkShowCMD.UseVisualStyleBackColor = true;
            // 
            // btnMuscle
            // 
            this.btnMuscle.Location = new System.Drawing.Point(513, 60);
            this.btnMuscle.Name = "btnMuscle";
            this.btnMuscle.Size = new System.Drawing.Size(75, 23);
            this.btnMuscle.TabIndex = 4;
            this.btnMuscle.Text = "Muscle";
            this.btnMuscle.UseVisualStyleBackColor = true;
            this.btnMuscle.Click += new System.EventHandler(this.btnMuscle_Click);
            // 
            // chkResetPrograms
            // 
            this.chkResetPrograms.AutoSize = true;
            this.chkResetPrograms.Location = new System.Drawing.Point(9, 64);
            this.chkResetPrograms.Name = "chkResetPrograms";
            this.chkResetPrograms.Size = new System.Drawing.Size(162, 17);
            this.chkResetPrograms.TabIndex = 5;
            this.chkResetPrograms.Text = "Reselect alignment programs";
            this.chkResetPrograms.UseVisualStyleBackColor = true;
            // 
            // chkAggregate
            // 
            this.chkAggregate.AutoSize = true;
            this.chkAggregate.Location = new System.Drawing.Point(374, 64);
            this.chkAggregate.Name = "chkAggregate";
            this.chkAggregate.Size = new System.Drawing.Size(133, 17);
            this.chkAggregate.TabIndex = 6;
            this.chkAggregate.Text = "Combine all alignments";
            this.chkAggregate.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 564);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(714, 603);
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
    }
}

