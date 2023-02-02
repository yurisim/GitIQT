namespace GitIQT
{
    internal class CreateBranch : IScenario
    {
        private string Response = string.Empty;

        private string[] Answer = new string[2];

        public void AskPrompt()
        {
<<<<<<< HEAD
            Answer = $"git branch feature/feature-name";
=======
            // Ask user to create their own branch
            Answer[0] = $"git checkout -b feature/feature-name dev";
            Answer[1] = $"git checkout --branch feature/feature-name dev";
>>>>>>> upstream/master

            var prompt = $"Next create your own branch from the dev branch. Please name it: 'feature/feature-name'.";


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
            Console.WriteLine("That's correct! You've successfully created a new branch and checked it out.");

            Console.WriteLine("Next change some of the code in your branch.");
            var changeCode = new ChangeCode();

            changeCode.AskPrompt();
            changeCode.GetResponses();
        }
    }
}
