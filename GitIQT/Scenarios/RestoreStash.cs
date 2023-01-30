namespace GitIQT
{
    internal class RestoreStash : IScenario
    {
        public string Response = string.Empty;

        private string[] Answer = new string[2];

        public void AskPrompt()
        {
            Answer[0] = $"git stash pop";
            Answer[1] = $"git stash apply";

            var prompt = "You want to restore the changes you stashed earlier. What git command can help you accomplish this?";

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
            Console.WriteLine("That's correct! You've successfully restored the stashed changes.");
            if (Response == Answer[1]) // Explaining difference between 'stash pop' and 'stash apply'
            {
                Console.WriteLine("Normally, when using 'git stash apply', you would still have the stashed changes stored in memory and would have to remove them manually using 'git stash drop <stash-name>'.");
                Console.WriteLine("For the purposes of this exercise however, you don't have to worry about it.");
            }
            Console.WriteLine("");
            Console.WriteLine("Your coworker wants to work on his own idea in a separate branch. How do you make a new branch, using this branch as the root?");
            var coworkerBranch = new CoworkerBranch();

            coworkerBranch.AskPrompt();
            coworkerBranch.GetResponses();
        }
    }
}
