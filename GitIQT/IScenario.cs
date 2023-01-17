namespace GitIQT
{
    public interface IScenario
    {
        // Methods
        void AskPrompt();
        void GetResponses();
        bool CheckReponse();
        void NextPrompt();
    }
}
