using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GeneMatrix
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Dictionary<string, Dictionary<string, feature>>> data = new Dictionary<string, Dictionary<string, Dictionary<string, feature>>>();
        private List<string> sequenceName = null;
        private List<string> CDS = null;
        private List<string> tRNA = null;
        private List<string> rRNA = null;
        private List<string> Unknown = null;
        private int rightButton = 1;
        private bool quitAnalysis = false;
        private string gblocks = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Width / 2;
            tv1.Sort();
            tv2.Sort();

            SetTreeviewImages();
        }
        private void SetTreeviewImages()
        {
            Bitmap NotSelected = new Bitmap(10, 10, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(NotSelected);
            g.Clear(tv1.BackColor);
            g.FillEllipse(Brushes.LightGray, 0, 0, 10, 10);
            g = null;

            Bitmap Selected = new Bitmap(10, 10, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(Selected);
            g.Clear(tv1.BackColor);
            g.FillEllipse(Brushes.Green, 0, 0, 10, 10);
            g = null;


            ImageList myImageList = new ImageList();

            myImageList.Images.Add(NotSelected);
            myImageList.Images.Add(Selected);
            tv1.ImageList = myImageList;
            tv1.ImageIndex = 0;

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            string empty = "";

            if (chkFolder.Checked == true)
            {
                string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder of GenBank and fasta files", "");
                if (System.IO.Directory.Exists(folder) == false) { return; }

                resetState();

                lblDataSource.Text = folder.Substring(folder.LastIndexOf("\\") + 1);
                Application.DoEvents();

                string[] gb = System.IO.Directory.GetFiles(folder, "*.gb");
                string[] genbank = System.IO.Directory.GetFiles(folder, "*.genbank");
                string[] fasta = System.IO.Directory.GetFiles(folder, "*.fasta");
                string[] fa = System.IO.Directory.GetFiles(folder, "*.fa");


                if (gb.Length > 0)
                {
                    foreach (string f in gb)
                    { empty = readFile(f, empty); }
                }

                if (genbank.Length > 0)
                {
                    foreach (string f in genbank)
                    { empty += readFile(f, empty); }
                }

                if (fa.Length > 0)
                {
                    foreach (string f in fa)
                    { empty += readFAFile(f, empty); }
                }

                if (fasta.Length > 0)
                {
                    foreach (string f in fasta)
                    { empty += readFAFile(f, empty); }
                }
            }
            else
            {
                string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the genbank file", "GenBank file (*.gb;*.genbank)|*.gb;*.genbank|List of NCBI accession IDs (*.txt)|*.txt");
                if (System.IO.File.Exists(fileName) == false) { return; }

                resetState();

                lblDataSource.Text = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                Application.DoEvents();
                if (fileName.Substring(fileName.LastIndexOf('.')).ToLower() == ".txt")
                { empty = listOfAccessionID(fileName, empty); }
                else                    
                { empty = readFile(fileName, empty);}
            }

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



            if (data.Count > 0)
            {
                populateLists();
                btnReset.Enabled = true;
            }

            if (string.IsNullOrEmpty(empty) == true)
            { MessageBox.Show("Retained data on " + data.Count.ToString() + " accession sequences", "Data"); }
            else { MessageBox.Show("Retained data on " + data.Count.ToString() + " accession sequences, However no data was retained for:" + empty, "Data"); }

        }

        private void resetState()
        {
            quitAnalysis = false;
            data = new Dictionary<string, Dictionary<string, Dictionary<string, feature>>>();
            sequenceName = new List<string>();
            CDS = new List<string>();
            tRNA = new List<string>();
            rRNA = new List<string>();
            Unknown = new List<string>();
            tv1.Nodes.Clear();
            tv2.Nodes.Clear();
        }

       private string  listOfAccessionID(string fileName,string empty)
        {
            string errorList = "";
            string titleText = Text;
            System.IO.StreamReader fs = null;
            try
            {
                DateTime startTime= DateTime.Now;
                btnImport.Enabled = false;
                
                fs =new System.IO.StreamReader(fileName);
                string accession = null;
                WebClient client = new WebClient();

                while (fs.Peek() >0)
                {
                    accession = fs.ReadLine().Trim();
                    try
                    {
                        Text = "Importing: " + accession;
                        Application.DoEvents();
                        string url = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/efetch.fcgi?db=nuccore&id=" + accession + "&rettype=gb&retmode=text\r\n";
                        
                        string content = client.DownloadString(url);
                        
                        List<string> lines = new List<string>();
                        List<string> fileData = new List<string>();
                        
                        fileData.AddRange(content.Split('\n'));

                        int startOfSequence = 0;

                        if (fileData.Count > 2)
                        {
                            for (int index = 0; index < fileData.Count; index++)
                            {
                                string line = fileData[index];
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
                                else 
                                { lines.Add(line); }
                            }                           
                        }
                        DateTime endTime = DateTime.Now;
                        TimeSpan elapsedTime = endTime - startTime;
                        if (elapsedTime.TotalMilliseconds < 350)
                        { Thread.Sleep(360 - (int)elapsedTime.TotalMilliseconds); }
                    }
                    catch (Exception ex)
                    { errorList+= accession + ": " + ex.Message + "\r\n"; }
                }                                                 
            }
            finally
            {
                Text = titleText;
                btnImport.Enabled = true;
                if (fs != null) { fs.Close(); }
            }           

            if (errorList != "")
            { 
                Downloaderrors de = new Downloaderrors(errorList); 
                de.ShowDialog();
            }

            return empty;
        }
        private string readFile(string fileName, string empty)
        {

            System.IO.StreamReader fs = null;
            try
            {
                int startOfSequence = 0;
                List<string> lines = new List<string>();
                fs = new System.IO.StreamReader(fileName);

                while (fs.Peek() > 0)
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
            }
            finally
            {
                if (fs != null) { fs.Close(); }
            }
            return empty;
        }

        private string readFAFile(string fileName, string empty)
        {
            System.IO.StreamReader fs = null;
            try
            {
                fs = new System.IO.StreamReader(fileName);
                string makeAccession = (data.Count + 1).ToString(); ;
                string name = "";
                string sequence = "";
                string organism = fileName.Substring(fileName.LastIndexOf("\\") + 1);
                organism = organism.Substring(0, organism.LastIndexOf("."));

                while (fs.Peek() > 0)
                {
                    string line = fs.ReadLine();
                    if (line.StartsWith(">") == true)
                    {
                        if (sequence.Length > 0)
                        {
                            if (data.ContainsKey(makeAccession) == false)
                            { data.Add(makeAccession, new Dictionary<string, Dictionary<string, feature>>()); }
                            if (data[makeAccession].ContainsKey("Unknown") == false)
                            { data[makeAccession].Add("Unknown", new Dictionary<string, feature>()); }
                            int count = data[makeAccession]["Unknown"].Count;

                            try
                            {
                                feature f = new feature(name, sequence, organism);
                                if (data[makeAccession]["Unknown"].ContainsKey(f.WorkingName) == false)
                                { data[makeAccession]["Unknown"].Add(f.WorkingName, f); }
                            }
                            catch (Exception ex) { }
                        }
                        name = line;
                        sequence = "";
                    }
                    else
                    {
                        sequence += line.Trim();
                    }
                }

                if (sequence.Length > 0 && name.Length > 0)
                {
                    if (data.ContainsKey(makeAccession) == false)
                    { data.Add(makeAccession, new Dictionary<string, Dictionary<string, feature>>()); }
                    if (data[makeAccession].ContainsKey("Unknown") == false)
                    { data[makeAccession].Add("Unknown", new Dictionary<string, feature>()); }
                    int count = data[makeAccession]["Unknown"].Count;

                    try
                    {
                        feature f = new feature(name, sequence, organism);
                        if (data[makeAccession]["Unknown"].ContainsKey(f.WorkingName) == false)
                        { data[makeAccession]["Unknown"].Add(f.WorkingName, f); }
                    }
                    catch (Exception ex) { }

                    name = "";
                    sequence = "";
                }
            }
            finally
            {
                if (fs != null) { fs.Close(); }
            }

            return empty;

        }

        private void processData(List<string> lines, int startOfSequence)
        {
            string sequence = getSequence(lines, startOfSequence);
            string accession = getAccession(lines);
            string organism = getOrganism(lines);

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
                        try
                        {
                            feature f = new feature(lines, featureStart, index, featureType, organism, sequence, count);
                            if (data[accession][featureType].ContainsKey(f.WorkingName) == false)
                            { data[accession][featureType].Add(f.WorkingName, f); }
                        }
                        catch (Exception ex) { }
                    }
                    featureType = lines[index].Substring(5, lines[index].IndexOf(" ", 6) - 5);
                    featureStart = index;
                }
                index++;
            }
        }

        private string getAccession(List<string> lines)
        {
            for (int index = 0; index < 10; index++)
            {
                if (index < lines.Count)
                {
                    if (lines[index].StartsWith("VERSION") == true)
                    {
                        string rawName = lines[index].Substring(12).Trim();

                        return rawName;
                    }
                }
            }
            return "";
        }

        private string getOrganism(List<string> lines)
        {
            for (int index = 0; index < 15; index++)
            {
                if (index < lines.Count)
                {
                    if (lines[index].StartsWith("  ORGANISM") == true)
                    {
                        string rawName = lines[index].Substring(12).Trim();

                        return rawName;
                    }
                }
            }
            return "";

        }

        private string getSequence(List<string> lines, int startPoint)
        {
            StringBuilder sb = new StringBuilder();

            for (int index = startPoint; index < lines.Count; index++)
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
                        case "Unknown":
                            foreach (feature f in data[name][featureType].Values)
                            {
                                if (Unknown.Contains(f.WorkingName) == false)
                                { Unknown.Add(f.WorkingName); }
                            }
                            break;
                    }
                }
            }

            TreeNode cds = new TreeNode("CDS", -1, -1);
            TreeNode trna = new TreeNode("tRNA", -1, -1);
            TreeNode rrna = new TreeNode("rRNA", -1, -1);
            TreeNode unknown = new TreeNode("Unknown", -1, -1);

            if (CDS != null)
            {
                CDS.Sort();
                foreach (string name in CDS)
                {
                    TreeNode n = new TreeNode(name, 0, 0);
                    n.Tag = "CDS";
                    cds.Nodes.Add(n); 
                }
            }

            if (tRNA != null)
            {
                tRNA.Sort();
                foreach (string name in tRNA)
                {
                    TreeNode n = new TreeNode(name, 0, 0);
                    n.Tag = "tRNA"; 
                    trna.Nodes.Add(n); 
                }
            }

            if (rRNA != null)
            {
                rRNA.Sort();
                foreach (string name in rRNA)
                {
                    TreeNode n = new TreeNode(name, 0, 0);
                    n.Tag = "rRNA"; 
                    rrna.Nodes.Add(n); 
                }
            }

            if (Unknown != null)
            {
                Unknown.Sort();
                foreach (string name in Unknown)
                {
                    TreeNode n = new TreeNode(name, 0, 0);
                    n.Tag = "Unknown"; 
                    unknown.Nodes.Add(n); 
                }
            }

            TreeNode tv1parent = new TreeNode("Sequences", -1, -1);
            tv1.Nodes.Add(tv1parent);

            TreeNode tv2parent = new TreeNode("Sequences");
            tv2.Nodes.Add(tv2parent);

            if (cds.Nodes.Count > 0)
            { tv1parent.Nodes.Add(cds); }
            tv2parent.Nodes.Add(new TreeNode("CDS"));


            if (trna.Nodes.Count > 0)
            { tv1parent.Nodes.Add(trna); }
            tv2parent.Nodes.Add(new TreeNode("tRNA"));


            if (rrna.Nodes.Count > 0)
            { tv1parent.Nodes.Add(rrna); }
            tv2parent.Nodes.Add(new TreeNode("rRNA"));

            if (unknown.Nodes.Count > 0)
            { tv1parent.Nodes.Add(unknown); }

            tv1parent.Expand();
            tv2parent.Expand();
        }

        private void tv1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null || e.Node.Parent.Text == "Sequences") { return; }
            TreeNode n = e.Node;
            n.Checked = !n.Checked;
            if (n.Checked == true)
            {
                n.ImageIndex = 1;
                n.SelectedImageIndex = 1;
            }
            else
            {
                n.ImageIndex = 0;
                n.SelectedImageIndex = 0;
            }
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

                        foreach (TreeNode cN in children)
                        {
                            n.Nodes.Remove(cN);
                            foreach (TreeNode pnn in tv1.Nodes[0].Nodes)
                            {
                                if ((string)cN.Tag == pnn.Text)
                                { pnn.Nodes.Add(cN);}
                            }                            
                        }
                    }
                }
            }
            tv2.SelectedNode = tv2.Nodes[0];

            btnSave.Enabled = false;
            foreach (TreeNode fN in tv2.Nodes[0].Nodes)
            {
                if (fN.Nodes.Count > 0)
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

            tv1.SelectedNode = null;

            foreach (TreeNode n in tv1.Nodes[0].Nodes)
            {
                if (n.Text == featureType || n.Text == "Unknown")
                {
                    foreach (TreeNode donor in n.Nodes)
                    {
                        if (n.Text != "Unknown")
                        { donor.Tag = featureType; }
                        else
                        { donor.Tag = "Unknown"; }

                        if (donor.Checked == true)
                        {
                            donor.ImageIndex = 0;
                            donor.SelectedImageIndex = 0;
                            names.Add(donor);
                        }
                    }
                    foreach (TreeNode name in names)
                    {
                        n.Nodes.Remove(name);
                        name.ImageIndex = -1;
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
                        string featureName = "NoIn";
                        foreach (string testName in names)
                        {
                            if (data[name].ContainsKey(featureType) == true && data[name][featureType].ContainsKey(testName) == true)
                            {
                                featureName = testName;
                                break;
                            }
                        }

                        if (data[name].ContainsKey(featureType) == true && data[name][featureType].ContainsKey(featureName) == true)
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
                                    if (listOfFilesToDelete.Contains(cleanFileNames(folder, featureType + "-" + names[0] + "_DNA.fasta")) == false)
                                    { listOfFilesToDelete.Add(cleanFileNames(folder, featureType + "-" + names[0] + "_DNA.fasta")); }
                                }
                            }
                            if (rboBoth.Checked == true || rboProtein.Checked == true)
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
                                    if (listOfFilesToDelete.Contains(cleanFileNames(folder, featureType + "-" + names[0] + "_protein.fasta")) == false)
                                    { listOfFilesToDelete.Add(cleanFileNames(folder, featureType + "-" + names[0] + "_protein.fasta")); }
                                }
                            }


                            if (data[name].ContainsKey("Unknown") == true && data[name]["Unknown"].ContainsKey(featureName) == true)
                            {
                                if (rboBoth.Checked == true || rboDNA.Checked == true)
                                {
                                    int length = data[name]["Unknown"][featureName].getDNASequence.Length;
                                    string key = featureType + "|" + names[0] + "|" + "D";
                                    if (lengths.ContainsKey(key) == true)
                                    {
                                        if (lengths[key] < length)
                                        { lengths[key] = length; }
                                    }
                                    else
                                    {
                                        lengths.Add(key, length);
                                        if (listOfFilesToDelete.Contains(cleanFileNames(folder, featureType + "-" + names[0] + "_DNA.fasta")) == false)
                                        { listOfFilesToDelete.Add(cleanFileNames(folder, featureType + "-" + names[0] + "_DNA.fasta")); }
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
                        string species = "";
                        string DNA = "";
                        string protein = "";
                        string featureName = "NoIn";
                        foreach (string testName in names)
                        {
                            if (data[name].ContainsKey(featureType) == true && data[name][featureType].ContainsKey(testName) == true)
                            {
                                featureName = testName;
                                break;
                            }
                        }

                        if (data[name].ContainsKey(featureType) == true && data[name][featureType].ContainsKey(featureName) == true)
                        {
                            species = data[name][featureType][featureName].getOrganism.Replace(" ", "_");
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
                        else if (data[name].ContainsKey("Unknown") == true && data[name]["Unknown"].ContainsKey(featureName) == true)
                        {
                            species = data[name]["Unknown"][featureName].getOrganism.Replace(" ", "_");
                            if (rboBoth.Checked == true || rboDNA.Checked == true)
                            {
                                if (string.IsNullOrEmpty(DNA) == true)
                                {
                                    DNA = data[name]["Unknown"][featureName].getDNASequence;
                                    DNA = DNA + new string(padding, lengths[featureType + "|" + names[0] + "|" + "D"] - DNA.Length);
                                }
                            }
                        }
                    
                        

                        if ((rboBoth.Checked == true || rboDNA.Checked == true) && lengths.ContainsKey(featureType + "|" + names[0] + "|" + "D") == true)
                        {
                            if (string.IsNullOrEmpty(DNA) == true && chkIgnoreEmptySequence.Checked == false)
                            {
                                DNA = new string('n', lengths[featureType + "|" + names[0] + "|" + "D"]);
                                System.IO.StreamWriter fw = new System.IO.StreamWriter(cleanFileNames(folder, featureType + "-" + names[0] + "_DNA.fasta"), true);
                                fw.Write(">" + name + "-" + species + "\n" + DNA + "\n");
                                fw.Close();
                            }
                            else if (string.IsNullOrEmpty(DNA) == false)
                            {
                                System.IO.StreamWriter fw = new System.IO.StreamWriter(cleanFileNames(folder, featureType + "-" + names[0] + "_DNA.fasta"), true);
                                fw.Write(">" + name + "-" + species + "\n" + DNA + "\n");
                                fw.Close();
                            }
                        }
                        if ((rboBoth.Checked == true || rboProtein.Checked == true) && lengths.ContainsKey(featureType + "|" + names[0] + "|" + "P") == true)
                        {
                            if (string.IsNullOrEmpty(protein) == true && chkIgnoreEmptySequence.Checked == false)
                            {
                                protein = new string('x', lengths[featureType + "|" + names[0] + "|" + "P"]);
                                System.IO.StreamWriter fw = new System.IO.StreamWriter(cleanFileNames(folder, featureType + "-" + names[0] + "_protein.fasta"), true);
                                fw.Write(">" + name + "-" + species + "\n" + protein + "\n");
                                fw.Close();
                            }
                            else if (string.IsNullOrEmpty(protein) == false)
                            {
                                System.IO.StreamWriter fw = new System.IO.StreamWriter(cleanFileNames(folder, featureType + "-" + names[0] + "_protein.fasta"), true);
                                fw.Write(">" + name + "-" + species + "\n" + protein + "\n");
                                fw.Close();
                            }
                        }
                    }
                }
            }

        }

        private string cleanFileNames(string folder, string fileName)
        {
            StringBuilder sb = new StringBuilder(fileName.Length);

            foreach (char c in fileName)
            {
                if (char.IsLetterOrDigit(c))
                { sb.Append(c); }
                else if (c == '_' || c == '-' || c == ' ' || c == '.')
                { sb.Append(c); }
                else { sb.Append('_'); }
            }
            fileName = sb.ToString().Replace("__", "_");

            return folder + "\\" + fileName;
        }

        private bool checkFile(string fileName)
        {
            if (System.IO.File.Exists(fileName) == false)
            { return false; }

            string name = fileName.Substring(fileName.LastIndexOf("\\") + 1);

            if (name.ToLower().Contains("muscle") == true)
            { return false; }
            else if (fileName.ToLower().Contains("clustalw") == true)
            { return false; }
            else if (fileName.ToLower().Contains("prank") == true)
            { return false; }
            else if (fileName.ToLower().Contains("mafft") == true)
            { return false; }

            return true;

        }

        private string getGBlocksFileName()
        {
            if (chkResetPrograms.Checked == false)
            {
                string GBlocks = Properties.Settings.Default.GBlocks;
                if (System.IO.File.Exists(GBlocks) == true)
                { return GBlocks; }

                string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                location = location.Substring(8);
                location = location.Replace("/", "\\");
                location = location.Substring(0, location.LastIndexOf('\\'));
                string program = location + "\\Gblocks.exe";

                if (System.IO.File.Exists(program) == true)
                {
                    Properties.Settings.Default.GBlocks = program;
                    Properties.Settings.Default.Save();
                    return program;
                }
            }

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the GBlocks executable file", "program (*.exe)|*.exe");
            if (System.IO.File.Exists(fileName) == true)
            {
                Properties.Settings.Default.GBlocks = fileName;
                Properties.Settings.Default.Save();
                return fileName;
            }
            else
            {
                MessageBox.Show("The GBlocks executable file is required for this function, see user guide for more information", "No external aligner cleaner");
                return null;
            }
        }


        private string getMAFFTFileName()
        {
            if (chkResetPrograms.Checked == false)
            {
                string MAFFT = Properties.Settings.Default.MAFFT;
                if (System.IO.File.Exists(MAFFT) == true)
                { return MAFFT; }

                string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                location = location.Substring(8);
                location = location.Replace("/", "\\");
                location = location.Substring(0, location.LastIndexOf('\\'));
                string program = location + "\\mafft.bat";

                if (System.IO.File.Exists(program) == true)
                {
                    Properties.Settings.Default.MAFFT = program;
                    Properties.Settings.Default.Save();
                    return program;
                }
            }

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the mafft.bat executable file", "program (*.bat)|*.bat");
            if (System.IO.File.Exists(fileName) == true)
            {
                Properties.Settings.Default.MAFFT = fileName;
                Properties.Settings.Default.Save();
                return fileName;
            }
            else
            {
                MessageBox.Show("The mafft.bat batch file is required for this function, see user guide for more information", "No external aligner");
                return null;
            }
        }

        private void btnMAFFT_Click(object sender, EventArgs e)
        {
            string program = getMAFFTFileName();
            if (program == null) { return; }

            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder containing the sequences", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }

            string[] files = System.IO.Directory.GetFiles(folder, "*_DNA.fasta");
            if (files.Length > 0)
            { runMAFFT(program, folder, files, "DNA"); }

            files = System.IO.Directory.GetFiles(folder, "*_protein.fasta");
            if (files.Length > 0)
            { runMAFFT(program, folder, files, "PROTEIN"); }
        }

        private void runMAFFT(string program, string folder, string[] files, string sequenceType)
        {
            System.IO.StreamWriter fw = null;
            string fileName = program.Substring(0, program.LastIndexOf("\\")) + "\\cmd_MAFFT.bat";
            string rootDir = program.Substring(0, program.LastIndexOf("\\"));

            string extension = "";
            if (sequenceType == "DNA")
            { extension = getCommandExtension("MAFFTD"); }
            else
            { extension = getCommandExtension("MAFFTP"); }

            try
            {
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        if (checkFile(file) == true)
                        {
                            fw = new System.IO.StreamWriter(fileName);

                            string filelinux = file.Replace("\\", "/");

                            string answer = filelinux.Substring(0, file.Length - 6) + "_MAFFT.fasta";

                            fw.Write("@echo off \r\nsetlocal enabledelayedexpansion\r\n" +
                                "cls; 1>&2\r\nchcp 65001 1>&2\r\n\r\n" +
                                "for /f \"usebackq tokens=*\" %%i IN (`cd`) DO @set current_dir=%%i\r\n" +
                                "if /i \"%current_dir%\" == \"%systemroot%\" (\r\n" +
                                "set mafft_working_dir=\"%~dp0\"\r\n" +
                                ") else (\r\n" +
                                " set mafft_working_dir=\"%current_dir%\"\r\n" +
                                ")\r\n" +
                                "pushd \"%mafft_working_dir%\"" +
                                "echo; 1>&2\r\n" +
                                "echo Preparing environment to run MAFFT on Windows. 1>&2\r\n" +
                                "echo This may take a while, if real-time scanning by anti-virus software is on. 1>&2\r\n\r\n" +
                                "set ROOTDIR=" + rootDir + "\\\"\r\n" +
                                "set PATH=/usr/bin/:%PATH%\r\n" +
                                "set MAFFT_BINARIES=/usr/lib/mafft\r\n" +
                                "set TMPDIR=%TMP%\r\n" +
                                "set MAFFT_TMPDIR=%TMPDIR%\r\n\r\n");

                            fw.WriteLine("%ROOTDIR%\\usr\\bin\\bash\" \"/usr/bin/mafft\" " + extension + " \"" + filelinux + "\" > \"" + answer + "\"");

                            if (chkGBlocks.Checked == true && string.IsNullOrEmpty(gblocks) == false)
                            {
                                string gblocksExtension = "";
                                if (sequenceType == "DNA")
                                { gblocksExtension = getCommandExtension("GBlocksD"); }
                                else
                                { gblocksExtension = getCommandExtension("GBlocksP"); }
                                fw.WriteLine("\"" + gblocks + "\" \"" + answer.Replace("/", "\\") + "\"" + gblocksExtension);
                            }

                            fw.Close();

                            lblStatus.Text = "Status: " + answer.Substring(answer.LastIndexOf('/') + 1);
                            Application.DoEvents();
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + fileName);
                            info.UseShellExecute = false;
                            info.CreateNoWindow = false;// !chkShowCMD.Checked;

                            process.StartInfo = info;

                            process.Start();
                            process.WaitForExit();

                            if (chkKeepCommandFile.Checked == true)
                            {
                                string newBatchFileName = file + "_" + sequenceType + "_MAFFT.bat";
                                if (System.IO.File.Exists(newBatchFileName) == true)
                                { System.IO.File.Delete(newBatchFileName); }
                                try { System.IO.File.Copy(fileName, newBatchFileName); } catch { }
                            }
                        }
                    }
                }


                if (chkAggregate.Checked == true)
                {
                    lblStatus.Text = "Status: Combining alignments";
                    Application.DoEvents();
                    CombineAlignments(folder, files, "MAFFT", sequenceType, false);
                    if (chkGBlocks.Checked == true)
                    { CombineAlignments(folder, files, "MAFFT", sequenceType, true); }
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

        private string getPRANKFileName()
        {
            if (chkResetPrograms.Checked == false)
            {
                string PRANK = Properties.Settings.Default.PRANK;
                if (System.IO.File.Exists(PRANK) == true)
                { return PRANK; }

                string location = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                location = location.Substring(8);
                location = location.Replace("/", "\\");
                location = location.Substring(0, location.LastIndexOf('\\'));
                string program = location + "\\PRANK.exe";

                if (System.IO.File.Exists(program) == true)
                {
                    Properties.Settings.Default.PRANK = program;
                    Properties.Settings.Default.Save();
                    return program;
                }
            }

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the PRANK.exe executable file", "program (*.exe)|*.exe");
            if (System.IO.File.Exists(fileName) == true)
            {
                Properties.Settings.Default.PRANK = fileName;
                Properties.Settings.Default.Save();
                return fileName;
            }
            else
            {
                MessageBox.Show("The PRANK.exe executable is required for this function, see user guide for more information", "No external aligner");
                return null;
            }
        }

        private void btnPrank_Click(object sender, EventArgs e)
        {
            string program = getPRANKFileName();
            if (program == null) { return; }

            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder containing the sequences", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }

            string[] files = System.IO.Directory.GetFiles(folder, "*_DNA.fasta");
            if (files.Length > 0)
            { runPRANK(program, folder, files, "DNA"); }

            files = System.IO.Directory.GetFiles(folder, "*_protein.fasta");
            if (files.Length > 0)
            { runPRANK(program, folder, files, "PROTEIN"); }
        }

        private void runPRANK(string program, string folder, string[] files, string sequenceType)
        {
            System.IO.StreamWriter fw = null;
            string fileName = folder + "\\cmd_PRANK.bat";

            string extension = "";
            if (sequenceType == "DNA")
            { extension = getCommandExtension("PRANKD"); }
            else
            { extension = getCommandExtension("PRANKP"); }

            try
            {
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        if (checkFile(file) == true)
                        {
                            fw = new System.IO.StreamWriter(fileName);

                            string filelinux = file.Replace("\\", "/");

                            string answer = filelinux.Substring(0, file.Length - 6) + "_PRANK.fasta";
                            fw.WriteLine("\"" + program + "\" " + extension + "  -d=\"" + filelinux + "\" -o=\"" + answer + "\"");

                            if (chkGBlocks.Checked == true && string.IsNullOrEmpty(gblocks) == false)
                            {
                                string gblocksExtension = "";
                                if (sequenceType == "DNA")
                                { gblocksExtension = getCommandExtension("GBlocksD"); }
                                else
                                { gblocksExtension = getCommandExtension("GBlocksP"); }
                                fw.WriteLine("\"" + gblocks + "\" \"" + answer.Replace("/", "\\") + ".best.fas\"" + gblocksExtension);
                            }

                            fw.Close();

                            lblStatus.Text = "Status: " + answer.Substring(answer.LastIndexOf('/') + 1);
                            Application.DoEvents();
                            System.Diagnostics.Process process = new System.Diagnostics.Process();
                            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + fileName);
                            info.UseShellExecute = false;
                            info.CreateNoWindow = !chkShowCMD.Checked;

                            process.StartInfo = info;

                            process.Start();
                            process.WaitForExit();

                            if (chkKeepCommandFile.Checked == true)
                            {
                                string newBatchFileName = file + "_" + sequenceType + "_PRANK.bat";
                                if (System.IO.File.Exists(newBatchFileName) == true)
                                { System.IO.File.Delete(newBatchFileName); }
                                try { System.IO.File.Copy(fileName, newBatchFileName); } catch { }
                            }
                        }
                    }
                }

                if (chkAggregate.Checked == true)
                {
                    lblStatus.Text = "Status: Combining alignments";
                    Application.DoEvents();
                    CombineAlignments(folder, files, "PRANK", sequenceType, false);
                    if (chkGBlocks.Checked == true)
                    { CombineAlignments(folder, files, "PRANK", sequenceType, true); }
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
                Properties.Settings.Default.ClustalW = fileName;
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

            string extension = "";
            if (sequenceType == "DNA")
            { extension = getCommandExtension("ClustalWD"); }
            else
            { extension = getCommandExtension("ClustalWP"); }

            try
            {
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        if (checkFile(file) == true)
                        {
                            fw = new System.IO.StreamWriter(fileName);
                            string answer = file.Substring(0, file.Length - 6) + "_ClustalW.fasta";
                            fw.WriteLine("\"" + program + "\" -INFILE=\"" + file + "\" " + extension + " -OUTFILE=\"" + answer + "\"");

                            if (chkGBlocks.Checked == true && string.IsNullOrEmpty(gblocks) == false)
                            {
                                string gblocksExtension = "";
                                if (sequenceType == "DNA")
                                { gblocksExtension = getCommandExtension("GBlocksD"); }
                                else
                                { gblocksExtension = getCommandExtension("GBlocksP"); }
                                fw.WriteLine("\"" + gblocks + "\" \"" + answer + "\"" + gblocksExtension);
                            }

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

                            if (chkKeepCommandFile.Checked == true)
                            {
                                string newBatchFileName = file + "_" + sequenceType + "_ClustalW.bat";
                                if (System.IO.File.Exists(newBatchFileName) == true)
                                { System.IO.File.Delete(newBatchFileName); }
                                try { System.IO.File.Copy(fileName, newBatchFileName); } catch { }
                            }
                        }
                    }
                }


                if (chkAggregate.Checked == true)
                {
                    lblStatus.Text = "Status: Combining alignments";
                    Application.DoEvents();
                    CombineAlignments(folder, files, "clustalw", sequenceType, false);
                    if (chkGBlocks.Checked == true) 
                    { CombineAlignments(folder, files, "clustalw", sequenceType, true); }
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
            if (System.IO.File.Exists(fileName) == true)
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
            { runMuscle(program, folder, files, "DNA"); }

            files = System.IO.Directory.GetFiles(folder, "*_protein.fasta");
            if (files.Length > 0)
            { runMuscle(program, folder, files, "Protein"); }
        }

        private void runMuscle(string program, string folder, string[] files, string sequenceType)
        {
            System.IO.StreamWriter fw = null;
            string fileName = folder + "\\cmd_Muscle.bat";

            string extension = "";
            if (sequenceType == "DNA")
            { extension = getCommandExtension("MuscleD"); }
            else
            { extension = getCommandExtension("MuscleP"); }

            try
            {
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        if (checkFile(file) == true)
                        {
                            fw = new System.IO.StreamWriter(fileName);
                            string answer = file.Substring(0, file.Length - 6) + "_Muscle.fasta";
                            fw.WriteLine("\"" + program + "\" " + extension + "  -align \"" + file + "\" -output \"" + answer + "\"");

                            if (chkGBlocks.Checked == true && string.IsNullOrEmpty(gblocks) == false)
                            {
                                string gblocksExtension = "";
                                if (sequenceType == "DNA")
                                { gblocksExtension = getCommandExtension("GBlocksD"); }
                                else
                                { gblocksExtension = getCommandExtension("GBlocksP"); }
                                fw.WriteLine("\"" + gblocks + "\" \"" + answer + "\"" + gblocksExtension);
                            }

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

                            if (chkKeepCommandFile.Checked == true)
                            {
                                string newBatchFileName = file + "_" + sequenceType + "_Muscle.bat";
                                if (System.IO.File.Exists(newBatchFileName) == true)
                                { System.IO.File.Delete(newBatchFileName); }
                                try { System.IO.File.Copy(fileName, newBatchFileName); } catch { }
                            }
                        }
                    }
                }

                if (chkAggregate.Checked == true)
                {
                    lblStatus.Text = "Status: Combining alignments";
                    Application.DoEvents();
                    CombineAlignments(folder, files, "muscle", sequenceType, false);
                    if (chkGBlocks.Checked == true) 
                    { CombineAlignments(folder, files, "muscle", sequenceType, true); }
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

        private void CombineAlignments(string folder, string[] files, string program, string sequenceType, bool gblocks)
        {
            System.IO.StreamReader fs = null;
            System.IO.StreamWriter fw = null;
            try
            {
                Dictionary<string, string> sequences = new Dictionary<string, string>();
                Dictionary<string, string> limits = new Dictionary<string, string>();
                
                int lastLimit = 0;

                foreach (string file in files)
                {
                    if (checkFile(file) == true)
                    {
                        string alignedFile = "";
                        if (program == "muscle")
                        { alignedFile = file.Substring(0, file.Length - 6) + "_Muscle.fasta"; }
                        else if (program == "clustalw")
                        { alignedFile = file.Substring(0, file.Length - 6) + "_ClustalW.fasta"; }
                        else if (program == "PRANK")
                        { alignedFile = file.Substring(0, file.Length - 6) + "_PRANK.fasta.best.fas"; }
                        else if (program == "MAFFT")
                        { alignedFile = file.Substring(0, file.Length - 6) + "_MAFFT.fasta"; }

                        if (gblocks==true)
                        { alignedFile += ".fa"; }

                        fs = new System.IO.StreamReader(alignedFile);
                        string line = "";

                        string accession = "";
                        while (fs.Peek() > 0)
                        {
                            line = fs.ReadLine();
                            if (line.StartsWith(">") == true)
                            {
                                accession = line.Substring(1).Trim();
                                if (sequences.ContainsKey(accession) == false)
                                { sequences.Add(accession, ""); }
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
                            { length = v.Length; }
                        }
                        
                        string LimitsKey = file.Substring(file.LastIndexOf("\\") + 1).Replace(".fasta", "");
                        string limit = LimitsKey + "\t" + (lastLimit + 1).ToString() + "\t" + length.ToString();
                        limits.Add(LimitsKey, limit);
                        lastLimit = length;

                        foreach (string key in sequences.Keys)
                        {
                            if (length < sequences[key].Length)
                            { sequences[key] += new string('-', length - sequences[key].Length); }
                        }
                    }
                }

                string exportName = folder + "\\";
                if (program == "muscle")
                { exportName += "Muscle_" + sequenceType + ".fasta"; }
                else if (program == "clustalw")
                { exportName += "ClustalW_" + sequenceType + ".fasta"; }
                else if (program == "PRANK")
                { exportName += "PRANK_" + sequenceType + ".fasta"; }
                else if (program == "MAFFT")
                { exportName += "MAFFT_" + sequenceType + ".fasta"; }

                if (gblocks == true)
                { exportName += ".fa"; }

                fw = new System.IO.StreamWriter(exportName);
                foreach (string key in sequences.Keys)
                {
                    fw.Write(">" + key + "\n" + sequences[key] + "\n");
                }
                fw.Close();


                fw = new System.IO.StreamWriter(exportName.Substring(0, exportName.Length - 6) + ".txt");
                foreach (string key in limits.Keys)
                { fw.Write(limits[key] + "\n"); }
                fw.Close();
                             
            }
            catch (Exception ex)
            { }
            finally
            {
                if (fs != null) { fs.Close(); }
                if (fw != null) { fw.Close(); }
            }
        }

        private void runGBlocks(string folder, string file, string sequenceType, string program)
        {
            System.IO.StreamWriter fw = null;
            try
            {
                if (System.IO.File.Exists(file) == true)
                {
                    string fileName = folder + "\\GBlocks.bat";
                    fw = new System.IO.StreamWriter(folder + "\\GBlocks.bat");

                    fw.Write("\n");
                    string gblocksExtension = "";
                    if (sequenceType == "DNA")
                    { gblocksExtension = getCommandExtension("GBlocksD"); }
                    else
                    { gblocksExtension = getCommandExtension("GBlocksP"); }
                    fw.Write("\"" + gblocks + "\" \"" + file + "\"" + gblocksExtension);


                    fw.Close();

                    lblStatus.Text = "Status: GBlocks";
                    Application.DoEvents();
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + fileName);
                    info.UseShellExecute = false;
                    info.CreateNoWindow = !chkShowCMD.Checked;
                    process.StartInfo = info;

                    process.Start();
                    process.WaitForExit();

                    if (chkKeepCommandFile.Checked == true)
                    {
                        string newBatchFileName = file + "_" + sequenceType + "_" + program + ".bat";
                        if (System.IO.File.Exists(newBatchFileName) == true)
                        { System.IO.File.Delete(newBatchFileName); }
                        try { System.IO.File.Copy(fileName, newBatchFileName); } catch { }
                    }
                }
            }
            catch (Exception ex) { }
            finally
            { if (fw != null) { fw.Close(); } }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {

            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select folder containing the sequences", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }

            string[] DNAFiles = System.IO.Directory.GetFiles(folder, "*_DNA.fasta");
            string[] ProteinFiles = System.IO.Directory.GetFiles(folder, "*_protein.fasta");

            string program = getClustalWFileName();
            if (program != null)
            {
                if (DNAFiles.Length > 0)
                { runClustalw(program, folder, DNAFiles, "DNA"); }

                if (ProteinFiles.Length > 0)
                { runClustalw(program, folder, ProteinFiles, "Protein"); }
            }


            program = getMuscleFileName();
            if (program != null)
            {
                if (DNAFiles.Length > 0)
                { runMuscle(program, folder, DNAFiles, "DNA"); }

                if (ProteinFiles.Length > 0)
                { runMuscle(program, folder, ProteinFiles, "Protein"); }
            }

            program = getMAFFTFileName();
            if (program != null)
            {
                if (DNAFiles.Length > 0)
                { runMAFFT(program, folder, DNAFiles, "DNA"); }

                if (ProteinFiles.Length > 0)
                { runMAFFT(program, folder, ProteinFiles, "Protein"); }
            }

            program = getPRANKFileName();
            if (program != null)
            {
                if (DNAFiles.Length > 0)
                { runPRANK(program, folder, DNAFiles, "DNA"); }

                if (ProteinFiles.Length > 0)
                { runPRANK(program, folder, ProteinFiles, "Protein"); }
            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            modifyCommand mc = new modifyCommand();
            mc.ShowDialog();
        }

        private string getCommandExtension(string task)
        {
            string answer = "";

            switch (task)
            {
                case "MuscleD":
                    answer = Properties.Settings.Default.MuscleD;
                    break;
                case "MuscleP":
                    answer = Properties.Settings.Default.MuscleP;
                    break;
                case "PRANKD":
                    answer = Properties.Settings.Default.PRANKD;
                    break;
                case "PRANKP":
                    answer = Properties.Settings.Default.PRANKP;
                    break;
                case "MAFFTD":
                    answer = Properties.Settings.Default.MAFFTD;
                    break;
                case "MAFFTP":
                    answer = Properties.Settings.Default.MAFFTP;
                    break;
                case "ClustalWD":
                    answer = Properties.Settings.Default.ClustalWD;
                    break;
                case "ClustalWP":
                    answer = Properties.Settings.Default.ClustalWP;
                    break;
                case "GBlocksD":
                    answer = Properties.Settings.Default.GBlocksD;
                    break;
                case "GBlocksP":
                    answer = Properties.Settings.Default.GBlocksP;
                    break;
            }

            return " " + answer + " ";

        }

        private void chkGBlocks_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGBlocks.Checked)
            {
                gblocks = getGBlocksFileName();
                if (gblocks == null)
                { chkGBlocks.Checked = false; }
            }
            else
            { gblocks = null; }
        }

        private void chkResetPrograms_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGBlocks.Checked)
            {
                gblocks = getGBlocksFileName();
                if (gblocks == null)
                { chkGBlocks.Checked = false; }
            }
            else
            { gblocks = null; }
        }

        private void btnSaveSteps_Click(object sender, EventArgs e)
        {
            List<string> steps = new List<string>();

            foreach (TreeNode pn in tv2.Nodes[0].Nodes)
            {
                if (pn.Nodes.Count > 0)
                {
                    foreach (TreeNode n in pn.Nodes)
                    {
                        string place = pn.Text + "\t" + n.Text + "\t\t" + (string)n.Tag;
                        steps.Add(place);
                        if (n.Nodes.Count > 0)
                        {
                            foreach (TreeNode cn in n.Nodes)
                            {
                                place = pn.Text + "\t" + n.Text + "\t" + cn.Text + "\t" + (string)cn.Tag;
                                steps.Add(place);
                            }
                        }
                    }
                }
            }

            if (steps.Count > 0)
            {
                string file = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "Select a file to save steps too", "Text file (*.txt)|*.txt");
                if (file.Equals("Cancel") == true) { return; }

                System.IO.StreamWriter sw = null;
                try 
                {
                    sw = new System.IO.StreamWriter(file);
                    foreach (string l in steps)
                    { sw.WriteLine(l); }
                }
                catch { MessageBox.Show("An error occurred saving the data to file"); }
                finally
                {
                    if (sw != null) { sw.Close(); }
                }
            }
        }

        private void btnImportSteps_Click(object sender, EventArgs e)
        {
            string file = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the file containing the amalgamations steps", "Text file (*.txt)|*.txt");
            if (System.IO.File.Exists(file)== false) { return; }

            System.IO.StreamReader fs = null;
            try
            {
                fs = new System.IO.StreamReader(file);

                string line = "";
                while(fs.Peek() > 0)
                {
                    TreeNode target = null;
                    TreeNode oldParent = null;
                    TreeNode newParent = null;


                    line = fs.ReadLine();
                    string[] items = line.Split('\t');
                    if (items.Length == 4)
                    {
                        int found = 0;
                        foreach (TreeNode pn in tv1.Nodes[0].Nodes)
                        {
                            if (pn.Text == items[3])
                            {
                                foreach (TreeNode n in pn.Nodes)
                                {
                                    if (n.Text == items[1])
                                    {
                                        target = n;
                                        oldParent = pn;
                                        found = 1;
                                        break;
                                    }
                                    else if (n.Text == items[2])
                                    {
                                        target = n;
                                        oldParent = pn; found = 1;
                                        break;
                                    }
                                }
                            }
                            if (found > 0)
                            { break; }
                        }
                        if (found == 1)
                        {
                            if (string.IsNullOrEmpty(items[2]) == true)
                            {
                                foreach (TreeNode pn in tv2.Nodes[0].Nodes)
                                {
                                    if (pn.Text == items[0])
                                    {
                                        found = 2;
                                        newParent = pn;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                foreach (TreeNode pn in tv2.Nodes[0].Nodes)
                                {
                                    if (pn.Text == items[0])
                                    {
                                        foreach (TreeNode n in pn.Nodes)
                                        {
                                            if (n.Text == items[1])
                                            {
                                                found = 2;
                                               newParent = n;
                                                break;
                                            }
                                        }
                                        if (found == 2) { break; }
                                    }
                                }
                            }
                            {
                                if (found == 2)
                                { 
                                    if (target != null && newParent !=null && oldParent != null)
                                    {
                                        oldParent.Nodes.Remove(target);
                                        Application.DoEvents();
                                        newParent.Nodes.Add(target);
                                        Application.DoEvents();
                                        btnSave.Enabled = true;
                                    }                                
                                }                                
                            }
                        }
                    }

                }              
            }
            catch { MessageBox.Show("An error occurred opening the file"); }
            finally
            {
                if (fs != null) { fs.Close(); }
            }

        }

        private void btnMakePartitionFinderFiles_Click(object sender, EventArgs e)
        {
            PartitionFinder pf = new PartitionFinder();
            pf.ShowDialog();
        }

        private void btnRunPartitionFinder_Click(object sender, EventArgs e)
        {            
            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select the folder containing the alignment and configuration files.", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }

            string options = "";

            string program = getPartitionFinder2Filename(false);
            if (program == null) { return; }

            string configFile = folder + "\\partition_finder.cfg";
            if (System.IO.File.Exists(configFile) == false)
            {
                MessageBox.Show("There is no configuration called partition_finder.cfg in the folder", "No config file");
                return;
            }

            System.IO.StreamReader sf = null;
            List<string> configLines = new List<string>();
            try 
            {
                sf = new System.IO.StreamReader(configFile);
                string configureContents = sf.ReadToEnd();
                configLines.AddRange(configureContents.Split('\n'));
                sf.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error reading the config file:" + ex.Message, "Config file error");
                return;
            }
            finally
            { if (sf != null) { sf.Close(); } }

            int sequenceType = -1;
            string phyFile = getAlignmentFile(configLines, folder);
            if (System.IO.File.Exists(phyFile) == false)
            {
                if (MessageBox.Show("There is no alignment file called " + phyFile.Substring(phyFile.LastIndexOf("\\") + 1) + " in the folder\r\nDo you want to carry on?", "No alignment file") != DialogResult.Yes);
                { return; }
            }
            //else { sequenceType = isDNA(phyFile)};

            if (UsingCluster(configLines) == true)
            { options += " --raxml"; }


            if (System.IO.Directory.Exists(folder + "\\analysis" ) == true)
            {
                if( MessageBox.Show("Do you want to overwrite previous analysis?", "Delete old analysis",MessageBoxButtons.YesNo) != DialogResult.Yes)
                { return; }
               else { options += " --force-restart"; }                
            }

            PartitionFinderCommand PFC = new PartitionFinderCommand(folder, program, options, folder);
            PFC.ShowDialog();

        }

        private int isDNA(string alignmentFile)
        {
            System.IO.StreamReader sf = null;
            List<string> alignmentLines = null;
            try
            {
                sf = new System.IO.StreamReader(alignmentFile);
                alignmentLines.AddRange(sf.ReadToEnd().Split('\n'));
                sf.Close();

                int all = 0;
                int Noacgt = 0;

                for (int index = 1; index < alignmentLines.Count; index++)
                {
                    string line = alignmentLines[index].Trim();
                    line = line.Substring(line.LastIndexOf(" ") + 1).ToLower();
                    line = line.Replace("-", "");
                    line = line.Replace("?", "");
                    all += line.Length;
                    line = line.Replace("a", "");
                    line = line.Replace("c", "");
                    line = line.Replace("g", "");
                    line = line.Replace("t", "");

                    Noacgt += line.Length;
                }

                if (Noacgt *5 > all)
                { return 1; }
                else { return 2; }
            }
            catch (Exception ex)
            {
                return 3;
            }
            finally
            { if (sf != null) { sf.Close(); } }
        }

        private bool UsingCluster(List<string> configLines)
        {
            int index = 0;
            while (index < configLines.Count)
            {
                if (configLines[index].ToLower().StartsWith("search") == true)
                {
                    if (configLines[index].ToLower().StartsWith("cluster") == true)
                    { return true; }
                    else { return false; }
                }
                else { index++; }
            }
            return false;
        }

        private string getAlignmentFile(List<string> configLines, string folder)
        {
            int index = 0;
            string fileName = "";
            while (index < configLines.Count)
            {
                if (configLines[index].ToLower().StartsWith("alignment") == true)
                {
                    fileName = configLines[index].Substring(configLines[index].LastIndexOf("=") + 1).Trim();
                    index = int.MaxValue;
                    fileName = folder + "\\" + fileName.Replace(";","");
                }
                else { index++; }
            }
            return fileName;
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

            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the PartitionFinder.py executable file", "program (*.py)|*.py");
            if (System.IO.File.Exists(fileName) == true)
            {
                Properties.Settings.Default.PartitionFinder = fileName;
                Properties.Settings.Default.Save();
                return fileName;
            }
            else
            {
                MessageBox.Show("The PartitionFinder2.exe executable is required for this function, see user guide for more information", "No external aligner");
                return null;
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "Select the name of the output file", "Tab-delimited text file (*.txt)|*.txt");
            if (fileName== "Cancel") { return; }

            List<string[]> names = new List<string[]>();

            foreach (TreeNode n in tv1.Nodes[0].Nodes)
            {
                foreach (TreeNode nN in n.Nodes)
                {
                    if (nN.ImageIndex == 1)
                    {
                        string[] value = { n.Text, nN.Text };
                        names.Add(value  ); 
                    }
                }
            }

            Dictionary<string, string> sequences = new Dictionary<string, string>();
            foreach (string accession in sequenceName)
            {
                if (data.ContainsKey(accession) == true)
                {
                    foreach (string[] value in names)
                    {
                        if (data[accession].ContainsKey(value[0]) == true)
                        { 
                            if (data[accession][value[0]].ContainsKey(value[1]) == true)
                            {
                                feature f = data[accession][value[0]][value[1]];
                                sequences.Add(f.WorkingName + ": " + f.getOrganism + ", " + accession, f.getDNASequence);
                            }
                        }
                    }
                }
            }

            comparison c = new comparison(sequences, fileName);
            Thread newthread = new Thread(new ThreadStart(c.Analysis));
            newthread.Start();
        }
    }
}
