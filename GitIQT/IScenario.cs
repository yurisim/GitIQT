using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitIQT
{
    public interface IScenario
    {
        void Prompt();
        bool Check(params string[] args);

        void Next();
    }
}
