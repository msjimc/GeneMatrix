using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public feature(List<string> lines, int index, int endIndex, string FeatureType, string Organism, string sequence, int count, bool extend)
        {
            organism = Organism;
            featureType = FeatureType;                               

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

            setCoordinates(lines, index, sequence, extend);
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

        private void setCoordinates(List<string> lines, int startIndex, string sequence, bool extend)
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
                int startPoint = 0;
                int endPoint = 0;
                foreach (string item in items)
                {
                    string[] bite = item.Split('.');
                    int from = Convert.ToInt32(bite[0]) - 1;
                    int too = Convert.ToInt32(bite[2]);
                    endPoint = too;
                    if (startPoint == 0) { startPoint = from; }
                    string bitOfOrf = sequence.Substring(from, too - from);
                    DNA += bitOfOrf.ToLower();
                }
                string five = "  ";
                try
                {
                    if (startPoint - 2 > 0)
                    { five = sequence.Substring(startPoint - 2, 2); }
                }
                catch { }
                string three = "  ";
                try 
                { 
                if (endPoint + 3 < sequence.Length)
                { three = sequence.Substring(endPoint, 2); }
                }
                catch { }

                if (lines[startIndex].ToLower().Contains("complement") == true)
                { 
                    DNA = reverseComplement(DNA);
                    if (featureType == "CDS")
                    {
                        string t = reverseComplement(five);
                        five = reverseComplement(three);
                        three = t;
                    }
                }

                if (featureType == "CDS" && extend == true)
                { extended(five, three); }               
               
            }
            catch { throw new Exception("Coordinate error for " + name + " feature"); }
        }

        private void extended(string five, string three)
        {
            
            five.PadLeft(2, ' ');
            if (DNA.StartsWith("atg") == false && DNA.StartsWith("gtg") == false && DNA.StartsWith("ttg") == false)
            {
                string test = five[1] + DNA;
                if (test.StartsWith("atg") == true || test.StartsWith("gtg") == true || test.StartsWith("ttg") == true)
                { DNA = test; }
                else
                {
                    test = five[0] + test;
                    if (test.StartsWith("atg") == true || test.StartsWith("gtg") == true || test.StartsWith("ttg") == true)
                    { DNA = test;  }
                }
            }
            
            three = three.PadRight(2, ' ');
            string end = DNA.Substring(DNA.Length - 3, 3);
            if (end.StartsWith("tag") == false && end.StartsWith("taa") == false && end.StartsWith("tga") == false && end.StartsWith("aga") == false && end.StartsWith("agg") == false)
            {
                if (three == "tag" || three == "taa" || three == "tga" || three == "aga" || three == "agg")
                { DNA += three;  }
                else
                {
                    end = end.Substring(1, 2) + three[0];
                    if (end.StartsWith("tag") == true || end.StartsWith("taa") == true || end.StartsWith("tga") == true || end.StartsWith("aga") == true || end.StartsWith("agg") == true)
                    { DNA += three[0]; }
                    else
                    {
                        end = end.Substring(1, 2) + three[1];
                        if (end.StartsWith("tag") == true || end.StartsWith("taa") == true || end.StartsWith("tga") == true || end.StartsWith("aga") == true || end.StartsWith("agg") == true)
                        { DNA += three; }
                    }
                }
            }
          
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
