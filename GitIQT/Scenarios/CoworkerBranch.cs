namespace GitIQT
{
    internal class CoworkerBranch : IScenario
    {
        public string Response = string.Empty;

        private string[] Answer = new string[2];

        public void AskPrompt()
        {
            Answer[0] = $"git checkout -b coworker-branch feature/feature-name";
            Answer[1] = $"git checkout --branch coworker-branch feature/feature-name";
            var prompt = "What git command do you need to type in to create a new branch from your current branch? (Please name it coworker-branch) (Note: You are currently on 'feature/feature-name'.";

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
            Console.WriteLine("That's correct! You've created a new branch from your current one.");

            Console.WriteLine("Lets start over.");
            var coBranchFromDev = new CoBranchFromDev();

            coBranchFromDev.AskPrompt();
            coBranchFromDev.GetResponses();
        }
    }
}
