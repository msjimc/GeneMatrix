using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneMatrix
{
    internal class feature
    {
        private string workingName = "";
        private string name = "";
        private string product = "";
        private string protein_id = "";
        private string locus_tag = "";
        private string organism = "";
        private string featureType = "";
        private string DNA = "";
        private string protein = "";

        public feature(string Name, string Sequence, string Organism)
        {
            
            featureType = "Unknown";
            

            string[] data = Name.Split(';');
            if (data.Length == 4)
            {
                organism = data[0].Substring(1);
                name = data[3];                
                workingName = data[3];
                if (data[2] == "-")
                { DNA = reverseComplement(Sequence); }
                else { DNA = Sequence; }
            }
            else
            { 
                organism = Organism;
                name = Name.Substring(1);
                workingName = name;                
                DNA = Sequence;
            }
        }

        public feature(List<string> lines, int index, int endIndex, string FeatureType, string Organism, string sequence, int count)
        {
            organism = Organism;
            featureType = FeatureType;
           
            
            setcoordinates(lines, index, sequence);

            for (int lineIndex = index + 1; lineIndex < endIndex; lineIndex++)
            {
                if (lines[lineIndex].ToLower().Contains("/gene=") == true)
                { name = getName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/product=") == true)
                { product = getName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/protein_id=") == true)
                { protein_id = getName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/locus_tag=") == true)
                { locus_tag = getName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/translation=") == true)
                {  getProtein(lines, lineIndex, endIndex); }
            }

            if (string.IsNullOrEmpty(name) == false)
            { workingName = name; }
            else if (string.IsNullOrEmpty(product) == false)
            { workingName = product; }
            else if (string.IsNullOrEmpty(protein_id) == false)
            { workingName = protein_id; }
            else if(string.IsNullOrEmpty(locus_tag) == false)
            { workingName = protein_id; }
            else { workingName = count.ToString(); }

        }

        private string getName(string line)
        {
            string answer = "";
            string[] items = line.Split('"');
            if (items.Length > 0)
            {
                if (items[1].Contains('_') == true)
                { answer = items[1].Split('_')[1]; }
                else
                { answer = items[1]; }
            }
            if (answer.Contains("/") == true)
            { answer = answer.Substring(0, answer.IndexOf("/")).Trim(); }
            return answer.Trim();
        }

        private void getProtein(List<string> lines, int startIndex, int endIndex)
        {
            StringBuilder sb = new StringBuilder(lines[startIndex].Substring(lines[startIndex].IndexOf("\"")+1).Trim());

            for (int index = startIndex + 1; index <= endIndex;index++)
            {
                if (lines[index].Contains("\"") == false)
                { sb.Append(lines[index].Trim()); }
                else
                { 
                    sb.Append(lines[index].Trim().Replace("\"", ""));
                    break;
                }
            }

            protein = sb.ToString();

        }

        private void setcoordinates(List<string> lines, int startIndex, string sequence)
        {
            string line = lines[startIndex];
            int index = startIndex;
            while (index < lines.Count)
            {
                if (line.TrimEnd().EndsWith(",") == true)
                {
                    index++;
                    line += lines[index].Replace(" ", "");
                }
                else { break; }
            }


            int bracket = line.LastIndexOf("(");
            string data = "";
            if (bracket == -1)
            { data = line.Substring(21).Trim(); }
            else
            {
                data = line.Substring(line.LastIndexOf("(") + 1).Trim();
                data = data.Substring(0, data.IndexOf(")"));
            }

            data = data.Replace(">", "").Replace("<", "");

            try
            {
                string[] items = data.Split(',');

                foreach (string item in items) 
                {
                    string[] bite = item.Split('.');
                    int from = Convert.ToInt32(bite[0]) -1;
                    int too = Convert.ToInt32(bite[2]);
                    string bitOfOrf = sequence.Substring(from, too - from);
                    DNA += bitOfOrf;
                }

                if (lines[startIndex].ToLower().Contains("complement") == true)
                { DNA = reverseComplement(DNA); }
               
            }
            catch { throw new Exception("Coordinate error for " + name + " feature"); }
        }

        private string reverseComplement(string sequence)
        {
            StringBuilder sb = new StringBuilder();

            for (int index = sequence.Length - 1; index > -1; index--)
            {
                switch (sequence[index])
                {
                    case 'A':
                    case 'a':
                        sb.Append("t");
                        break;
                    case 'C':
                    case 'c':
                        sb.Append("g");
                        break;
                    case 'G':
                    case 'g':
                        sb.Append("c");
                        break;
                    case 'T':
                    case 't':
                        sb.Append("a");
                        break;
                    case 'R':
                    case 'r':
                        sb.Append("y");
                        break;
                    case 'Y':
                    case 'y':
                        sb.Append("r");
                        break;
                    case 'K':
                    case 'k':
                        sb.Append("m");
                        break;
                    case 'M':
                    case 'm':
                        sb.Append("k");
                        break;
                    case 'W':
                    case 'w':
                        sb.Append("w");
                        break;
                    case 'S':
                    case 's':
                        sb.Append("s");
                        break;
                    case 'B':
                    case 'b':
                        sb.Append("v");
                        break;
                    case 'D':
                    case 'd':
                        sb.Append("h");
                        break;
                    case 'H':
                    case 'h':
                        sb.Append("d");
                        break;
                    case 'V':
                    case 'v':
                        sb.Append("b");
                        break;
                    default:
                        sb.Append("n");
                        break;
                }
            }

            return sb.ToString();
        }

        public string WorkingName
        { get { return workingName; } }

        public string getDNASequence
        { get { return DNA; } }

        public string getProteinSequence
        { get { return protein; } }

        public string getOrganism
        { get { return organism;  } }

    }
}
