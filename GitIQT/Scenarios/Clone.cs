namespace GitIQT.Scenarios
{
    public class Clone : IScenario
    {
        public string Response = string.Empty;

        private string[] Answer = new string[2];

        public string RepoURL = string.Empty;

        // Ask user to clone a repository
        public void AskPrompt()
        {
            // Ask user to clone a repository
            // Get the first 5 characters of a GUID
            var repoID = Guid.NewGuid().ToString().Substring(0, 5);

            // Ask user to checkout the dev branch of the repository
            RepoURL = $"https://github.com/552ODST/{repoID}/ProjectBacon.git";
            Answer[0] = $"git clone {RepoURL}";
            Answer[1] = $"git clone {RepoURL} -b thisBranch-name --single-branch";


            var prompt = new[] {
                "First, you need to clone the repository located at:",
                $"{RepoURL}?",
                "You can copy and paste!",
                "",
                "Alternatively, you could clone from a specific branch",
                "One branch that exists in this repository is named",
                "thisBranch-name"
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
                NextPrompt();
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
            foreach (string s in Answer)
                if (Response == s)
                    return true;
            return false;
        }

        public void NextPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (Response == Answer[0])
            {
                Console.WriteLine("That's correct! You've successfully cloned the repository from the main branch.");
            }
            if (Response == Answer[1])
            {
                Console.WriteLine("That's correct! You've successfully cloned the repository from thisBranch-name branch");             
            }

            var changeDirectory = new ChangeDirectory();

            changeDirectory.AskPrompt();
            changeDirectory.GetResponses();
        }
    }
}
