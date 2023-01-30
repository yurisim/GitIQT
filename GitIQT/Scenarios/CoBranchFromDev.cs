using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT
{
    internal class CoBranchFromDev
    {
        private string Response = string.Empty;

        private string[] Answer = new string[2];

        // Ask user to ckeckout dev branch
        public void AskPrompt()
        {
            // Ask user to ckeckout dev branch
            Answer[0] = $"git checkout -b coworker-branch dev";
            Answer[1] = $"git checkout --branch coworker-branch dev";

            var prompt = $"This time, create 'coworker-branch' again, but use 'dev' as the reference point.";

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
            Console.WriteLine("That's correct! You've successfully created your coworkers branch using 'dev' as the reference point.");

            Console.WriteLine("Now, you've made some (hypothetical) changes to your code, and want to submit it back to the remote repository.");
            var changeCode = new ChangeCode();

            changeCode.AskPrompt();
            changeCode.GetResponses();
        }
    }
}
