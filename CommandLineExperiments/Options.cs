using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineExperiments
{
    public class OptionsCompability
    {
        [Option("jobToken", Required = true)]
        public Guid JobToken { get; set; }

        [Option("url", Required = true)]
        public string SigningWebApiUri { get; set; }
    }

    [Verb("remote", HelpText = "Firma un documento caricato dal server.")]
    public class OptionsRemote
    {
        [Option("jobToken", Required = true, HelpText = "L'id del job da caricare dal server. Deve essere un Guid.")]
        public Guid JobToken { get; set; }

        [Option("url", Required = true, HelpText = "L'url per le chiamate REST al server.")]
        public string SigningWebApiUri { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Esempio di caricamento dal server", new OptionsRemote { JobToken = Guid.NewGuid(), SigningWebApiUri = "http://server.net/service" });
            }
        }
    }

    [Verb("local", HelpText = "Firma un file in locale.")]
    public class OptionsLocal
    {
        [Option("pdf-path", Required = true, HelpText ="Il percorso di un file pdf da firmare.")]
        public string PdfPath { get; set; }
        [Usage]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Esempio di firma di un pdf", new OptionsLocal{ PdfPath = @"c:\path\to\file.pdf" });
            }
        }
    }
}
