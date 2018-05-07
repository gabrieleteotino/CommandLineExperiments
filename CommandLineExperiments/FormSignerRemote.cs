using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommandLineExperiments
{
    public partial class FormSignerRemote : CommandLineExperiments.FormSignerMaster
    {
        private Guid jobToken;
        private readonly string signingWebApiUri;

        public FormSignerRemote(Guid jobToken, string signingWebApiUri)
        {
            InitializeComponent();

            this.jobToken = jobToken;
            this.signingWebApiUri = signingWebApiUri;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Firma remota");
        }
    }
}
