using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
