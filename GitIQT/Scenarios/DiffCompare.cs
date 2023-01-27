namespace GitIQT
{
    internal class DiffCompare : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to check their current branch
        public void AskPrompt()
        {
            // Ask user to check their current branch
            Answer = $"git diff master..feature/feature-name";

            var prompt = $"What git command compares the differences between master and your branch? (use feature/feature-name)";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(prompt);
        }

        public void GetResponses()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Response = Console.ReadLine()?.Trim() ?? "";

            if (CheckReponse())
            {
                NextPrompt();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not correct. Try again.");
                GetResponses();
            }
        }

        // Check if Prompt() was successful
        public bool CheckReponse()
        {
            return Response == Answer;
        }

        public void NextPrompt()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("NO CHANGES MADE TO 'master' MERGING IS ALLOWED");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You've successfully compared your branch to the master branch, a pull request is not needed at this time.");

            Console.WriteLine("Lets push your changes back to the master branch.");

            var pushBranch = new PushBranch();

            pushBranch.AskPrompt();
            pushBranch.GetResponses();
        }
    }
}
