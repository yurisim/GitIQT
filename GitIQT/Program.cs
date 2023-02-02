namespace GitIQT.Scenarios
{
    internal class GitIQT
    {
        // Entry point for the program
        static void Main(string[] args)
        {

            var prompts = new[]
            {
                "======================================================================================================================",
                "It's your first day at your new job and there's a lot of stuff to do. Your boss gives you a list of tasks to complete:",
                "1. Clone a repository",
                "    ( Clone from main branch or a specific branch )",
                "2. Check out what branch you are on",
                "3. Checkout the dev branch of the repository",
                "4. Create a new branch called 'feature/feature-name' from the dev branch",
                "5. Make some changes to the code",
                "6. Commit the changes to the feature branch",
                "7. Push the feature branch to the remote repository",
                "======================================================================================================================",
                "",
                "======================",
                "= Let's get started! =",
                "======================",
                "",
            };

            Console.ForegroundColor = ConsoleColor.Blue;
            // Print out the prompts
            foreach (var prompt in prompts) Console.WriteLine(prompt);


            var configGlobals = new ConfigGlobalsName();

            configGlobals.AskPrompt();
            configGlobals.GetResponses();
        }
    }
}