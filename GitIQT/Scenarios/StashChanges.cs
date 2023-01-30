namespace GitIQT
{
    public class StashChanges : IScenario
    {
        public string Response = string.Empty;

        private string Answer = string.Empty;

        // Ask user to stash current changes
        public void AskPrompt()
        {
            // Ask user to stashcurrent changes
            Answer = $"git stash";

            var prompt = new[] {
                "You an a coworker are struggling on a task on a feature branch and you want to try something radically different that would require you to undo a lot of a uncommited work the coworker did. ",
                "You don't really want to commit, because you want to quickly undo it if you go with the way you are thinking of. What's a way to save your coworkers work?"
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string s in prompt)
                Console.WriteLine(s);
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("That's correct! You've successfully stashed changes made by your coworker.");

            Console.WriteLine("Looks like your idea was not quite what was needed, what do you need to do to get your coworker's changes back?");
            var restoreChanges = new RestoreStash();

            restoreChanges.AskPrompt();
            restoreChanges.GetResponses();
        }
    }
}
