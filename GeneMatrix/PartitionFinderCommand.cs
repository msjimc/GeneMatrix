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
    public partial class PartitionFinderCommand : Form
    {
        private string program = "";
        private string baseComand = "";
        public PartitionFinderCommand(string command, string partitionFinder)
        {
            InitializeComponent();

            populateEnvironmentList();

            baseComand = command;
            program = partitionFinder;

        }

        private void populateEnvironmentList()
        {
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            cboAnaconda.Items.Clear();
            cboAnaconda.Items.Add("Select");  
            
            String endOfPath = "\\Anaconda3\\envs\\";
            string[] envs = null;
            if (System.IO.Directory.Exists(userFolder + endOfPath) == true)
            {
                 envs = System.IO.Directory.GetDirectories(userFolder + endOfPath);

                foreach (string env in envs)
                {
                    cboAnaconda.Items.Add(env.Substring(env.LastIndexOf("\\") + 1));
                }
            }

            if (System.IO.Directory.Exists("C:\\ProgramData" + endOfPath) == true)
            {
                envs = System.IO.Directory.GetDirectories("C:\\ProgramData" + endOfPath);
                foreach (string env in envs)
                {
                    cboAnaconda.Items.Add(env.Substring(env.LastIndexOf("\\") + 1));
                }
            }
            if (cboAnaconda.Items.Count == 2)
            {
                cboAnaconda.SelectedIndex = 1;
                rboAnaconda3.Checked = true;
            }
            else if (cboAnaconda.Items.Count > 2)
            {
                cboAnaconda.SelectedIndex = 0;
            rboAnaconda3.Checked= true;
            }
            else
            {
                cboAnaconda.SelectedIndex = 0;
                cboAnaconda.Enabled = false;
                rboPython27.Checked = true;
            }

        }

        private void PartitionFinderCommand_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}
