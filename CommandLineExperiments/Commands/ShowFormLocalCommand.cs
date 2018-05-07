using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineExperiments.Commands
{
    public class ShowFormLocalCommand
    {
        public string PdfPath { get; }

        public ShowFormLocalCommand(string pdfPath)
        {
            PdfPath = pdfPath;
        }
    }
}
