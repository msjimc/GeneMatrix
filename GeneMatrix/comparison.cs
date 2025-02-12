using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
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
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(fileName);                

                List<string> results = new List<string>();
                string line = "";
                foreach (string key in sequences.Keys)
                { line += "\t" + key; }
                sw.Write(line + "\n");

                List<string> done = new List<string>();

                foreach (string keyFirst in sequences.Keys)
                {
                    line = keyFirst;
                    foreach (string keySecond in sequences.Keys)
                    {
                        if (done.Contains(keySecond) == true)
                        { line += "\t-"; }
                        else if (keyFirst == keySecond)
                        {
                            line += "\t" + sequences[keyFirst].Length.ToString("N0");
                            done.Add(keyFirst);
                        }
                        else
                        {
                            int score = fillMatrixNW(sequences[keyFirst], sequences[keySecond]);
                            line += "\t" + (score / 3).ToString("N0");
                        }
                    }
                    sw.Write(line + "\n");
                    sw.Flush();
                }
            }
            finally { if (sw != null) { sw.Close(); } }

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
            for (int seq1I = 1; seq1I < matrix.GetUpperBound(0); seq1I++)
            {
                for (int seq2I = 1; seq2I < matrix.GetUpperBound(1); seq2I++)
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
            return matrix[matrix.GetUpperBound(0) - 1, matrix.GetUpperBound(1) - 1];
        }



    }
}
