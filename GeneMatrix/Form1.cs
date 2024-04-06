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
            data = new Dictionary<string, Dictionary<string, Dictionary<string, feature>>>();
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
                    }
                    else if (line.StartsWith("ORIGIN") == true)
                    {
                        lines.Add(line);
                        startOfSequence = lines.Count;
                    }
                    else { lines.Add(line); }
                }

                if (lines.Count > 0)
                {
                    processData(lines, startOfSequence);
                    lines = new List<string>();
                }
            
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
        }

        private string getAccession(List<string> lines)
        {
            for (int index =0; index < 6;index++)
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

        private string reverseComplement(string sequence)
        {            
            StringBuilder sb = new StringBuilder();

            for (int index = sequence.Length -1; index > -1; index--)
            {
                switch (sequence[index])
                {
                    case 'A':
                        sb.Append("T");
                        break;
                    case 'C':
                        sb.Append("G");
                        break;
                    case 'G':
                        sb.Append("C");
                        break;
                    case 'T':
                        sb.Append("A");
                        break;
                    default:
                        sb.Append("N");
                        break;
                }
            }

            return sb.ToString();

        }
    }
}
