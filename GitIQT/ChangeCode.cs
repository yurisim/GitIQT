using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT
{
    internal class ChangeCode : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to check the status of their branch
        public void AskPrompt()
        {
            // Ask user to check the status of their branch
            Answer = $"git status";

            var prompt = $"You've made some changes to your code. What git command do you need to see the changes you have made in your current branch?";

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
            Console.WriteLine("That's correct! You've successfully checked changes made in your branches code.");

            Console.WriteLine("Next commit these changes to your branch.");
            new CommitChange().AskPrompt();
        }
    }
}
