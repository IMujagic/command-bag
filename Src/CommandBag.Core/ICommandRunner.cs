using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core
{
    public interface ICommandRunner
    {
        void ResolveAndRun(string[] args);
    }
}
