using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLineExperiments.Commands;
using CommandLine.Text;
using CommandLine;
using System.IO;

namespace CommandLineExperiments
{
    public class ProgramController
    {
        private Action<ShowFormLocalCommand> showFormLocal;
        private Action<ShowFormRemoteCommand> showFormRemote;
        private Action<ShowHelpCommand> showHelp;

        public ProgramController(Action<ShowFormRemoteCommand> showFormRemote, Action<ShowFormLocalCommand> showFormLocal, Action<ShowHelpCommand> showHelp)
        {
            this.showFormRemote = showFormRemote;
            this.showFormLocal = showFormLocal;
            this.showHelp = showHelp;
        }

        public void Execute(string[] args)
        {
            // The previous version of the software did not use any verbs.
            // To mantain compatibility if no verb is passed assume that it is a remote call
            var compatibilityModeFailed = false;
            new Parser(conf =>
            {
                conf.CaseSensitive = false;
                conf.HelpWriter = null;
            })
            .ParseArguments<OptionsCompability>(args)
            .WithParsed<OptionsCompability>(options =>
            {
                showFormRemote(new ShowFormRemoteCommand(options.JobToken, options.SigningWebApiUri));
            })
            .WithNotParsed(_ => compatibilityModeFailed = true);

            // Otherwise use the standard parameters
            if (compatibilityModeFailed)
            {
                using (StringWriter helpWriter = new StringWriter())
                {
                    // Change the language used to build the help with a local class
                    SentenceBuilder.Factory = () => new ItalianSentenceBuilder();

                    new Parser(with =>
                    {
                        with.CaseSensitive = false;
                        with.HelpWriter = helpWriter;
                        with.MaximumDisplayWidth = 240;
                    })
                    .ParseArguments<OptionsRemote, OptionsLocal>(args)
                    .WithParsed<OptionsRemote>(options =>
                    {
                        showFormRemote(new ShowFormRemoteCommand(options.JobToken, options.SigningWebApiUri));
                    })
                    .WithParsed<OptionsLocal>(options =>
                    {
                        showFormLocal(new ShowFormLocalCommand(options.PdfPath));
                    })
                    .WithNotParsed(_ =>
                    {
                        showHelp(new ShowHelpCommand(helpWriter.ToString()));
                    });
                }
            }
        }
    }
}
