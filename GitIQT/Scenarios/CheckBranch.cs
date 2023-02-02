using System.ComponentModel.Design;

namespace GitIQT
{
    internal class CheckBranch : IScenario
    {
        private string Response = string.Empty;

        private string[] Answer = new string[2];

        // Ask user to check their current branch
        public void AskPrompt()
        {
            // Ask user to check their current branch
            Answer[0] = $"git branch";
            Answer[1] = $"git status";

            var prompt = $"What git command do you need to type in to check the branch you are currently on?";

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
            bool isValidResponse = false;
            foreach (string s in Answer)
                if (Response == s)
                    isValidResponse = true;
            return isValidResponse;
        }

        public void NextPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You've successfully checked your current branch.");

            var checkoutDev = new CheckoutDev();

            checkoutDev.AskPrompt();
            checkoutDev.GetResponses();
        }
    }
}
