namespace GitIQT
{
    public class ConfigGlobalsName : IScenario
    {
        public string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to change global configs
        public void AskPrompt()
        {
            // Ask user to change global configs
            Answer = "git config --global user.name";
            
            var prompt = new[] {
                "Looks like someone else's credentials are on your git machine.",
                "How do you set the global configs to use your name instead?",
                "(Do not input an actual name after the git command.)"
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
            Console.WriteLine("Correct, you have changed the global configs to use your name.");

            Console.WriteLine("Now, change the configs to use your email.");
            var configGlobals = new ConfigGlobalsEmail();

            configGlobals.AskPrompt();
            configGlobals.GetResponses();
        }
    }
}
