using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandLineExperiments;
using CommandLineExperiments.Commands;

namespace Test
{
    [TestClass]
    public class ProgramControllerTest
    {
        [TestMethod]
        public void When_no_arguments_should_launch_help()
        {
            var args = new string[0];
            bool actionCalled = false;
            Action<ShowHelpCommand> showHelp = _ => actionCalled = true;
            Action<ShowFormLocalCommand> showFormLocal = null;
            Action<ShowFormRemoteCommand> showFormRemote = null;

            var controller = new ProgramController(showFormRemote, showFormLocal, showHelp);

            controller.Execute(args);

            Assert.IsTrue(actionCalled);
        }

        [TestMethod]
        public void When_no_verb_Should_use_compatibility_and_launch_remote()
        {
            Guid jobToken = Guid.NewGuid();
            var url = "http://localhost:25446";
            var args = $"--jobToken {jobToken} --url {url}".Split(' ');

            bool actionCalled = false;
            Action<ShowFormRemoteCommand> showFormRemote = cmd => {
                actionCalled = true;
                Assert.AreEqual(jobToken, cmd.JobToken);
                Assert.AreEqual(url, cmd.SigningWebApiUri);
            };
            Action<ShowFormLocalCommand> showFormLocal = null;
            Action<ShowHelpCommand> showHelp = null;

            var controller = new ProgramController(showFormRemote, showFormLocal, showHelp);

            controller.Execute(args);

            Assert.IsTrue(actionCalled);
        }

        [TestMethod]
        public void When_verb_remote_Should_launch_remote()
        {
            Guid jobToken = Guid.NewGuid();
            var url = "http://localhost:25446";
            var args = $"remote --jobToken {jobToken} --url {url}".Split(' ');

            bool actionCalled = false;
            Action<ShowFormRemoteCommand> showFormRemote = cmd => {
                actionCalled = true;
                Assert.AreEqual(jobToken, cmd.JobToken);
                Assert.AreEqual(url, cmd.SigningWebApiUri);
            };
            Action<ShowFormLocalCommand> showFormLocal = null;
            Action<ShowHelpCommand> showHelp = null;

            var controller = new ProgramController(showFormRemote, showFormLocal, showHelp);

            controller.Execute(args);

            Assert.IsTrue(actionCalled);
        }

        [TestMethod]
        public void When_verb_local_Should_launch_local()
        {
            var pdf = "c:\temp\file.pdf";
            var args = $"local --pdf-path {pdf}".Split(' ');

            bool actionCalled = false;
            Action<ShowFormRemoteCommand> showFormRemote = null;
            Action<ShowFormLocalCommand> showFormLocal = cmd => {
                actionCalled = true;
                Assert.AreEqual(pdf, cmd.PdfPath);
            };
            Action<ShowHelpCommand> showHelp = null;

            var controller = new ProgramController(showFormRemote, showFormLocal, showHelp);

            controller.Execute(args);

            Assert.IsTrue(actionCalled);
        }
    }
}
