namespace GitIQT
{
    internal class ChangeCode : IScenario
    {
        private string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to check the status of their branch
        public void AskPrompt()
        {
            // Ask user to check the status of their branch
            Answer = $"git status";

            var prompt = $"You've made some changes to your code. What git command do you need to see the changes you have made in your current branch?";

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
            return Response == Answer;
        }

        public void NextPrompt()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("On branch feature/feature-name");
            Console.WriteLine("Changes not staged for commit");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("    Modified: AddThis.txt");
            Console.WriteLine("    Modified: AddThisToo.txt");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("no changes added to commit (use \"git add <filename>\" or \"git add --all\") ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You've successfully checked changes made in your branches files.");

            Console.WriteLine("Next add these changes to prepare a commit.");

            var AddFile = new AddFile();

            AddFile.AskPrompt();
            AddFile.GetResponses();
        }
    }
}
