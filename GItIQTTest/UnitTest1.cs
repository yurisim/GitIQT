using GitIQT.Scenarios;

namespace GItIQTTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CloneRepoTests()
        {
            var whateverCloneTest = new CloneRepo();

            whateverCloneTest.AskPrompt();

            //var repoURL = whateverCloneTest.RepoURL;
        }
    }
}