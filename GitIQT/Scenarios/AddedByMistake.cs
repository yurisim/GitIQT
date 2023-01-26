namespace GitIQT
{
    internal class AddedByMistake : IScenario
    {
        public string Response = string.Empty;

        private string Answer = string.Empty;

        public void AskPrompt()
        {
            Answer = "git reset DoNotAddThis.txt";

            var prompt = "Oh no! looks like DoNotAddThis.txt was accidently added to be committed! How do you remove it?";

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

        public bool CheckReponse()
        {
            return Response == Answer;
        }

        public void NextPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You've successfully removed the unwanted file.");

            Console.WriteLine("Next commit the added files.");

            var commitChange = new CommitChange();

            commitChange.AskPrompt();
            commitChange.GetResponses();
        }
    }
}
