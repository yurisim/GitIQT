using FluentAssertions;
using GitIQT;

namespace GitIQTTest
{
    public class ConfigTests
    {
        ConfigGlobalsName NameInstance = new();
        ConfigGlobalsEmail EmailInstance = new();

        [SetUp]
        public void Setup()
        {
            NameInstance = new ConfigGlobalsName();
            EmailInstance = new ConfigGlobalsEmail();
            NameInstance.AskPrompt();
            EmailInstance.AskPrompt();
        }

        [Test]
        public void CorrectName()
        {
            NameInstance.Response = "git config --global user.name";

            var actual = NameInstance.CheckReponse();
            var prompt = "git config --global user.name is the correct command to use when changing global username configs";

            actual.Should().BeTrue( because: prompt);
        }

        [Test]
        public void CorrectEmail()
        {
            EmailInstance.Response = "git config --global user.email";

            var actual = EmailInstance.CheckReponse();
            var prompt = "git config --global user.email is the correct command to use when changing global email configs";

            actual.Should().BeTrue( because: prompt);
        }
        [Test]
        public void IncorrectName()
        {
            NameInstance.Response = "git --global config name";

            var actual = NameInstance.CheckReponse();
            var prompt = "this is not the correct command to use when changing global username configs";

            actual.Should().BeFalse(because: prompt);
        }

        [Test]
        public void IncorrectEmail()
        {
            EmailInstance.Response = "git --global config email";

            var actual = EmailInstance.CheckReponse();
            var prompt = "this is not the correct command to use when changing global email configs";

            actual.Should().BeFalse(because: prompt);
        }
    }
}
