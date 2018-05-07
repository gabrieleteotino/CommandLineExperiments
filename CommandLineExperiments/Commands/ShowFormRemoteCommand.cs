using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineExperiments.Commands
{
    public class ShowFormRemoteCommand
    {
        public Guid JobToken { get; }

        public string SigningWebApiUri { get; }

        public ShowFormRemoteCommand(Guid jobToken, string signingWebApiUri)
        {
            JobToken = jobToken;
            SigningWebApiUri = signingWebApiUri;
        }
    }
}
