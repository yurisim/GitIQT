using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT
{
    internal class CheckBranch : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to check their current branch
        public void AskPrompt()
        {
            // Ask user to check their current branch
            Answer = $"git branch";

            var prompt = $"What git command do you need to type in to check the branch you are currently on?";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(prompt);

            GetResponses();
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
            Console.WriteLine("That's correct! You've successfully checked your current branch.");

            Console.WriteLine("Next swap to the dev branch.");
            new CheckoutDev().AskPrompt();
        }
    }
}
