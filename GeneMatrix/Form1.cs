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
        private  Dictionary<string, Dictionary<string, Dictionary<string, feature>>> data = new Dictionary<string, Dictionary<string, Dictionary<string, feature>>>();
        private List<string> sequenceName = null;
        private List<string> CDS = null;
        private List<string> tRNA = null;
        private List<string> rRNA = null;

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

            while (index < startOfSequence && index < lines.Count)
            {
                if (lines[index].StartsWith("     ") == true && lines[index][6] != ' ')
                {
                    if (featureStart > -1 && (featureType == "CDS" || featureType == "tRNA" || featureType == "rRNA"))
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
                }
            }
            tv2.SelectedNode = tv2.Nodes[0];
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
        }

        private int rightButton = 1;
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
    }
}
