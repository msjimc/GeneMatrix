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
        private string featureType = "";
        private string DNA = "";
        private string protien = "";
        public feature(List<string> lines, int index, int endIndex, string FeatureType, string sequence, int count)
        {
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

            protien = sb.ToString();

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

        public string WorkingName
        { get { return workingName; } }

    }
}
