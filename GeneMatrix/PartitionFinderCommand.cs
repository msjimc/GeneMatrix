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
        private string options = "";
        private string folder = "";
        public PartitionFinderCommand(string command, string partitionFinder, string Options, string Folder)
        {
            InitializeComponent();

            populateEnvironmentList();

            baseComand = command;
            program = partitionFinder;
            options = Options;
            folder = Folder;
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

            rboAnaconda3.Enabled = false;

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
                rboAnaconda3.Enabled = true;
            }
            else if (cboAnaconda.Items.Count > 2)
            {
                cboAnaconda.SelectedIndex = 0;
                rboAnaconda3.Checked = true;
                rboAnaconda3.Enabled = true;
            }
            else
            {
                cboAnaconda.SelectedIndex = 0;
                cboAnaconda.Enabled = false;
                rboPython27.Checked = true;
            }

            makeCommand();
        }

        private void makeCommand()
        {
            string pythonCommand = "";
            if (rboAnaconda3.Checked == true)
            { pythonCommand = "python " + program + baseComand + options; }
            else if (rboPython27.Checked == true)
            { pythonCommand = "python2.7 " + program + baseComand + options; }
            else if (rboPython3.Checked == true)
            { pythonCommand = "python3 " + program + baseComand + options; }
            else if (rboPython.Checked == true)
            { pythonCommand = "conda activate " + cboAnaconda.Text + "\npython " + program + baseComand + options; }
                       
            txtCommand.Text = pythonCommand;
        } 

        private void PartitionFinderCommand_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboOptions.SelectedIndex == 0) {return;}

            string selected = cboOptions.Text;
            if (selected.Contains(" ") == true)
            { options = options.Substring(0, selected.IndexOf(" ")); }

            if (options.Contains(selected) == false)
            { options += " " + selected; }
            else
            {
                int indexS = options.IndexOf(selected);
                int indexE = options.IndexOf("-", indexS);
                if (indexE== -1)
                { options = options.Substring(0, indexS); }
                else
                { options = options.Substring(0, indexS) + " " + options.Substring(indexE);}
            }

            makeCommand();
        }

        private void rbo_CheckChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true) { makeCommand(); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string file = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "Enter the filename.", "Text file (*.txt)|*.txt");
            if (file == "Cancel") { return; }

            System.IO.StreamWriter sf = null;

            try
            {
                sf = new System.IO.StreamWriter(file);
                sf.Write(txtCommand.Text);
            }
            catch(Exception ex)
            { MessageBox.Show("Could not create the file: " + ex.Message, "Error"); }
            finally
            { if (sf!= null) { sf.Close(); } }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string filename = folder + "\\PartitionFinder2.sh";
            System.IO.StreamWriter sf = null;

            try
            {
                sf = new System.IO.StreamWriter(filename);
                sf.Write(txtCommand.Text);
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Could not create the shell file: " + ex.Message, "Error");
                return;
            }
            finally
            { if (sf != null) { sf.Close(); } }


            Application.DoEvents();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + filename);
            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            process.StartInfo = info;

            process.Start();
            process.WaitForExit();

        }
    }
}
