namespace GitIQT
{
    internal class CommitChange : IScenario
    {
        private string Response = string.Empty;

        private string[] Answer = new string[2];

        // Ask user to commit changes to their branch
        public void AskPrompt()
        {
            // Ask user to commit changes to their branch
            Answer[0] = $"git commit -m \"Text files changed\"";
            Answer[1] = $"git commit";

            var prompt = $"What git command do you need to type in to commit changes to the branch? (Hint: Message must be \"Text files changed\")";

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
            Console.WriteLine("That's correct! You've successfully committed the changes to your branch.");

            Console.WriteLine("Next compare your branch to dev, to determine if a pull is required.");
            var diffCompare = new DiffCompare();

            diffCompare.AskPrompt();
            diffCompare.GetResponses();
        }
    }
}
