namespace GitIQT
{
    internal class CheckoutDev : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to ckeckout dev branch
        public void AskPrompt()
        {
            // Ask user to ckeckout dev branch
            Answer = $"git checkout dev";

            var prompt = $"What git command do you need to type in to checkout the repository named 'dev'?";

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
            Console.WriteLine("That's correct! You've successfully checked out the dev branch of this repository.");

            Console.WriteLine("Next create your own branch from the dev branch. Please name it: 'feature/feature-name'.");
            var createBranch = new CreateBranch();

            // These are seperated from the previous version where it was a one line `new Clone().AskPrompt();` to this to better
            // control how the tests run
            createBranch.AskPrompt();
            createBranch.GetResponses();
        }
    }
}
