namespace GitIQT.Scenarios
{
    internal class ChangeDirectory : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to commit changes to their branch
        public void AskPrompt()
        {
            // Ask user to commit changes to their branch
            Answer = $"cd ProjectBacon";

            var prompt = "However, while the repository has been cloned, you are not currently in it. What do you need to do next to access the local repository?";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(prompt);
        }

        public void GetResponses()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You are now in the ProjectBacon repository.");

            Console.WriteLine("Next push the changes back to the remote repository.");

            var checkBranch = new CheckBranch();

            checkBranch.AskPrompt();
            checkBranch.GetResponses();
        }
    }
}
