using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneMatrix
{
    internal class feature
    {
        private string name = "";
        private string featureType = "";
        private string DNA = "";
        private string protien = "";
        public feature(List<string> lines, int index, int endIndex, string FeatureType, string sequence)
        {
            featureType = FeatureType;
            for (int lineIndex = index + 1; lineIndex < endIndex; lineIndex++)
            {
                if (lines[lineIndex].ToLower().Contains("/gene=") == true)
                { setName(lines[lineIndex]); }
                else if (lines[lineIndex].ToLower().Contains("/translation=") == true)
                {

                }
            }
        }

        private void setName(string line)
        {
            string[] items = line.Split('"');
            if (items.Length > 0)
            {
                if (items[0].ToLower().Contains("/gene=") == true)               
                {
                    if (items[1].Contains('_') == true)
                    { name = items[1].Split('_')[1]; }
                    else
                    { name = items[1]; }
                }                
            }
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

    }
}
