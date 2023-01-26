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
            Answer = $"git checkout -b dev";

            var prompt = $"What git command do you need to type in to checkout the branch named 'dev'?";

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You've successfully checked out the dev branch of this repository.");

            var createBranch = new CreateBranch();

            // These are seperated from the previous version where it was a one line `new Clone().AskPrompt();` to this to better
            // control how the tests run
            createBranch.AskPrompt();
            createBranch.GetResponses();
        }
    }
}
