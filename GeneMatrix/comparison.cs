using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeneMatrix
{
    internal class comparison
    {
        private int MatchNW = 3;
        private int GapNW = -2;
        private int MismatchNW = -3;

        private Dictionary<string, string> sequences = null;
        private string fileName;

        public comparison(Dictionary<string, string> Sequences, string FileName)
        {
            fileName = FileName;
            sequences = Sequences;
        }

        public void Analysis()
        {
            try { DoAnalysis(); }
            catch { }
        }

        private void DoAnalysis()
        {
            List<string> results = new List<string>();
            int[,] scores = setScoreArray(sequences.Count);
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(fileName);                

               
                string line = "";
                foreach (string key in sequences.Keys)
                { line += "\t" + key; }
                sw.Write(line + "\n");

                int one = 0;
                int two = 0;


                foreach (string keyFirst in sequences.Keys)
                {
                    int maximum = sequences[keyFirst].Length;
                    line = keyFirst + " (" + maximum.ToString("N0") + "bp)";

                    foreach (string keySecond in sequences.Keys)
                    {
                        //if (done.Contains(keySecond) == true)
                        //{ line += "\t-"; }
                        //else 
                        if (scores[two, one] != int.MinValue)
                        { line += "\t" + scores[two, one].ToString("N0"); }
                        else if (keyFirst == keySecond)
                        {
                            line += "\t" + maximum.ToString("N0") + "*";
                            //done.Add(keyFirst);
                            scores[one, two] = maximum;
                        }
                        else
                        {
                            int score = fillMatrixNW(sequences[keyFirst], sequences[keySecond]);
                            scores[two, one] = score / 3;
                            line += "\t" + scores[two, one].ToString("N0");
                            scores[one, two] = scores[two, one];
                        }
                        two++;
                    }
                    results.Add(line);
                    sw.Write(line + "\n");
                    sw.Flush();
                    one++;
                    two = 0;
                }                
            }
            finally { if (sw != null) { sw.Close(); } }
            Dictionary<string, List<string>> duplicates =new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> minimumSetDuplicates = compareResults(results, ref duplicates);
            makeMinimumComparisonSet(minimumSetDuplicates, scores, fileName, duplicates);
        }

        private void makeMinimumComparisonSet(Dictionary<string, List<string>> minimumSetDuplicates, int[,] scores, string fileName, Dictionary<string, List<string>> duplicates)
        {
            Dictionary<string,int> nameIindex = new Dictionary<string,int>();
            int index = 0;
            foreach (string key in sequences.Keys)
            {
                nameIindex.Add(key, index);
                index++;
            }          


            foreach (List<string> name in minimumSetDuplicates.Values)
            {
                foreach(string key in name)
                {
                    int bracket = key.IndexOf("(");
                    string thiskey = key.Substring(0, bracket - 1);
                    if (nameIindex.ContainsKey(thiskey)==true)
                    { nameIindex.Remove(thiskey); }
                }
            }           

            System.IO.StreamWriter sw = null;

            try
            {
                sw = new System.IO.StreamWriter(fileName, true);
                sw.Write("\n\nMinimum sequence set\n");

                foreach (string key in nameIindex.Keys)
                { sw.Write("\t" + key); }
                sw.Write("\n");

                Dictionary<string, List<string>> duplicateCleanKeys = new Dictionary<string, List<string>>();
                foreach (string key in duplicates.Keys)
                {
                    int bracket = key.IndexOf("(");
                    string thiskey = key.Substring(0, bracket - 1);
                    duplicateCleanKeys.Add(thiskey, duplicates[key]);
                }

                foreach (string outerKey in nameIindex.Keys)
                {
                    sw.Write(outerKey);
                    foreach (string innerkey in nameIindex.Keys)
                    {
                        sw.Write("\t" + scores[nameIindex[outerKey], nameIindex[innerkey]].ToString("N0"));
                        if (outerKey == innerkey)
                        { sw.Write("*"); }
                    }
                    if (duplicateCleanKeys.ContainsKey(outerKey) == true)
                    {
                        if (duplicateCleanKeys[outerKey].Count > 1)
                        {
                            sw.Write("\t");
                            for (int place = 1; place < duplicateCleanKeys[outerKey].Count; place++)
                            { sw.Write(duplicateCleanKeys[outerKey][place] + " "); }
                            sw.Write("\n");
                        }
                        else
                        { sw.Write("\tUnique\n"); }
                    }
                    else
                    { sw.Write("\tUnique\n"); }
                }

                sw.Write("\n\nDuplicated sequence sets\n");
                string lists = "";
                foreach (string key in duplicateCleanKeys.Keys)
                {
                    if (duplicateCleanKeys[key].Count > 1)
                    {
                        if (lists.Contains(key) == false)
                        {
                            foreach (string value in duplicateCleanKeys[key])
                            {
                                int bracket = value.IndexOf("(");
                                string thisKey = value.Substring(0, bracket - 1);
                                lists += thisKey + "\t";
                            }
                            lists += "\n";
                        }
                    }
                }
                sw.Write(lists);


                int[] sizes = new int[sequences.Count];
                int counter = 0;
                foreach (string sequence in sequences.Values)
                {
                    sizes[counter] = (int)sequence.Length;
                    counter++;
                }
                Array.Sort(sizes);
                int median = GetMedian(sizes);            
                

                sw.Write("\n\nSize range\nMedian length\t" + median.ToString("N1") +
                   "Size range\t" + sizes[0].ToString() + "\t" + sizes[sizes.GetUpperBound(0)] + "\n");

                sw.Write("Sequence\tLength\tDifference from median length\tPercent of median length\n");
                foreach(string key in sequences.Keys)
                {                   
                    sw.Write(key +"\t" + sequences[key].Length.ToString() +
                        "\t" + (sequences[key].Length - median).ToString("N0") +
                        "\t" + ((double)(sequences[key].Length * 100) / median).ToString("N2") + "\n");
                }
                sw.Flush();
            }
            finally
            { if (sw != null) { sw.Close(); } }

        }

        private int GetMedian(int[] sizes)
        {
            Array.Sort(sizes);
            int count = sizes.Length;
            if (count % 2 == 0)
            {
                // Even number of elements
                return (int)((sizes[count / 2 - 1] + sizes[count / 2]) / 2.0);
            }
            else
            {
                // Odd number of elements
                return sizes[count / 2];
            }
        }

        private double GetMedian(double[] sizes)
        {
            Array.Sort(sizes);
            int count = sizes.Length;
            if (count % 2 == 0)
            {
                // Even number of elements
                return (int)((sizes[count / 2 - 1] + sizes[count / 2]) / 2.0);
            }
            else
            {
                // Odd number of elements
                return sizes[count / 2];
            }
        }

        private double getMAD(int[] sizes, int median)
        {
            double[] dSizes = new double[sizes.Length];
            for (int i = 0; i < sizes.Length;i++)
            {
                dSizes[i] = (double)sizes[i];
            }

            double[] absoluteDeviations = dSizes.Select(x => Math.Abs(x - median)).ToArray();

            return GetMedian(absoluteDeviations);
        }

        private Dictionary<string, List<string>> compareResults(List<string> results, ref Dictionary<string, List<string>> duplicates)
        {
            //Dictionary<string, List<string>> duplicates = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> minimumSetDuplicates = new Dictionary<string, List<string>>();

            for (int index = 0; index < results.Count; index++)
            {
                string line = results[index];
                int firstTab = line.IndexOf('\t');
                if (firstTab != -1)
                {
                    string name = line.Substring(0, firstTab);
                    string data = line.Substring(firstTab + 1).Replace("*", "");
                    for (int inner = 0; inner < results.Count; inner++)
                    {
                        int innerFirstTab = results[inner].IndexOf("\t");
                        if (innerFirstTab != -1)
                        {
                            string innerName = results[inner].Substring(0, firstTab);
                            string innerData = results[inner].Substring(firstTab + 1).Replace("*", "");
                            if (string.Compare(data, innerData) == 0)
                            {
                                if (duplicates.ContainsKey(name) == true)
                                { duplicates[name].Add(innerName); }
                                else
                                { duplicates.Add(name, new List<string> { innerName }); }
                                if (inner > index)
                                {
                                    if (minimumSetDuplicates.ContainsKey(name) == true)
                                    { minimumSetDuplicates[name].Add(innerName); }
                                    else
                                    { minimumSetDuplicates.Add(name, new List<string> { innerName }); }
                                }
                            }
                        }
                    }
                }
            }

            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(fileName);
                string line = "";
                foreach (string key in sequences.Keys)
                { line += "\t" + key; }
                sw.Write(line + "\n");


                for (int index = 0; index < results.Count; index++)
                {
                    line = results[index];
                    int firstTab = line.IndexOf('\t');
                    if (firstTab != -1)
                    {
                        string name = line.Substring(0, firstTab);
                        sw.Write(line + "\t");
                        if (duplicates.ContainsKey(name) == true && duplicates[name].Count >1)
                        { sw.Write(string.Join(", ",duplicates[name]) + "\n"); }
                        else { sw.Write("Unique\n"); }
                    }
                }
            }
            finally { if (sw != null) { sw.Close(); } }

            return minimumSetDuplicates;
        }
               
        private int[,] setScoreArray(int dimension)
        {
            int[,] scores = new int[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    scores[i, j] = int.MinValue;
                }
            }

            return scores;
        }

        private int[,] makeMatrixNW(string seq1, string seq2)
        {
            int[,] matrix = new int[seq1.Length + 1, seq2.Length + 1];
            for (int index1 = 0; index1 <= matrix.GetUpperBound(0); index1++)
            {
                for (int index2 = 0; index2 <= matrix.GetUpperBound(1); index2++)
                {
                    matrix[index1, index2] = 0;
                }
            }

            for (int index1 = 0; index1 <= matrix.GetUpperBound(0); index1++)
            { matrix[index1, 0] = -index1; }

            for (int index2 = 0; index2 <= matrix.GetUpperBound(1); index2++)
            { matrix[0, index2] = -index2; }

            return matrix;
        }

        private int fillMatrixNW(string seq1, string seq2)
        {
            int[,] matrix = makeMatrixNW(seq2,seq1);
            
            int thisScore = 0;
            for (int seq1I = 1; seq1I < matrix.GetUpperBound(0) + 1; seq1I++)
            {
                for (int seq2I = 1; seq2I < matrix.GetUpperBound(1) + 1; seq2I++)
                {
                    if (seq2[seq1I - 1] == seq1[seq2I - 1])
                    {
                        matrix[seq1I, seq2I] = matrix[seq1I - 1, seq2I - 1] + MatchNW;
                        thisScore = matrix[seq1I, seq2I];
                    }
                    else
                    {
                        thisScore = matrix[seq1I - 1, seq2I - 1] + MismatchNW;

                        if (matrix[seq1I, seq2I - 1] + GapNW > thisScore)
                        {
                            thisScore = matrix[seq1I, seq2I - 1] + GapNW;
                        }

                        if (matrix[seq1I - 1, seq2I] + GapNW > thisScore)
                        {
                            thisScore = matrix[seq1I - 1, seq2I] + GapNW;
                        }
                    }

                    matrix[seq1I, seq2I] = thisScore;
                }
            }
           
            return matrix[matrix.GetUpperBound(0), matrix.GetUpperBound(1)];
        }



    }
}
