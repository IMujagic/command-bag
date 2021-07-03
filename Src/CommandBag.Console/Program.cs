using CommandBag.Core;
using CommandBag.DIConfig;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandBag.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            MainModule.Load(serviceCollection);

            if(!args.Any())
            {
                ShowAvailableCommands(MainModule.CommandMetadataList);
                return;
            }

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var runner = serviceProvider.GetService<ICommandRunner>();

            runner.ResolveAndRun(args);
        }

        private static void ShowAvailableCommands(List<CommandMetadata> commandMetadataList)
        {
            System.Console.WriteLine("Available commands:");

            foreach (var command in commandMetadataList)
            {
                System.Console.WriteLine(Environment.NewLine);

                System.Console.WriteLine($"Command name: {command.Name}");
                System.Console.WriteLine($"Group: {command.Group}");
                System.Console.WriteLine($"Description: {command.Description}");
            }
        }
    }
}
