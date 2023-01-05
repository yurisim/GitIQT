using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT
{
    internal class CreateBranch : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to create their own branch
        public void AskPrompt()
        {
            // Ask user to create their own branch
            Answer = $"git branch feature/feature-name";

            var prompt = $"What git command do you need to type in to create a new branch from the dev branch? (Please name it feature/feature-name)";

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
            Console.WriteLine("That's correct! You've successfully created a new branch.");

            Console.WriteLine("Next change some of the code in your branch.");
            new ChangeCode().AskPrompt();
        }
    }
}
