using CommandLine;
using CommandLine.Text;
using CommandLineExperiments.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandLineExperiments
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ProgramController(ShowFormRemote, ShowFormLocal, ShowHelp);
            controller.Execute(args);
        }

        private static void ShowHelp(ShowHelpCommand helpCommand)
        {
            MessageBox.Show(helpCommand.HelpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
            Environment.ExitCode = (int)ExitCode.UsageError;
        }

        private static void ShowFormLocal(ShowFormLocalCommand command)
        {
            try
            {
                Application.Run(new FormSignerLocal(command.PdfPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Esecuzione applicazione interrotta.\n" + ex, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.ExitCode = (int)ExitCode.UnexpectedException;
            }
        }

        private static void ShowFormRemote(ShowFormRemoteCommand command)
        {
            try
            {
                Application.Run(new FormSignerRemote(command.JobToken, command.SigningWebApiUri));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Esecuzione applicazione interrotta.\n" + ex, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.ExitCode = (int)ExitCode.UnexpectedException;
            }
        }
    }
}
