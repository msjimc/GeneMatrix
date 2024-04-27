using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneMatrix
{
    public partial class modifyCommand : Form
    {
        public modifyCommand()
        {
            InitializeComponent();


            txtMAFFTDNA.Text = Properties.Settings.Default.MAFFTD;
            txtMAFFTProtein.Text = Properties.Settings.Default.MAFFTP;
            txtPRANKDNA.Text = Properties.Settings.Default.PRANKD;
            txtPRANKProtein.Text = Properties.Settings.Default.PRANKP;
            txtMuscleDNA.Text = Properties.Settings.Default.MuscleD;
            txtMuscleProtein.Text = Properties.Settings.Default.MuscleP;
            txtClustalWDNA.Text = Properties.Settings.Default.ClustalWD;
            txtClustalWProtein.Text = Properties.Settings.Default.ClustalWP;
            txtGBlocksD.Text = Properties.Settings.Default.GBlocksD;
            txtGBlocksP.Text = Properties.Settings.Default.GBlocksP;

            btnMAFFTDNA.ForeColor = btnMAFFTDr.ForeColor;
            btnMAFFTProtein.ForeColor = btnMAFFTDr.ForeColor;
            btnPRANKDNA.ForeColor = btnMAFFTDr.ForeColor;
            btnPRANKProtein.ForeColor = btnMAFFTDr.ForeColor;
            btnMuscleDNA.ForeColor = btnMAFFTDr.ForeColor;
            btnMuscleProtein.ForeColor = btnMAFFTDr.ForeColor;
            btnClustalWDNA.ForeColor = btnMAFFTDr.ForeColor;
            btnClustalWProtein.ForeColor = btnMAFFTDr.ForeColor;
            btnGBlocksD.ForeColor= btnMAFFTDr.ForeColor;
            btnGBlocksP.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMAFFTDNA_Click(object sender, EventArgs e)
        {
            string c = txtMAFFTDNA.Text.Trim();
            Properties.Settings.Default.MAFFTD = c;
            Properties.Settings.Default.Save();
            btnMAFFTDNA.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnMAFFTProtein_Click(object sender, EventArgs e)
        {
            string c = txtMAFFTProtein.Text.Trim();
            Properties.Settings.Default.MAFFTP = c;
            Properties.Settings.Default.Save();
            btnMAFFTProtein.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnPRANKDNA_Click(object sender, EventArgs e)
        {
            string c = txtPRANKDNA.Text.Trim();
            Properties.Settings.Default.PRANKD = c;
            Properties.Settings.Default.Save();
            btnPRANKDNA.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnPRANKProtein_Click(object sender, EventArgs e)
        {
            string c = txtPRANKProtein.Text.Trim();
            Properties.Settings.Default.PRANKP = c;
            Properties.Settings.Default.Save();
            btnPRANKProtein.ForeColor = btnMAFFTDr.ForeColor;
        }

            private void btnMuscleDNA_Click(object sender, EventArgs e)
        {
            string c = txtMuscleDNA.Text.Trim();
            Properties.Settings.Default.MuscleD = c;
            Properties.Settings.Default.Save();
            btnMuscleDNA.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnMuscleProtein_Click(object sender, EventArgs e)
        {
            string c = txtMuscleProtein.Text.Trim();
            Properties.Settings.Default.MuscleP = c;
            Properties.Settings.Default.Save();
            btnMuscleProtein.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnClustalWDNA_Click(object sender, EventArgs e)
        {
            string c = txtClustalWDNA.Text.Trim();
            Properties.Settings.Default.ClustalWD = c;
            Properties.Settings.Default.Save();
            btnClustalWDNA.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnClustalWProtein_Click(object sender, EventArgs e)
        {
            string c = txtClustalWProtein.Text.Trim();
            Properties.Settings.Default.ClustalWP = c;
            Properties.Settings.Default.Save();
            btnClustalWProtein.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnMAFFTDr_Click(object sender, EventArgs e)
        {
            txtMAFFTDNA.Text = "--auto --retree 2 --inputorder";
            btnMAFFTDNA.PerformClick();
        }

        private void btnMAFFTProteinr_Click(object sender, EventArgs e)
        {
            txtMAFFTProtein.Text = "--auto --retree 2 --inputorder";
            btnMAFFTProtein.PerformClick();
        }

        private void btnPRANKDNAr_Click(object sender, EventArgs e)
        {
            txtPRANKDNA.Clear();
            btnPRANKDNA.PerformClick();
        }

        private void btnPRANKProteinr_Click(object sender, EventArgs e)
        {
            txtPRANKProtein.Clear();
            btnPRANKProtein.PerformClick();
        }

        private void btnMuscleDNAr_Click(object sender, EventArgs e)
        {
            txtMuscleDNA.Clear();
            btnMuscleDNA.PerformClick();
        }

        private void btnMuscleProteinr_Click(object sender, EventArgs e)
        {
            txtMuscleProtein.Clear();
            btnMuscleProtein.PerformClick();
        }

        private void btnClustalWDNAr_Click(object sender, EventArgs e)
        {
            txtClustalWDNA.Text = "-OUTPUT=FASTA -TYPE=DNA";
            btnClustalWDNA.PerformClick();
        }

        private void btnClustalWProteinr_Click(object sender, EventArgs e)
        {
            txtClustalWProtein.Text = "-OUTPUT=FASTA -TYPE=PROTEIN";
            btnClustalWProtein.PerformClick();
        }

        private void txtMAFFTDNA_TextChanged(object sender, EventArgs e)
        {
            btnMAFFTDNA.ForeColor = Color.Red;
        }

        private void txtMAFFTProtein_TextChanged(object sender, EventArgs e)
        {
            btnMAFFTProtein.ForeColor = Color.Red;
        }

        private void txtPRANKDNA_TextChanged(object sender, EventArgs e)
        {
            btnPRANKDNA.ForeColor = Color.Red;
        }

        private void txtPRANKProtein_TextChanged(object sender, EventArgs e)
        {
            btnPRANKProtein.ForeColor = Color.Red;
        }

        private void txtMuscleDNA_TextChanged(object sender, EventArgs e)
        {
            btnMuscleDNA.ForeColor = Color.Red;
        }

        private void txtMuscleProtein_TextChanged(object sender, EventArgs e)
        {
            btnMuscleProtein.ForeColor = Color.Red;
        }

        private void txtClustalWDNA_TextChanged(object sender, EventArgs e)
        {
            btnClustalWDNA.ForeColor = Color.Red;
        }

        private void txtClustalWProtein_TextChanged(object sender, EventArgs e)
        {
            btnClustalWProtein.ForeColor = Color.Red;
        }

        private void txtGBlocksD_TextChanged(object sender, EventArgs e)
        {
            btnGBlocksD.ForeColor = Color.Red;
        }

        private void txtGBlocksP_TextChanged(object sender, EventArgs e)
        {
            btnGBlocksP.ForeColor = Color.Red;
        }

        private void btnGBlocksD_Click(object sender, EventArgs e)
        {
            string c = txtGBlocksD.Text.Trim();
            Properties.Settings.Default.GBlocksD = c;
            Properties.Settings.Default.Save();
            btnGBlocksD.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnGBlocksP_Click(object sender, EventArgs e)
        {
            string c = txtGBlocksP.Text.Trim();
            Properties.Settings.Default.GBlocksP = c;
            Properties.Settings.Default.Save();
            btnGBlocksP.ForeColor = btnMAFFTDr.ForeColor;
        }

        private void btnGBlocksDr_Click(object sender, EventArgs e)
        {
            txtGBlocksD.Text = "-t=d -e=.fa";
            btnGBlocksD.PerformClick();
        }

        private void btnGBlocksPr_Click(object sender, EventArgs e)
        {
            txtGBlocksP.Text = "-t=p -e=.fa";
            btnGBlocksP.PerformClick();
        }
    }
}
