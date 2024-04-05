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
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, Dictionary<string, feature>>> data = new Dictionary<string, Dictionary<string, Dictionary<string, feature>>>();
        private List<string> sequenceName = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (chkFolder.Checked==true)
            {
                string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder of GenBank files", "");
                if (System.IO.Directory.Exists(folder) == false) { return; }

                lblDataSource.Text = folder.Substring(folder.LastIndexOf("\\") + 1);
                Application.DoEvents();

                string[] gb=System.IO.Directory.GetDirectories(folder, "*.gb");
                string[] genbank = System.IO.Directory.GetDirectories(folder = "*.genbank");

                if (gb.Length > 0)
                {
                    foreach (string f in gb)
                    { readFile(f); }
                }

                if (genbank.Length > 0)
                {
                    foreach (string f in genbank)
                    { readFile(f); }
                }
            }
            else
            {
                string fileNmae = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the genbank file", "GenBank file (*.gb:*.genbank)|*.gb:*.genbank");
                if (System.IO.File.Exists(fileNmae) == false) { return; }

                lblDataSource.Text = fileNmae.Substring(fileNmae.LastIndexOf("\\") + 1);
                Application.DoEvents();

                readFile(fileNmae);
            }
        }

        private void readFile(string fileName)
        {

        }
    }
}
