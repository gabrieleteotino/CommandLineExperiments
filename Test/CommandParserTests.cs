using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommandLine;
using System.IO;
using CommandLineExperiments;

namespace Test
{
    [TestClass]
    public class CommandParserTests
    {
        private Parser parser;
        private TextWriter help;

        [TestInitialize]
        public void Init()
        {
            help = new StringWriter();

            parser = new Parser(with =>
            {
                with.CaseSensitive = false;
                with.HelpWriter = help;
                with.EnableDashDash = true;
            });
        }

        [TestMethod]
        public void When_no_argument_is_passed_help_is_shown()
        {
            var args = new string[0];

            var res = parser.ParseArguments<CommandLineExperiments.OptionsCompability>(args);

            var text = help.ToString();
            Assert.IsTrue(text.Length > 0);
        }

        [TestMethod]
        public void When_jobToken_is_defined_and_url_is_defined_parsing_is_succesful()
        {
            var jobToken = Guid.NewGuid();
            const string url = "http://localhost:25446";
            var args = new[] { "--jobToken", jobToken.ToString(), "--url", url };
            var parsed = false;

            var res = parser.ParseArguments<OptionsCompability>(args)
                .WithParsed<OptionsCompability>(opt =>
                {
                    parsed = true;
                    Assert.AreEqual(jobToken, opt.JobToken);
                    Assert.AreEqual(url, opt.SigningWebApiUri);
                });

            var text = help.ToString();
            Assert.IsTrue(text.Length == 0);

            Assert.IsTrue(parsed);
        }

        [TestMethod]
        public void When_jobtoken_is_not_a_guid_parsing_fails()
        {
            const string url = "http://localhost:25446";
            var args = new[] { "--jobToken", "notaguid", "--url", url };

            var res = parser.ParseArguments<OptionsCompability>(args);

            var text = help.ToString();
            Assert.IsTrue(text.Length > 0);
        }

        [TestMethod]
        public void When_jobToken_is_defined_and_url_is_not_defined_parsing_fails()
        {
            var jobToken = Guid.NewGuid();
            var args = new[] { "--jobToken", jobToken.ToString() };

            var res = parser.ParseArguments<OptionsCompability>(args);

            var text = help.ToString();
            Assert.IsTrue(text.Length > 0);
        }

        [TestMethod]
        public void When_jobToken_is_not_defined_and_url_is_defined_parsing_fails()
        {
            const string url = "http://localhost:25446";
            var args = new[] { "--url", url };

            var res = parser.ParseArguments<OptionsCompability>(args);

            var text = help.ToString();
            Assert.IsTrue(text.Length > 0);
        }

        [TestMethod]
        public void When_pdf_path_is_defined_parsing_is_succesful()
        {
            const string pdfPath = "path\to\file.pdf";
            var args = new[] { "--pdf-path", pdfPath };
            var parsed = false;

            var res = parser.ParseArguments<OptionsLocal>(args)
                .WithParsed<OptionsLocal>(opt =>
                {
                    parsed = true;
                    Assert.AreEqual(pdfPath, opt.PdfPath);
                });

            var text = help.ToString();
            Assert.IsTrue(text.Length == 0);

            Assert.IsTrue(parsed);
        }
    }
}
