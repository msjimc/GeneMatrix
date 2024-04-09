using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace GeneMatrix
{
    public partial class Form1 : Form
    {
        private  Dictionary<string, Dictionary<string, Dictionary<string, feature>>> data = new Dictionary<string, Dictionary<string, Dictionary<string, feature>>>();
        private List<string> sequenceName = null;
        private List<string> CDS = null;
        private List<string> tRNA = null;
        private List<string> rRNA = null;
        private int rightButton = 1;
        private bool quitAnalysis = false;
        
       public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            tv1.Sort();
            tv2.Sort();
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

                resetState();

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
                string fileNmae = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the genbank file", "GenBank file (*.gb;*.genbank)|*.gb;*.genbank");
                if (System.IO.File.Exists(fileNmae) == false) { return; }

                resetState();

                lblDataSource.Text = fileNmae.Substring(fileNmae.LastIndexOf("\\") + 1);
                Application.DoEvents();

                readFile(fileNmae);
            }
        }

        private void resetState()
        {
            quitAnalysis = false;
            data = new Dictionary<string, Dictionary<string, Dictionary<string, feature>>>();
            sequenceName = new List<string>();
            CDS = new List<string>();
            tRNA = new List<string>();
            rRNA = new List<string>();
            tv1.Nodes.Clear();
            tv2.Nodes.Clear();
        }

        private void readFile(string fileName)
        {
            
            System.IO.StreamReader fs = null;
            try
            {
                int startOfSequence = 0;
                List<string> lines = new List<string>();
                fs = new System.IO.StreamReader(fileName);

                while (fs.Peek()>0)
                {
                    string line = fs.ReadLine();
                    if (line.StartsWith("//") == true)
                    {
                        processData(lines, startOfSequence);
                        lines = new List<string>();
                        if (quitAnalysis == true)
                        { 
                            resetState();
                            break; 
                        }
                    }
                    else if (line.StartsWith("ORIGIN") == true)
                    {
                        lines.Add(line);
                        startOfSequence = lines.Count;
                    }
                    else { lines.Add(line); }
                }

                if (lines.Count > 2)
                {
                    processData(lines, startOfSequence);
                    lines = new List<string>();
                    if (quitAnalysis == true)
                    { resetState(); }
                }

                string empty = "";
                List<string> empltyList = new List<string>();
                foreach (string key in data.Keys)
                {
                    if (data[key].Count == 0)
                    {
                        empty += " " + key;
                        empltyList.Add(key);
                    }
                    else { sequenceName.Add(key); }
                }
                foreach (string key in empltyList)
                { data.Remove(key); }

                if (string.IsNullOrEmpty(empty) == true)
                { MessageBox.Show("Retained data on " + data.Count.ToString() + " accession sequences", "Data"); }
                else { MessageBox.Show("Retained data on " + data.Count.ToString() + " accession sequences, However no data was retianed for:" + empty, "Data"); }

                populateLists();

            }
            finally
            {
                if (fs != null) { fs.Close(); }
            }
        }

        private void processData(List<string> lines, int startOfSequence)
        {
            string sequence = getSequence(lines, startOfSequence);
            string accession = getAccession(lines);

            if (data.ContainsKey(accession) == false)
            { data.Add(accession, new Dictionary<string, Dictionary<string, feature>>()); }
            else
            {
                DialogResult result = MessageBox.Show("Accession sequence: " + accession + " appears to be in data set more then once. Do you want to stop (press Yes) or continue ignoring subsequent versions (press No)", "Duplicate accessions", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }
                else
                {
                    quitAnalysis = true;
                    return;
                }
            }
            
            int index = 0;
            int featureStart = -1;
            string featureType = "";

            while (index < startOfSequence + 1 && index < lines.Count)
            {
                if ((lines[index].StartsWith("     ") == true && lines[index][6] != ' ') || lines[index].StartsWith("ORIGIN") == true)
                {
                    if (featureStart > -1 && (featureType == "CDS" || featureType == "tRNA" || featureType == "rRNA" || lines[index] == "ORIGIN"))
                    {
                        if (data[accession].ContainsKey(featureType) == false)
                        { data[accession].Add(featureType, new Dictionary<string, feature>()); }
                        int count = data[accession][featureType].Count;
                        feature f = new feature(lines, featureStart, index, featureType, sequence, count);
                        if (data[accession][featureType].ContainsKey(f.WorkingName) == false)
                        { data[accession][featureType].Add(f.WorkingName, f); }                                                                       
                    }
                    featureType = lines[index].Substring(5, lines[index].IndexOf(" ",6) - 5);
                    featureStart = index;                    
                }
                index++;
            }
        }

        private string getAccession(List<string> lines)
        {
            for (int index = 0; index < 10;index++)
            {
                if (lines[index].StartsWith("VERSION") == true)
                {
                    string rawName=lines[index].Substring(12).Trim();
                   
                    return rawName;
                }
            }
            return "";
        }

        private string getSequence(List<string> lines, int startPoint)
        {
            StringBuilder sb = new StringBuilder();

            for (int index = startPoint; index < lines.Count;index++)
            {
                string sequenceRaw = lines[index].Substring(10).Trim().Replace(" ", "");
                
                sb.Append(sequenceRaw);
            }

            return sb.ToString();
        }

        private void populateLists()
        {
            tv1.Nodes.Clear();
            tv2.Nodes.Clear();

            foreach (string name in data.Keys)
            {
                foreach (string featureType in data[name].Keys)
                {
                    switch (featureType)
                    {
                        case "CDS":
                            foreach (feature f in data[name][featureType].Values)
                            {
                                if (CDS.Contains(f.WorkingName) == false)
                                { CDS.Add(f.WorkingName); }
                            }
                            break;
                        case "tRNA":
                            foreach (feature f in data[name][featureType].Values)
                            {
                                if (tRNA.Contains(f.WorkingName) == false)
                                { tRNA.Add(f.WorkingName); }
                            }
                            break;
                        case "rRNA":
                            foreach (feature f in data[name][featureType].Values)
                            {
                                if (rRNA.Contains(f.WorkingName) == false)
                                { rRNA.Add(f.WorkingName); }
                            }
                            break;
                    }
                }
            }
            CDS.Sort();
            tRNA.Sort();
            rRNA.Sort();


            TreeNode cds = new TreeNode("CDS");
            TreeNode trna = new TreeNode("tRNA");
            TreeNode rrna = new TreeNode("rRNA");

            foreach (string name in CDS)
            { cds.Nodes.Add(new TreeNode(name)); }

            foreach (string name in tRNA)
            { trna.Nodes.Add(new TreeNode(name)); }

            foreach (string name in rRNA)
            { rrna.Nodes.Add(new TreeNode(name)); }

            TreeNode tv1parent = new TreeNode("Sequences");
            tv1.Nodes.Add(tv1parent);

            TreeNode tv2parent = new TreeNode("Sequences");
            tv2.Nodes.Add(tv2parent);
            
            if (cds.Nodes.Count > 0)
            { 
                tv1parent.Nodes.Add(cds);
                tv2parent.Nodes.Add(new TreeNode("CDS"));
            }

            if (trna.Nodes.Count > 0)
            { 
                tv1parent.Nodes.Add(trna); 
                tv2parent.Nodes.Add(new TreeNode("tRNA"));
            }

            if (rrna.Nodes.Count > 0)
            { 
                tv1parent.Nodes.Add(rrna);
                tv2parent.Nodes.Add(new TreeNode("rRNA"));
            }

            tv1parent.Expand();
            tv2parent.Expand();
        }

        private void tv1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tv1.SelectedNode.Parent == null || tv1.SelectedNode.Parent.Text == "Sequences") { return; }
            tv1.SelectedNode.Checked = !tv1.SelectedNode.Checked;
        }

        private void tv2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (rightButton == 1)
            { moveTooRight(); }           
        }

        private void moveTooLeft()
        {
            TreeNode n = tv2.SelectedNode;
            string featureType = (string)n.Tag;
            
            foreach (TreeNode pN in tv1.Nodes[0].Nodes)
            {
                if (pN.Text == featureType)
                { 
                    n.Parent.Nodes.Remove(n);
                    pN.Nodes.Add(n);
                    if (n.Nodes.Count > 0)
                    {
                        List<TreeNode> children = new List<TreeNode>();
                        foreach (TreeNode cN in n.Nodes)
                        { children.Add(cN); }

                        foreach(TreeNode cN in children)
                        {
                            n.Nodes.Remove(cN);
                            pN.Nodes.Add(cN);
                        }
                    }
                }
            }
            tv2.SelectedNode = tv2.Nodes[0];

            btnSave.Enabled = false;
            foreach (TreeNode fN in tv2.Nodes[0].Nodes)
            {
                if (fN.Nodes.Count >0)
                { btnSave.Enabled = true; }
            }

        }

        private void moveTooRight()
        { 
            string featureType = "";
            if (tv2.SelectedNode.Parent == null)
            { return; }
            else if (tv2.SelectedNode.Parent.Text == "Sequences")
            { featureType = tv2.SelectedNode.Text; }
            else if (tv2.SelectedNode.Parent.Parent.Text == "Sequences")
            { featureType = tv2.SelectedNode.Parent.Text; }
            else
            { return; }

            List<TreeNode> names = new List<TreeNode>();

            tv1.SelectedNode= null;

            foreach (TreeNode n in tv1.Nodes[0].Nodes)
            {
                if (n.Text == featureType)
                {
                    foreach (TreeNode donor in n.Nodes)
                    {
                        donor.Tag = featureType;
                        if (donor.Checked == true)
                        { names.Add(donor); }
                    }
                    foreach (TreeNode name in names)
                    {  
                        n.Nodes.Remove(name);
                        tv2.SelectedNode.Nodes.Add(name);
                        name.Checked = false;
                    }                   

                }
            }
            tv2.SelectedNode = tv2.Nodes[0];
            btnSave.Enabled = true;
        }
               
        private void tv2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            { rightButton = 1; }
            else if (e.Button == MouseButtons.Right)
            { rightButton = 2; }
            else { rightButton = 0; }
        }

        private void tv2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { 
                tv2.SelectedNode = e.Node;
                moveTooLeft();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            populateLists();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder to save sequences too", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }
            Dictionary<string, int> lengths = new Dictionary<string, int>();

            List<string> listOfFilesToDelete = new List<string>();

            foreach (TreeNode fN in tv2.Nodes[0].Nodes)
            {
                string featureType = fN.Text;
                foreach (TreeNode nN in fN.Nodes)
                {
                    List<string> names = new List<string>();
                    names.Add(nN.Text);
                    foreach (TreeNode nnN in nN.Nodes)
                    { names.Add(nnN.Text); }
                    
                    foreach (string name in sequenceName)
                    {
                        foreach (string featureName in names)
                        {
                            if (data[name][featureType].ContainsKey(featureName) == true)
                            {
                                if (rboBoth.Checked == true || rboDNA.Checked == true)
                                {
                                    int length = data[name][featureType][featureName].getDNASequence.Length;
                                    string key = featureType + "|" + names[0] + "|" + "D";
                                    if (lengths.ContainsKey(key) == true)
                                    {
                                        if (lengths[key] < length)
                                        { lengths[key] = length; }
                                    }
                                    else
                                    { 
                                        lengths.Add(key, length);
                                        if (listOfFilesToDelete.Contains(folder + "\\" + featureType + "-" + names[0] + "_DNA.fasta") == false)
                                        { listOfFilesToDelete.Add(folder + "\\" + featureType + "-" + names[0] + "_DNA.fasta"); }
                                    }
                                }
                                if (rboBoth.Checked==true || rboProtein.Checked == true)
                                {
                                    int length = data[name][featureType][featureName].getProteinSequence.Length;
                                    string key = featureType + "|" + names[0] + "|" + "P";
                                    if (lengths.ContainsKey(key) == true)
                                    {
                                        if (lengths[key] < length)
                                        { lengths[key] = length; }
                                    }
                                    else
                                    { 
                                        lengths.Add(key, length);
                                        if (listOfFilesToDelete.Contains(folder + "\\" + featureType + "-" + names[0] + "_protein.fasta") == false)
                                        { listOfFilesToDelete.Add(folder + "\\" + featureType + "-" + names[0] + "_protein.fasta"); }
                                    }
                                }
                            }                            
                        }
                    }
                }
            }

            foreach (string file in listOfFilesToDelete)
            {
                if (System.IO.File.Exists(file) == true)
                { System.IO.File.Delete(file); }
            }

            char padding = ' ';
            if (false) { padding = '-'; }

            foreach (TreeNode fN in tv2.Nodes[0].Nodes)
            {
                string featureType = fN.Text;
                foreach (TreeNode nN in fN.Nodes)
                {
                    List<string> names = new List<string>();
                    names.Add(nN.Text);
                    foreach (TreeNode nnN in nN.Nodes)
                    { names.Add(nnN.Text); }

                    foreach (string name in sequenceName)
                    {
                        string DNA = "";
                        string protein = "";
                        foreach (string featureName in names)
                        {
                            if (data[name][featureType].ContainsKey(featureName) == true)
                            {
                                if (rboBoth.Checked == true || rboDNA.Checked == true)
                                {
                                    if (string.IsNullOrEmpty(DNA) == true)
                                    {
                                        DNA = data[name][featureType][featureName].getDNASequence;
                                        DNA = DNA + new string(padding, lengths[featureType + "|" + names[0] + "|" + "D"] - DNA.Length);
                                    }
                                }
                                if (rboBoth.Checked == true || rboProtein.Checked == true)
                                {
                                    if (string.IsNullOrEmpty(protein) == true)
                                    {
                                        protein = data[name][featureType][featureName].getProteinSequence;
                                        protein = protein + new string(padding, lengths[featureType + "|" + names[0] + "|" + "P"] - protein.Length);
                                    }
                                }
                            }
                        }

                        if ((rboBoth.Checked == true || rboDNA.Checked == true) && lengths.ContainsKey(featureType + "|" + names[0] + "|" + "D")==true)
                        {
                            if (string.IsNullOrEmpty(DNA) == true)
                            { DNA = new string(padding, lengths[featureType + "|" + names[0] + "|" + "D"]); }
                            System.IO.StreamWriter fw = new System.IO.StreamWriter(folder + "\\" + featureType + "-" + names[0] + "_DNA.fasta", true);
                            fw.Write(">" + name + "\n" + DNA + "\n");
                            fw.Close();
                        }
                        if ((rboBoth.Checked == true || rboProtein.Checked == true) && lengths.ContainsKey(featureType + "|" + names[0] + "|" + "P") == true)
                        {
                            if (string.IsNullOrEmpty(protein) == true)
                            { protein = new string(padding, lengths[featureType + "|" + names[0] + "|" + "p"]); }
                            System.IO.StreamWriter fw = new System.IO.StreamWriter(folder + "\\" + featureType + "-" + names[0] + "_protein.fasta", true);
                            fw.Write(">" + name + "\n" + protein + "\n");
                            fw.Close();
                        }
                    }                    
                }
            }

        }

        private string getClustalWFileName()
        {
            if (chkResetPrograms.Checked == false)
            {
                string ClustalW = Properties.Settings.Default.ClustalW;
                if (System.IO.File.Exists(ClustalW) == true)
                { return ClustalW; }

                string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                location = location.Substring(8);
                location = location.Replace("/", "\\");
                location = location.Substring(0, location.LastIndexOf('\\'));
                string program = location + "\\clustalw2.exe";

                if (System.IO.File.Exists(program) == true)
                {
                    Properties.Settings.Default.ClustalW = program;
                    Properties.Settings.Default.Save();
                    return program;
                }
            }

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the ClustalW2.exe executable file", "program (*.exe)|*.exe");
            if (System.IO.File.Exists(fileName) == true)
            {
                Properties.Settings.Default.Muscle = fileName;
                Properties.Settings.Default.Save();
                return fileName;
            }
            else
            {
                MessageBox.Show("The ClustalW2.exe executable is required for this function, see user guide for more information", "No external aligner");
                return null;
            }
        }

        private void btnClustalW_Click(object sender, EventArgs e)
        {
            string program = getClustalWFileName();
            if (program == null) { return; }

            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder containing the sequences", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }

            string[] files = System.IO.Directory.GetFiles(folder, "*_DNA.fasta");
            if (files.Length > 0)
            { runClustalw(program, folder, files, "DNA"); }

            files = System.IO.Directory.GetFiles(folder, "*_protein.fasta");
            if (files.Length > 0)
            { runClustalw(program, folder, files, "PROTEIN"); }
        }

        private void runClustalw(string program, string folder, string[] files, string sequenceType)
        {
            System.IO.StreamWriter fw = null;
            string fileName = folder + "\\cmd_ClustalW.bat";
            try
            {               
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        fw = new System.IO.StreamWriter(fileName);
                        string answer = file.Substring(0, file.Length - 6) + "_ClustalW.fasta";
                        fw.WriteLine("\"" + program + "\" -INFILE=\"" + file + "\" -TYPE="+ sequenceType + " -OUTPUT=FASTA -OUTFILE=\"" + answer + "\"");
                        fw.Close();

                        lblStatus.Text = "Status: " + answer.Substring(answer.LastIndexOf('\\') + 1);
                        Application.DoEvents();
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + fileName);
                        info.UseShellExecute = false;
                        info.CreateNoWindow = ! chkShowCMD.Checked;

                        process.StartInfo = info;

                        process.Start();
                        process.WaitForExit();
                    }
                }

               
                if (chkAggregate.Checked == true)
                {
                    lblStatus.Text = "Status: Combining alignments";
                    Application.DoEvents();
                    CombineAlignments(folder, files, "clustalw"); 
                }

                lblStatus.Text = "Status: Done";
                Application.DoEvents();

            }
            catch (Exception ex)
            { }
            finally
            {
                if (fw != null) { fw.Close(); }
            }

            if (System.IO.File.Exists(fileName) == true)
            { System.IO.File.Delete(fileName); }

        }

        private string getMuscleFileName()
        {
            if (chkResetPrograms.Checked == false)
            {
                string Muscle = Properties.Settings.Default.Muscle;
                if (System.IO.File.Exists(Muscle) == true)
                { return Muscle; }

                string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                location = location.Substring(8);
                location = location.Replace("/", "\\");
                location = location.Substring(0, location.LastIndexOf('\\'));
                string program = location + "\\muscle5.1.win64.exe";

                if (System.IO.File.Exists(program) == true)
                {
                    Properties.Settings.Default.Muscle = program;
                    Properties.Settings.Default.Save();
                    return program;
                }
            }

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the Muscle executable file", "program (*.exe)|*.exe");
            if (System.IO.File.Exists (fileName) == true)
            {
                Properties.Settings.Default.Muscle = fileName;
                Properties.Settings.Default.Save();
                return fileName; 
            }
            else 
            {
                MessageBox.Show("The Muscle executable is required for this function, see user guide for more information", "No external aligner");
                return null; 
            }
        }

        private void btnMuscle_Click(object sender, EventArgs e)
        {            
            string program = getMuscleFileName();
            if (program == null) { return; }

            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder containing the sequences", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }

            string[] files = System.IO.Directory.GetFiles(folder, "*_DNA.fasta");
            if (files.Length > 0)
            { runMuscle(program, folder, files); }

            files = System.IO.Directory.GetFiles(folder, "*_protein.fasta");
            if (files.Length > 0)
            { runMuscle(program, folder, files); }
        }

        private void runMuscle(string program, string folder, string[] files)
        {
            System.IO.StreamWriter fw = null;
            string fileName = folder + "\\cmd_Muscle.bat";
            try
            {
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        fw = new System.IO.StreamWriter(fileName);
                        string answer = file.Substring(0, file.Length - 6) + "_Muscle.fasta";
                        fw.WriteLine("\"" + program + "\" -align \"" + file + "\" -output \"" + answer + "\"");
                        fw.Close();

                        lblStatus.Text = "Status: " + answer.Substring(answer.LastIndexOf('\\') + 1);
                        Application.DoEvents();
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + fileName);
                        info.UseShellExecute = false;
                        info.CreateNoWindow = !chkShowCMD.Checked;

                        process.StartInfo = info;

                        process.Start();
                        process.WaitForExit();
                    }
                }

               if (chkAggregate.Checked == true)
                {
                    lblStatus.Text = "Status: Combining alignments";
                    Application.DoEvents();
                    CombineAlignments(folder, files, "muscle"); 
                }

                lblStatus.Text = "Status: Done";
                Application.DoEvents();
                
            }
            catch (Exception ex)
            { }
            finally
            {
                if (fw != null) { fw.Close(); }
            }

            if (System.IO.File.Exists(fileName) == true)
            { System.IO.File.Delete(fileName); }

        }

        private void CombineAlignments(string folder, string[] files, string program)
        {
            System.IO.StreamReader fs = null;
            System.IO.StreamWriter fw = null;

            try
            {
                Dictionary<string, string> sequences = new Dictionary<string, string>();

                foreach (string file in files)
                {
                    string alignedFile = "";
                    if (program == "muscle")
                    { alignedFile = file.Substring(0, file.Length - 6) + "_Muscle.fasta"; }
                    else if (program == "clustalw")
                    { alignedFile = file.Substring(0, file.Length - 6) + "_ClustalW.fasta"; }
                    
                    fs = new System.IO.StreamReader(alignedFile);
                    string line = "";

                    string accession = "";
                    while (fs.Peek() > 0)
                    {
                        line=fs.ReadLine();
                        if (line.StartsWith(">") == true)
                        {
                            accession = line.Substring(1).Trim();
                            if (sequences.ContainsKey(accession) == false)
                            { sequences.Add(accession,""); }
                        }
                        else if (accession != "")
                        {
                            sequences[accession] += line.Trim();
                        }
                    }
                    fs.Close();

                    int length = 0;
                    foreach (string v in sequences.Values)
                    { 
                        if (length < v.Length) 
                        { length = v.Length;}
                    }
                    foreach (string key in sequences.Keys)
                    {
                        if (length < sequences[key].Length)
                        { sequences[key] +=  new string('-', length - sequences[key].Length); }
                    }
                }

                string exportName = folder + "\\";
                if (program == "muscle")
                { exportName += "Muscle.fasta"; }
                else if (program == "clustalw")
                { exportName += "ClustalW.fasta"; }

                fw = new System.IO.StreamWriter(exportName);
                foreach (string key in sequences.Keys)
                {
                    fw.Write(">" + key + "\n" + sequences[key] + "\n");
                }

            }
            catch (Exception ex)
            { }
            finally
            {
                if (fs != null) { fs.Close(); }
                if (fw != null) { fw.Close(); }
            }
        }
    }
}
