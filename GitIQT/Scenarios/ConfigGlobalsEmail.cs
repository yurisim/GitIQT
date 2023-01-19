namespace GitIQT
{
    public class ConfigGlobalsEmail : IScenario
    {
        public string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to change global configs
        public void AskPrompt()
        {
            // Ask user to change global configs
            Answer = "git config --global user.email";

            var prompt = new[] {
                "How do you set the global configs to use your email instead?",
                "(Do not input an actual email after the git command.)"
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
            Console.WriteLine("Correct, you have changed the global configs to use your email.");

            Console.WriteLine("Next, lets clone a repository.");
            var clone = new Clone();

            clone.AskPrompt();
            clone.GetResponses();
        }
    }
}
