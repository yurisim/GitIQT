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
            Console.ForegroundColor = ConsoleColor.White;

            // Ask user to clone a repository
            // Get the first 5 characters of a GUID
            var repoID = Guid.NewGuid().ToString().Substring(0, 5);

            // Ask user to checkout the dev branch of the repository
            var repoUrl = $"https://github.com/552ODST/{repoID}/ProjectBacon.git";

            Console.WriteLine($"What git command do you need to type in to clone the repository located at '{repoUrl}'? Don't forget you can copy and paste!");
            Check(repoUrl);
        }

        // Check if Prompt() was successful
        public void Check(params string[] parameters)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Get the User's input
            var userInput = Console.ReadLine();

            // Check if the user input is correct
            var correctInput = $"git clone {parameters.First()}";

            if (userInput == correctInput)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("That's correct! You've successfully cloned the repository.");
                // CheckoutDevBranch();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not correct. Try again.");
                Check(parameters);
            }
        }
    }
}
