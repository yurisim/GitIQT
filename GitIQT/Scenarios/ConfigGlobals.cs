namespace GitIQT
{
    internal class ConfigGlobals : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to change global configs
        public void AskPrompt()
        {
            // Ask user to change global configs
            Answer = "git config --global user.name \"FIRST_NAME LAST_NAME\"";

            var prompt = new[] {
                "Looks like someone else's credentials are on your git machine.",
                "How do you set the global configs to use your name and email instead?" 
            };
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string s in prompt)
                Console.WriteLine(s);
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
            Console.WriteLine("That's correct! You've successfully changed the global configs to use your credentials.");

            Console.WriteLine("Next let's clone a repository onto your local machine, so you can work on a project simultaneously with other users, without affecting their work.");
            var clone = new Clone();

            clone.AskPrompt();
            clone.GetResponses();
        }
    }
}
