using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT
{
    internal class CommitChange : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to commit changes to their branch
        public void AskPrompt()
        {
            // Ask user to commit changes to their branch
            Answer = $"git commit";

            var prompt = $"What git command do you need to type in to commit changes to the branch? (git add has already been performed)";

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
            Console.WriteLine("That's correct! You've successfully committed the changes to your branch.");

            Console.WriteLine("Next push the changes back to the remote repository.");
            new PushBranch().AskPrompt();
        }
    }
}
