using System.IO;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AcceptanceTests.StepDefinations
{
    [Binding]
    public class BasicHookEmSteps
    {
        private const string FILE_NAME = "testFile.test";

        private static void DeleteFile()
        {
            if (File.Exists(FILE_NAME))
                File.Delete(FILE_NAME);
        }

        private static void WriteFileToSystem()
        {
            using (var fileSystem = File.Create(FILE_NAME))
                fileSystem.Close();
        }

        private bool givenExecuted;
        private bool whenExecuted;

        [Given(@"a file is written to the system")]
        public void GivenAFileIsWrittenToTheSystem()
        {
            WriteFileToSystem();
        }

        [Given(@"have access to the file system")]
        public void GivenHaveAccessToTheFileSystem() {}

        [Given(@"I have specflow referenced")]
        public void GivenIHaveSpecflowReferenced()
        {
            givenExecuted = true;
        }

        [Before]
        public void SetUp()
        {
            givenExecuted = false;
            whenExecuted = false;
        }

        [After]
        public void TearDown()
        {
            DeleteFile();
        }

        [Then(@"each step is executed")]
        public void ThenEachStepIsExecuted()
        {
            givenExecuted.Should().BeTrue();
            whenExecuted.Should().BeTrue();
        }

        [Then(@"the file is deleted")]
        public void ThenTheFileIsDeleted()
        {
            File.Exists(FILE_NAME).Should().BeFalse();
        }

        [Then(@"the file is written to the file system")]
        public void ThenTheFileIsWrittenToTheFileSystem()
        {
            File.Exists(FILE_NAME).Should().BeTrue();
        }

        [When(@"a file is deleted from the system")]
        public void WhenAFileIsDeletedFromTheSystem()
        {
            DeleteFile();
        }

        [When(@"a file is written to the sytem")]
        public void WhenAFileIsWrittenToTheSytem()
        {
            WriteFileToSystem();
        }

        [When(@"I run this test")]
        public void WhenIRunThisTest()
        {
            whenExecuted = true;
        }
    }
}