using FluentAssertions;
using GitIQT;

namespace GitIQTTest
{
    public class StashTests
    {
        StashChanges StashInstance = new();

        [SetUp]
        public void Setup()
        {
            StashInstance = new();

            StashInstance.AskPrompt();
        }

        [Test]
        public void CorrectStash()
        {
            StashInstance.Response = $"git stash";

            var actual = StashInstance.CheckReponse();
            var prompt = "git stash is the correct command to use when stashing existing changes";

            actual.Should().BeTrue( because: prompt);
        }

        [Test]
        public void IncorrectStash()
        {
            StashInstance.Response = $"git --stash-changes --potato";

            var actual = StashInstance.CheckReponse();
            var prompt = "this is not the right command";

            actual.Should().BeFalse( because: prompt);
        }
    }
}