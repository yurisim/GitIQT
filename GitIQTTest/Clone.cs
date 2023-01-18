using FluentAssertions;
using GitIQT;

namespace GitIQTTest
{
    public class Tests
    {
        ConfigGlobals CloneInstance = new ConfigGlobals();

        [SetUp]
        public void Setup()
        {
            // Use this to set up your tests. It will run for each one
            CloneInstance = new ConfigGlobals();

            // Set the Answer property to the correct answer
            CloneInstance.AskPrompt(); // This is required so that the answer property is properly filled.
        }

        // MAKE SURE YOU DON'T TRIGGER ANY METHODS THAT WILL ASK FOR USER INPUT
        // IT WILL CAUSE THE TESTS TO HANG
        // IMPORTANT!!!

        [Test]
        public void CorrectClone()
        {
            // IMPORTANT!!!

            CloneInstance.Response = $"git clone {CloneInstance.RepoURL}";

            var actual = CloneInstance.CheckReponse();
            var expected = true;
            var prompt = "git clone is the correct command to use when just cloning a repository";

            actual.Should().Be(expected, because: prompt);
            // actual.Should().BeTrue( because: prompt); // THis works too but I wanted to be explicit as to how the actual/expect variables should be.
        }

        [Test]
        public void IncorrectClone()
        {

            CloneInstance.Response = $"LITERALLY ANYTHING ELSE {CloneInstance.RepoURL}";

            var actual = CloneInstance.CheckReponse();
            var expected = false;
            var prompt = "this is not the right command";

            actual.Should().Be(expected, because: prompt);
            // actual.Should().BeFalse( because: prompt); // THis works too but I wanted to be explicit as to how the actual/expect variables should be.
        }
    }
}