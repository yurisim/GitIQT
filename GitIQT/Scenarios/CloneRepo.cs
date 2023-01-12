using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT.Scenarios
{
    public class CloneRepo: IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to clone a repository
        public string AskPrompt()
        {
            // Ask user to clone a repository
            // Get the first 5 characters of a GUID
            var repoID = Guid.NewGuid().ToString().Substring(0, 5);

            // Ask user to checkout the dev branch of the repository
            var RepoURL = $"https://github.com/552ODST/{repoID}/ProjectBacon.git";
            Answer = $"git clone {RepoURL}";

            var prompt = $"What git command do you need to type in to clone the repository located at '{RepoURL}'? You can copy and paste!";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(prompt);

            GetResponses();

            return RepoURL;
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
            Console.WriteLine("That's correct! You've successfully cloned the repository.");

            Console.WriteLine("Next check what branch you are on and then swap to the dev branch.");
            //new CheckoutDev().Prompt();
        }
    }
}
