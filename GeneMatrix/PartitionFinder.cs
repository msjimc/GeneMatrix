using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GeneMatrix
{
    public partial class PartitionFinder : Form
    {
        string fastaFolder = "";
        string[] fastaFiles = null;
        Dictionary<string, string> name_file = null;
        List<string> blockLines = null;

        public PartitionFinder()
        {
            InitializeComponent();

            cboSchemes.SelectedIndex = 0;
            cboExtension.SelectedIndex = 0;
            cboModel.SelectedIndex = 0;
            cboSelectionModel.SelectedIndex = 0;
            rdoDNA.Checked = true;
            List<string> blockLines = null;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder of Fasta files.", fastaFolder);
            if (System.IO.Directory.Exists(folder) == false) { return; }

            fastaFolder = folder;
            getFileCount();
        }

        private void getFileCount()
        {
            if (string.IsNullOrEmpty(fastaFolder) == true)
            {
                lblCount.Text = "Count: -";
                return;
            }

            string extension = cboExtension.Text;
            if (extension.StartsWith("*") == false) { extension = "*" + extension; }

            fastaFiles = System.IO.Directory.GetFiles(fastaFolder, extension);

            int count = fastaFiles.Length;
            lblCount.Text = "Count: " + count.ToString();

            if (count > 0) { btnCreate.Enabled = true; }
            else { btnCreate.Enabled = false; }
        }

        private void cboExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            getFileCount();
        }

        private void cboExtension_TextChanged(object sender, EventArgs e)
        {
            getFileCount();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string[] phyFileNames = getCommonName(fastaFiles);

            string[] listOfSequences = getListOfCommonSequences(fastaFiles);
            if (listOfSequences == null || listOfSequences.Length == 0)
            {
                MessageBox.Show("No sequence was in all of the files: a phylip file will only be made from sequences present in all the files.", "Error");
                return;
            }

            Dictionary<string, string> fastaSequences = new Dictionary<string, string>();
            List<int> sequenceLengths = new List<int>();

            System.IO.StreamWriter sw = null;
            System.IO.StreamWriter swB = null;
            string blocks = "";

            try
            {
               int lastLength = 0;

                sw = new System.IO.StreamWriter(phyFileNames[0]);
                swB = new System.IO.StreamWriter(phyFileNames[1]);
                sw.Write(listOfSequences.Length.ToString() + " " + getCombinedSequenceLength(listOfSequences).ToString() + "\n");

                string extension = cboExtension.Text;

                for (int sequenceIndex = 0; sequenceIndex < listOfSequences.Length; sequenceIndex++)
                {
                    sw.Write(listOfSequences[sequenceIndex] + " ");

                    for (int fileIndex = 0; fileIndex < fastaFiles.Length; fileIndex++)
                    {

                        string key = listOfSequences[sequenceIndex] + "_" + fastaFiles[fileIndex].Substring(fastaFiles[fileIndex].LastIndexOf("\\") + 1);
                        if (name_file.ContainsKey(key) == true)
                        {
                            if (sequenceIndex == 0)
                            {
                                System.Diagnostics.Debug.WriteLine(name_file[key].Length);
                                blocks += fastaFiles[fileIndex].Substring(fastaFiles[fileIndex].LastIndexOf("\\") + 1).Replace(extension,"") + "\t" + (lastLength + 1).ToString() + "-" + (lastLength + name_file[key].Length).ToString() + "\n";
                                blocks += fastaFiles[fileIndex].Substring(fastaFiles[fileIndex].LastIndexOf("\\") + 1).Replace(extension, "") + "_1stPos\t" + (lastLength + 1).ToString() + "-" + (lastLength + name_file[key].Length).ToString() + "\\3\n";
                                blocks += fastaFiles[fileIndex].Substring(fastaFiles[fileIndex].LastIndexOf("\\") + 1).Replace(extension, "") + "_2stPos\t" + (lastLength + 2).ToString() + "-" + (lastLength + name_file[key].Length).ToString() + "\\3\n";
                                blocks += fastaFiles[fileIndex].Substring(fastaFiles[fileIndex].LastIndexOf("\\") + 1).Replace(extension, "") + "_3stPos\t" + (lastLength + 3).ToString() + "-" + (lastLength + name_file[key].Length).ToString() + "\\3\n";
                                lastLength += name_file[key].Length;
                            }
                            sw.Write(name_file[key]);
                        }
                    }
                    sw.Write('\n');
                }

                swB.Write(blocks);
            }
            catch (Exception ex)
            { }
            finally
            {
                if (sw != null) { sw.Close(); }
                if (swB != null) { swB.Close(); }
            }

        }

        private int getCombinedSequenceLength(string[] listOfSequences)
        {
            int phyliplengths = 0;
            for (int index = 0; index < fastaFiles.Length; index++)
            {
                string key = listOfSequences[0] + "_" + fastaFiles[index].Substring(fastaFiles[index].LastIndexOf("\\") + 1);
                if (name_file.ContainsKey(key) == true)
                { phyliplengths += name_file[key].Length; }
            }
            return phyliplengths;
        }

        private string[] getListOfCommonSequences(string[] fastaFiles)
        {
            if (fastaFiles == null || fastaFiles.Length == 0) { return null; }
            System.IO.StreamReader sf = null;
            List<string> answer = new List<string>();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            name_file = new Dictionary<string, string>();
            try
            {

                name_file = new Dictionary<string, string>();
                sf = new System.IO.StreamReader(fastaFiles[0]);
                string line = "";
                string sequence = "";
                string name = "";
                while (sf.Peek() > 0)
                {
                    line = sf.ReadLine();
                    if (line.Length > 0 && line.StartsWith(">") == true)
                    {
                        line = line.Substring(1).Trim();
                        if (counts.ContainsKey(line) == false)
                        {
                            counts.Add(line, 1);
                            if (sequence.Length > 0)
                            {
                                string key = name + "_" + fastaFiles[0].Substring(fastaFiles[0].LastIndexOf("\\") + 1);
                                if (name_file.ContainsKey(key) == false)
                                { name_file.Add(key, sequence); }
                            }

                        }
                        name = line;
                        sequence = "";
                    }
                    else { sequence += line.Trim().Replace(" ", ""); }
                }

                if (sequence.Length > 0 && name.Length > 0)
                {
                    string key = name + "_" + fastaFiles[0].Substring(fastaFiles[0].LastIndexOf("\\") + 1);
                    if (name_file.ContainsKey(key) == false)
                    { name_file.Add(key, sequence); }
                }
                sequence = "";
                name = "";
                sf.Close();

                for (int index = 1; index < fastaFiles.Length; index++)
                {
                    sf = new System.IO.StreamReader(fastaFiles[index]);
                    while (sf.Peek() > 0)
                    {
                        line = sf.ReadLine();
                        if (line.Length > 0 && line.StartsWith(">") == true)
                        {
                            line = line.Substring(1).Trim();
                            if (counts.ContainsKey(line) == true)
                            {
                                counts[line]++;
                                if (sequence.Length > 0)
                                {
                                    string key = name + "_" + fastaFiles[index].Substring(fastaFiles[index].LastIndexOf("\\") + 1);

                                    if (name_file.ContainsKey(key) == false)
                                    { name_file.Add(key, sequence); }
                                }
                            }
                            name = line;
                            sequence = "";
                        }
                        else { sequence += line.Trim().Replace(" ", ""); }
                    }

                    if (sequence.Length > 0 && name.Length > 0)
                    {
                        string key = name + "_" + fastaFiles[index].Substring(fastaFiles[index].LastIndexOf("\\") + 1);
                        if (name_file.ContainsKey(key) == false)
                        { name_file.Add(key, sequence); }
                    }

                    name = "";
                    sequence = "";

                    sf.Close();
                    int most = 0;
                    List<string> deleteKey = new List<string>();
                    foreach (int v in counts.Values)
                    {
                        if (v > most)
                        { most = v; }
                    }

                    foreach (string k in counts.Keys)
                    {
                        if (counts[k] < most)
                        { deleteKey.Add(k); }
                    }

                    foreach (string k in deleteKey)
                    {
                        counts.Remove(k);
                    }
                }

                answer = new List<string>();
                foreach (string k in counts.Keys)
                { answer.Add(k); }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred reading the files" + ex.Message);
                return null;
            }
            finally { if (sf != null) { sf.Close(); } }

            return answer.ToArray();
        }

        private string[] getCommonName(string[] fastaFiles)
        {
            int shortest = int.MaxValue;
            foreach (string fastaFile in fastaFiles)
            {
                if (shortest > fastaFile.Length)
                { shortest = fastaFile.Length; }
            }

            int length = 0;
            string firstFile = fastaFiles[0];
            for (int index = 0; index < shortest; index++)
            {
                bool allSame = true;
                foreach (string fastaFile in fastaFiles)
                {
                    if (firstFile[index] != fastaFile[index])
                    { allSame = false; break; }
                }
                if (allSame == false)
                {
                    length = index;
                    break;
                }
            }

            string[] name = { firstFile.Substring(0, length), firstFile.Substring(0, length) };
            if (name[0][name.Length - 1] == '\\')
            {
                name[0] += "phylip.phy";
                name[1] += "phylip.blocks";
            }
            else
            {
                name[0] += ".phy";
                name[1] += ".blocks";
            }

            return name;
        }

        private void rboLinked_unlinked_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            if (rdo.Checked == true)
            { ValidateSettings(); }
        }

        private void rdoDNA_Protein_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = (RadioButton)sender;
            if (rdo.Checked == true)
            {                
                if(rdoDNA.Checked == true)
                {
                    checkBox1.Text = "JC";
                    checkBox2.Text = "JC+G";
                    checkBox3.Text = "HKY";
                    checkBox4.Text = "HKY+G";
                    checkBox5.Text = "GTR";
                    checkBox6.Text = "GTR+G";
                }
                else if (rdoProtein.Checked == true)
                {
                    checkBox1.Text = "LG";
                    checkBox2.Text = "LG+G";
                    checkBox3.Text = "LG+G+F";
                    checkBox4.Text = "WAG";
                    checkBox5.Text = "WAG+G";
                    checkBox6.Text = "WAG+G+F";
                }
            }
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool active = false;
            if (cboModel.SelectedIndex == 7) { active = true; }
            rdoDNA.Enabled = active;
            rdoProtein.Enabled = active;
            checkBox1.Enabled = active;
            checkBox2.Enabled = active;
            checkBox3.Enabled = active;
            checkBox4.Enabled = active;
            checkBox5.Enabled = active;
            checkBox6.Enabled = active;

            ValidateSettings();
        }

        private void btnBlockSelect_Click(object sender, EventArgs e)
        {
            string filename = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the block file made by GeneMatrix", "*.blocks|*.blocks");
            if (System.IO.File.Exists(filename) == false) {return;}

            System.IO.StreamReader sf = null;

            try 
            { 
                sf =new System.IO.StreamReader(filename);
                string[] line = null;
                

                blockLines = new List<string>();
                blockLines.AddRange(sf.ReadToEnd().Trim().Split('\n'));
                sf.Close();

                cblCodingSequences.Items.Clear();

                for (int index = 0; index < blockLines.Count; index += 4)
                {
                    line = blockLines[index].Split('\t');
                    if (line.Length > 1)
                    { cblCodingSequences.Items.Add(line[0]); }

                }
                btnCreateConfigFile.Enabled = true;
            
            }
            catch(Exception ex) { MessageBox.Show("An error occurred processing the file:" + ex.Message, "Error"); }
            finally { if (sf !=null) { sf.Close(); } }

              ValidateSettings();
        }

        private void btnCreateConfigFile_Click(object sender, EventArgs e)
        {
            string branches = "linked";
            if (rboUnlinked.Checked == true) { branches = "unlinked"; }

            string contents = "## ALIGNMENT FILE ##\nalignment = " + txtAlignmentFile.Text.Trim() + ";\n\n" +
                "## BRANCHLENGTHS: linked | unlinked ##\nbranchlengths = " + branches + ";\n\n" +
                "## MODELS OF EVOLUTION: all | allx | mrbayes | beast | gamma | gammai | <list> ##\nmodels = " + getModelString() + ";\n\n" +
                "# MODEL SELECCTION: AIC | AICc | BIC #\nmodel_selection = " + cboSelectionModel.Text + ";\n\n" +
                "## DATA BLOCKS: see manual for how to define ##\n[data_blocks]\n" + getBlockText() + "\n\n" +
                "## SCHEMES, search: all | user | greedy | rcluster | rclusterf | kmeans ##\n[schemes]\nsearch = " + cboSchemes.Text.ToLower().Replace("-","") + ";\n";

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "select configuration file name", "Phylip configuration file (*.cfg)|*.cfg", "partition_finder.cfg");
            if (fileName == "Cancel") { return; }

            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(fileName);
                sw.WriteLine(contents);
                sw.Close();
            }
            catch (Exception ex) { MessageBox.Show("An error occurred processing the file:" + ex.Message, "Error"); }
            finally { if (sw != null) { sw.Close(); } }

        }

        private string getBlockText()
        {
            string answer = "";
            List<int> checkedIndices = cblCodingSequences.CheckedIndices.Cast <int>().ToList();
            int sequenceCount = 0;
            for (int index = 0; index < blockLines.Count; index +=4)
            {
                if (checkedIndices.Contains(sequenceCount) == true)
                {
                    for (int line = 1; line < 4; line++)
                    {
                        if (line < blockLines.Count)
                        { answer += blockLines[index + line] + ";\n"; }
                    }
                }
                else
                { answer += blockLines[index] + ";\n"; }
                sequenceCount++;
            }

            int longestName = 0;
            string[] lines = answer.Split('\n');

            foreach (string l in lines)
            {
                string[] items = l.Split('\t');
                if (items.Length > 1)
                {
                    if (longestName < items[0].Length)
                    { longestName = items[0].Length; }
                }
            }

            string finalAnswer = "";
            if (longestName > 2)
            {
                longestName++;
                foreach (string l in lines)
                {
                    string[] items = l.Split('\t');
                    if (items.Length > 1)
                    {
                        finalAnswer += items[0].PadRight(longestName) + " = " + items[1] + "\n";
                    }
                }
            }


            return finalAnswer;

        }

        private string getModelString()
        {
            if (cboModel.SelectedIndex < 7)
            { return cboModel.Text.ToLower(); }

            string answer = "";
            if (checkBox1.Checked == true) { answer += checkBox1.Text + ", "; }
            if (checkBox2.Checked == true) { answer += checkBox2.Text + ", "; }
            if (checkBox3.Checked == true) { answer += checkBox3.Text + ", "; }
            if (checkBox4.Checked == true) { answer += checkBox4.Text + ", "; }
            if (checkBox5.Checked == true) { answer += checkBox5.Text + ", "; }
            if (checkBox6.Checked == true) { answer += checkBox6.Text + ", "; }

            if (answer.Length > 2)
            { answer = answer.Substring(0, answer.Length - 2); }
            return answer;
        }

            private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void ValidateSettings()
        {
            bool status = true;

            if (txtAlignmentFile.Text.Trim().Length == 0)
            { status = false; }
            else if (cboModel.SelectedIndex == 0)
            { status = false; }
            else if (cboModel.SelectedIndex == 7)
            {
                if (!(checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true || checkBox5.Checked == true || checkBox6.Checked == true))
                { status = false; }
            }
            else if (cboSchemes.SelectedIndex == 0)
            { status = false; }
            else if (cblCodingSequences.Items.Count == 0)
            { status = false; }
            else if (cboSelectionModel.SelectedIndex == 0)
            { status = false; }

            btnCreateConfigFile.Enabled = status;
        }

        private void txtAlignmentFile_TextChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void cboSchemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void cboSelectionModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void btnAlignmentFile_Click(object sender, EventArgs e)
        {
            txtAlignmentFile.Clear();

            string filename = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the Phylip alignment file", "*.phy|*.phy");
            if (System.IO.File.Exists(filename) == false) { return; }

            txtAlignmentFile.Text = filename.Substring(filename.LastIndexOf("\\")+ 1);

        }
    }
}
