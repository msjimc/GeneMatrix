namespace GeneMatrix
{
    partial class PartitionFinderCommand
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReselect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cboOptions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rboPython = new System.Windows.Forms.RadioButton();
            this.rboPython3 = new System.Windows.Forms.RadioButton();
            this.cboAnaconda = new System.Windows.Forms.ComboBox();
            this.rboAnaconda3 = new System.Windows.Forms.RadioButton();
            this.rboPython27 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnReselect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Controls.Add(this.cboOptions);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1300, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btnReselect
            // 
            this.btnReselect.Location = new System.Drawing.Point(194, 85);
            this.btnReselect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnReselect.Name = "btnReselect";
            this.btnReselect.Size = new System.Drawing.Size(150, 44);
            this.btnReselect.TabIndex = 6;
            this.btnReselect.Text = "Program";
            this.btnReselect.UseVisualStyleBackColor = true;
            this.btnReselect.Click += new System.EventHandler(this.btnReselect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Reselect program";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(588, 85);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(150, 44);
            this.btnSelect.TabIndex = 7;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cboOptions
            // 
            this.cboOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOptions.FormattingEnabled = true;
            this.cboOptions.Items.AddRange(new object[] {
            "Select",
            "--all-states",
            "--force-restart",
            "--min-subset-size",
            "--no-ml-tree",
            "--processors N",
            "--quick",
            "--raxml",
            "--rcluster-max N",
            "--rcluster-percent N",
            "--save-phylofiles",
            "--weights “Wrate , Wbase , Wmodel , Walpha ” "});
            this.cboOptions.Location = new System.Drawing.Point(762, 88);
            this.cboOptions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboOptions.Name = "cboOptions";
            this.cboOptions.Size = new System.Drawing.Size(524, 33);
            this.cboOptions.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Command line options";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rboPython);
            this.panel1.Controls.Add(this.rboPython3);
            this.panel1.Controls.Add(this.cboAnaconda);
            this.panel1.Controls.Add(this.rboAnaconda3);
            this.panel1.Controls.Add(this.rboPython27);
            this.panel1.Location = new System.Drawing.Point(156, 29);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 52);
            this.panel1.TabIndex = 1;
            // 
            // rboPython
            // 
            this.rboPython.AutoSize = true;
            this.rboPython.Location = new System.Drawing.Point(6, 6);
            this.rboPython.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rboPython.Name = "rboPython";
            this.rboPython.Size = new System.Drawing.Size(110, 29);
            this.rboPython.TabIndex = 1;
            this.rboPython.TabStop = true;
            this.rboPython.Text = "Python";
            this.rboPython.UseVisualStyleBackColor = true;
            this.rboPython.CheckedChanged += new System.EventHandler(this.rbo_CheckChanged);
            // 
            // rboPython3
            // 
            this.rboPython3.AutoSize = true;
            this.rboPython3.Location = new System.Drawing.Point(292, 6);
            this.rboPython3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rboPython3.Name = "rboPython3";
            this.rboPython3.Size = new System.Drawing.Size(122, 29);
            this.rboPython3.TabIndex = 3;
            this.rboPython3.TabStop = true;
            this.rboPython3.Text = "Python3";
            this.rboPython3.UseVisualStyleBackColor = true;
            this.rboPython3.CheckedChanged += new System.EventHandler(this.rbo_CheckChanged);
            // 
            // cboAnaconda
            // 
            this.cboAnaconda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAnaconda.FormattingEnabled = true;
            this.cboAnaconda.Location = new System.Drawing.Point(604, 4);
            this.cboAnaconda.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cboAnaconda.Name = "cboAnaconda";
            this.cboAnaconda.Size = new System.Drawing.Size(524, 33);
            this.cboAnaconda.TabIndex = 5;
            // 
            // rboAnaconda3
            // 
            this.rboAnaconda3.AutoSize = true;
            this.rboAnaconda3.Location = new System.Drawing.Point(432, 6);
            this.rboAnaconda3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rboAnaconda3.Name = "rboAnaconda3";
            this.rboAnaconda3.Size = new System.Drawing.Size(152, 29);
            this.rboAnaconda3.TabIndex = 4;
            this.rboAnaconda3.TabStop = true;
            this.rboAnaconda3.Text = "Anaconda3";
            this.rboAnaconda3.UseVisualStyleBackColor = true;
            this.rboAnaconda3.CheckedChanged += new System.EventHandler(this.rbo_CheckChanged);
            // 
            // rboPython27
            // 
            this.rboPython27.AutoSize = true;
            this.rboPython27.Location = new System.Drawing.Point(134, 6);
            this.rboPython27.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rboPython27.Name = "rboPython27";
            this.rboPython27.Size = new System.Drawing.Size(140, 29);
            this.rboPython27.TabIndex = 2;
            this.rboPython27.TabStop = true;
            this.rboPython27.Text = "Python2.7";
            this.rboPython27.UseVisualStyleBackColor = true;
            this.rboPython27.CheckedChanged += new System.EventHandler(this.rbo_CheckChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Environment";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtCommand);
            this.groupBox2.Location = new System.Drawing.Point(12, 167);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1300, 235);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Command";
            // 
            // txtCommand
            // 
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommand.Location = new System.Drawing.Point(4, 28);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCommand.Size = new System.Drawing.Size(1292, 203);
            this.txtCommand.TabIndex = 0;
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuit.Location = new System.Drawing.Point(30, 410);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(150, 44);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1004, 410);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 44);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(1162, 410);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(150, 44);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // PartitionFinderCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 475);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1330, 484);
            this.Name = "PartitionFinderCommand";
            this.Text = "PartitionFinder2 command constructor";
            this.Load += new System.EventHandler(this.PartitionFinderCommand_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboAnaconda;
        private System.Windows.Forms.RadioButton rboAnaconda3;
        private System.Windows.Forms.RadioButton rboPython;
        private System.Windows.Forms.RadioButton rboPython27;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rboPython3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cboOptions;
        private System.Windows.Forms.Button btnReselect;
        private System.Windows.Forms.Label label3;
    }
}