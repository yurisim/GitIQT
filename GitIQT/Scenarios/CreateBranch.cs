namespace GitIQT
{
    internal class CreateBranch : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        public void AskPrompt()
        {
            Answer = $"git branch feature/feature-name";

            var prompt = $"What git command do you need to type in to create a new branch from the dev branch? (Please name it feature/feature-name)";

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
            Console.WriteLine("That's correct! You've successfully created a new branch.");

            Console.WriteLine("Next change some of the code in your branch.");
            var changeCode = new ChangeCode();

            changeCode.AskPrompt();
            changeCode.GetResponses();
        }
    }
}
