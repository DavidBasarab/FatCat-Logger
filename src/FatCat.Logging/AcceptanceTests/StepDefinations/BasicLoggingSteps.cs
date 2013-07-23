using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FatCat.Logging;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinations
{
    [Binding]
    public class BasicLoggingSteps
    {
        private static string ApplicationName
        {
            get { return Process.GetCurrentProcess().ProcessName; }
        }

        private static string LogName
        {
            get { return string.Format("{0}_log.txt", ApplicationName); }
        }

        private static void DeleteLogFile()
        {
            if (File.Exists(LogName))
                File.Delete(LogName);
        }

        private IEnumerable<string> lines;

        [Given(@"I have nothing setup in the configuration")]
        public void GivenIHaveNothingSetupInTheConfiguration()
        {
            ConfigurationManager.GetSection("FatCatLogging").Should().BeNull();
        }

        [Given(@"the application has no log files")]
        public void GivenTheApplicationHasNoLogFiles()
        {
            DeleteLogFile();
        }

        [Then(@"a file is created matching the name of the application")]
        public void ThenAFileIsCreatedMatchingTheNameOfTheApplication()
        {
            File.Exists(LogName).Should().BeTrue();
        }

        [Then(@"the file contains only one line")]
        public void ThenTheFileContainsOnlyOneLine()
        {
            lines = File.ReadAllLines(LogName);

            lines.Count().Should().Be(1);
        }

        [Then(@"the file contains the message ""(.*)""")]
        public void ThenTheFileContainsTheMessage(string message)
        {
            var firstLine = lines.FirstOrDefault();

            firstLine.Should().Be(message);
        }

        [When(@"I write message ""(.*)""")]
        public void WhenIWriteMessage(string message)
        {
            Logger.Write(message);
        }
    }
}