using System.Net.Http.Headers;

namespace GitIQT
{
    internal class AddFile : IScenario
    {
        private string Response = string.Empty;

        private string[] Answer = new string[4];

        int AnswerCounter = 0;
        string AnsweredAlready = "";
        public void AskPrompt()
        {
            Answer[0] = $"git add AddThis.txt";
            Answer[1] = $"git add AddThisToo.txt";
            Answer[2] = $"git add -a";
            Answer[3] = $"git add --all";

            var prompt = $"What git command do you use to add the desired files to prepare for a commit";

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
            bool IsValidResponse = false;
            foreach(string s in Answer)
            {
                if(Response == s)
                {
                    IsValidResponse = true;
                }
            }
            return IsValidResponse;
        }

        public void NextPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if(Response == Answer[0] && Response != AnsweredAlready)
            {
                AnswerCounter++;
                AnsweredAlready = Response;
            }
            else if (Response == Answer[1] && Response != AnsweredAlready)
            {
                AnswerCounter++;
                AnsweredAlready = Response;
            }
            else if (Response == Answer[2] || Response == Answer[3])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Whoops! You added an extra file by mistake!");
                Console.WriteLine("");
                var addedByMistake = new AddedByMistake();

                addedByMistake.AskPrompt();
                addedByMistake.GetResponses();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Already Added to commit");
                GetResponses();
            }

            if(AnswerCounter < 2)
            {
                GetResponses();
            }
            else
            {
                    Console.WriteLine("That's correct! You've successfully checked changes made in your branches code.");

                    Console.WriteLine("Next commit these changes to your branch.");
                    var commitChange = new CommitChange();

                    commitChange.AskPrompt();
                    commitChange.GetResponses();
            }
        }
    }
}
