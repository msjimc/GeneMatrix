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
    public partial class DataTextView : Form
    {
        string basicData = "";
        public DataTextView(string data)
        {
            InitializeComponent();

            txtData.Text = data;
            basicData = data;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "Select the name of the output file", "Text file (*.txt)|*.txt");
            if (fileName == "Cancel") { return; }
            System.IO.StreamWriter sw = null;

            try
            {
                sw = new System.IO.StreamWriter(fileName,false);
                sw.Write(basicData);           
            }
            catch (Exception ex) { MessageBox.Show("An error occurred creating the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally {if (sw!= null) { sw.Close(); } }   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
