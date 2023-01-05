using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("That's correct! You've successfully checked out the dev branch of this repository.");

            Console.WriteLine("Next create your own branch from the dev branch. Please name it: 'feature/feature-name'.");
            new CreateBranch().AskPrompt();
        }
    }
}
