namespace GitIQT
{
    internal class PushBranch : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to push changes to remote
        public void AskPrompt()
        {
            // Ask user to push changes to remote
            Answer = $"git push";

            var prompt = $"What git command do you need to type in to push the committed changes back to the remote repository. (git pull has already been performed, and the branch is up-to-date)";

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
            Console.WriteLine("That's correct! You've successfully pushed the branch back to the remote repository.");

            Console.WriteLine("Congratulations! You have successfully completed all your git tasks.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
