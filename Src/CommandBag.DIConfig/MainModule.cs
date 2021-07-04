using CommandBag.Core;
using CommandBag.Core.Logging;
using CommandBag.Infrastructure;
using CommandBag.Infrastructure.Logging;
using CommandBag.Commands;
using CommandBag.Commands.Todo;
using CommandBag.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CommandBag.DIConfig
{
    public class MainModule
    {
        public static List<CommandMetadata> CommandMetadataList = new List<CommandMetadata>();
        
        public static void Load(IServiceCollection serviceCollection)
        {
            var servicesAssembly = typeof(TodoService).Assembly;
            var commandAssembly = typeof(AddTodoCommand).Assembly;

            CommandBagLog.SetLogProvider(new DefaultLogProvider());

            servicesAssembly.GetTypes()
                .Where(x => !x.GetTypeInfo().IsAbstract && x.Name.EndsWith("Service"))
                .Select(implType => implType.GetInterfaces()
                    .Select(
                        it => serviceCollection.AddTransient(it, implType))
                    .ToList())
                .ToList();

            commandAssembly.GetTypes()
                .Where(x => !x.GetTypeInfo().IsAbstract && x.Name.EndsWith("Command"))
                .Select(implType =>
                {
                    // add each job metadata to list which is later used to see available jobs
                    CommandMetadataList.Add(CommandMetadata.FromType(implType));

                    //TODO: Check if NULL and if really inherits from IDomainCommand

                    return serviceCollection.AddTransient(implType);
                })
                .ToList();

            serviceCollection.AddTransient<Func<string, object>>(serviceProvider => key =>
            {
                var type = commandAssembly.GetTypes()
                    .Where(x => !x.GetTypeInfo().IsAbstract && x.Name.Equals(key))
                    .SingleOrDefault();

                return serviceProvider.GetService(type);
            });

            serviceCollection.AddTransient<ICommandRunner, CommandRunner>();
        }
    }
}
