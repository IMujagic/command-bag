using CommandBag.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandBag.Commands
{
    public class CommandRunner : ICommandRunner
    {
        private readonly Func<string, IDomainCommand> _commandResolver;

        public CommandRunner(Func<string, IDomainCommand> commandResolver)
        {
            _commandResolver = commandResolver;
        }

        public void ResolveAndRun(string[] args)
        {
            var instance = _commandResolver(args[0]);

            instance.Execute(args);
        }
    }
}
