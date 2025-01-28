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

            cboOptions.SelectedIndex = 0;

            makeCommand();
        }

        private void populateEnvironmentList()
        {
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            cboAnaconda.Items.Clear();
            cboAnaconda.Items.Add("Select");

            String endOfPath = "\\Anaconda3\\envs\\";
            string[] envs = null;
            List<string> envsList = new List<string>();

            if (System.IO.Directory.Exists(userFolder + endOfPath) == true)
            {
                envs = System.IO.Directory.GetDirectories(userFolder + endOfPath);

                foreach (string env in envs)             
                {
                    string en = env.Substring(env.LastIndexOf("\\") + 1);
                    if (envsList.Contains(en) == false)
                    { envsList.Add(env.Substring(env.LastIndexOf("\\") + 1)); }
                }
            }

            if (System.IO.Directory.Exists("C:\\ProgramData" + endOfPath) == true)
            {
                envs = System.IO.Directory.GetDirectories("C:\\ProgramData" + endOfPath);
                foreach (string env in envs)
                {
                    string en = env.Substring(env.LastIndexOf("\\") + 1);
                    if (envsList.Contains(en) == false)
                    { envsList.Add(env.Substring(env.LastIndexOf("\\") + 1)); }
                }
            }

            string nonStandardLocation = getNonStandardLocation();
            if (System.IO.Directory.Exists (nonStandardLocation + "\\envs") == true)
            {
                envs = System.IO.Directory.GetDirectories(nonStandardLocation + "\\envs");
                foreach (string env in envs)
                {
                    string en = env.Substring(env.LastIndexOf("\\") + 1);
                    if (envsList.Contains(en) == false)
                    { envsList.Add(env.Substring(env.LastIndexOf("\\") + 1)); }
                }
            }

            cboAnaconda.Items.AddRange(envsList.ToArray());

            if (cboAnaconda.Items.Count == 2)
            {
                cboAnaconda.SelectedIndex = 1;
                rboAnaconda3.Checked = true;
            }
            else if (cboAnaconda.Items.Count > 2)
            {
                cboAnaconda.SelectedIndex = 0;
                rboAnaconda3.Checked = true;
            }
            else
            {
                cboAnaconda.SelectedIndex = 0;
                rboPython27.Checked = true;
            }

            makeCommand();
        }

        private string getNonStandardLocation()
        {
            List<string> folders = new List<string>();

            string path = Environment.GetEnvironmentVariable("PATH");
            if (path != null && path.Contains("anaconda"))
            {
                string[] paths = path.Split(';');

                foreach (string individualPath in paths)
                {
                    if (individualPath.Contains("anaconda"))
                    {
                        folders.Add(individualPath);
                    }
                }
            }

            path = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.User);
            if (path != null && path.Contains("anaconda"))
            {
                string[] paths = path.Split(';');

                foreach (string individualPath in paths)
                {
                    if (individualPath.Contains("anaconda"))
                    {
                        folders.Add(individualPath);
                    }
                }
            }

            foreach(string f in folders)
            {
                string fPlus = f + "\\";
                int indexS = fPlus.ToLower().IndexOf("anaconda");
                int indexE = fPlus.IndexOf("\\", indexS + 1);
                fPlus = fPlus.Substring(0, indexE);
                if (System.IO.Directory.Exists(fPlus + "\\envs") ==true)
                { return fPlus; }
            }

            return "";
        }

        private void makeCommand()
        {
            string pythonCommand = "";
            if (rboPython.Checked == true)
            { pythonCommand = "python " + program + baseComand + options; }
            else if (rboPython27.Checked == true)
            { pythonCommand = "python2.7 " + program + baseComand + options; }
            else if (rboPython3.Checked == true)
            { pythonCommand = "python3 " + program + baseComand + options; }
            else if (rboAnaconda3.Checked == true)
            { pythonCommand = "call conda init\r\ncall conda activate " + cboAnaconda.Text + "\r\npython " + program + " " + baseComand + " " + options; }
                       
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
            { selected = selected.Substring(0, selected.IndexOf(" ")); }

            if (options.Contains(selected) == false)
            { options += " " + cboOptions.Text; }
            else
            {
                int indexS = options.IndexOf(selected);
                int indexE = options.IndexOf(selected, indexS + 1);
                if (indexE== -1)
                { options = options.Substring(0, indexS); }
                else
                { options = options.Substring(0, indexS) + " " + options.Substring(indexE);}
            }

            int optionLength = 0;

            while (optionLength != options.Length)
            {
                options = options.Replace("  ", " ");
                optionLength = options.Length;
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
            string filename = folder + "\\PartitionFinder2.bat";
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
            info.CreateNoWindow = false;

            process.StartInfo = info;

            process.Start();
            process.WaitForExit();

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string getPartitionFinder2Filename(bool reselect)
        {
            if (reselect == false)
            {
                string PartitionFinder = Properties.Settings.Default.PartitionFinder;
                if (System.IO.File.Exists(PartitionFinder) == true)
                { return PartitionFinder; }

                string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                location = location.Substring(8);
                location = location.Replace("/", "\\");
                location = location.Substring(0, location.LastIndexOf('\\'));
                string program = location + "\\PartitionFinder.py";

                if (System.IO.File.Exists(program) == true)
                {
                    Properties.Settings.Default.PartitionFinder = program;
                    Properties.Settings.Default.Save();
                    return program;
                }
            }

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the PartitionFinder.py script file", "program (*.py)|*.py");
            if (System.IO.File.Exists(fileName) == true)
            {
                Properties.Settings.Default.PartitionFinder = fileName;
                Properties.Settings.Default.Save();
                return fileName;
            }
            else
            {
                MessageBox.Show("The PartitionFinder2.py script is required for this function, see user guide for more information", "No PartitionFinder2 script");
                return null;
            }
        }

        private void btnReselect_Click(object sender, EventArgs e)
        {
            string answer = getPartitionFinder2Filename(true);
            if (answer != null)
            {
                makeCommand();
            }
        }
    }
}
