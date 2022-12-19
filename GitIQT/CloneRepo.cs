using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT
{
    internal class CloneRepo : IScenario
    {
        // Ask user to clone a repository
         public void Prompt()
        {
            // Ask user to clone a repository
            // Get the first 5 characters of a GUID
            var repoID = Guid.NewGuid().ToString().Substring(0, 5);

            // Ask user to checkout the dev branch of the repository
            var repoUrl = $"https://github.com/552ODST/{repoID}/ProjectBacon.git";

            var prompt = $"What git command do you need to type in to clone the repository located at '{repoUrl}'? You can copy and paste!";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(prompt);

            var success = false;
            while (!success)
            {
                if (Check(repoUrl))
                {
                    success = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That's not correct. Try again.");
                }
            }

            Next();
        }

        // Check if Prompt() was successful
        public bool Check(params string[] parameters)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Get the User's input
            var userInput = Console.ReadLine();

            // Check if the user input is correct
            var correctInput = $"git clone {parameters.First()}";

            return userInput == correctInput;
        }

        public void Next()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You've successfully cloned the repository.");

            Console.WriteLine("Check what branch you are on.");
            //new CheckoutDev().Prompt();
        }
    }
}
