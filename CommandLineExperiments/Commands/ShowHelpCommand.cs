using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineExperiments.Commands
{
    public class ShowHelpCommand
    {
        public string HelpText {get;}

        public ShowHelpCommand(string helpText)
        {
            HelpText = helpText;
        }
    }
}
