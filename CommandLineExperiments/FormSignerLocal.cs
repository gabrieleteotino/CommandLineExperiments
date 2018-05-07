using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommandLineExperiments
{
    public partial class FormSignerLocal : CommandLineExperiments.FormSignerMaster
    {
        private readonly string pdfPath;

        public FormSignerLocal(string pdfPath)
        {
            InitializeComponent();
            this.pdfPath = pdfPath;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Firma locale");
        }
    }
}
