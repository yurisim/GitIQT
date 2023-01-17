namespace GitIQT
{
    public class Clone : IScenario
    {
        public string Response = string.Empty;

        private string Answer = string.Empty;

        public string RepoURL = string.Empty;

        // Ask user to clone a repository
        public void AskPrompt()
        {
            // Ask user to clone a repository
            // Get the first 5 characters of a GUID
            var repoID = Guid.NewGuid().ToString().Substring(0, 5);

            // Ask user to checkout the dev branch of the repository
            RepoURL = $"https://github.com/552ODST/{repoID}/ProjectBacon.git";
            Answer = $"git clone {RepoURL}";
            
            var prompt = $"What git command do you need to type in to clone the repository located at '{RepoURL}'? You can copy and paste!";

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(prompt);
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
            new CheckBranch().AskPrompt();
        }
    }
}
