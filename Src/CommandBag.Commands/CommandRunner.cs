using CommandBag.Commands.Todo;
using CommandBag.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandBag.Commands
{
    public class CommandRunner : ICommandRunner
    {
        private readonly Func<string, object> _commandResolver;

        public CommandRunner(Func<string, object> commandResolver)
        {
            _commandResolver = commandResolver;
        }

        public void ResolveAndRun(string[] args)
        {
            var instance = _commandResolver(args[0]);
            var methodInfo = instance.GetType().GetMethod("Execute");
            var parameter = methodInfo.GetParameters().Single();

            var JSONCovert = typeof(JsonConvert);
            var parameterTypes = new[] { typeof(string) };
            var deserializer = JSONCovert.GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(i => i.Name.Equals("DeserializeObject", StringComparison.InvariantCulture))
                .Where(i => i.IsGenericMethod)
                .Where(i => i.GetParameters().Select(a => a.ParameterType).SequenceEqual(parameterTypes))
                .Single();
            
            deserializer = deserializer.MakeGenericMethod(parameter.ParameterType);

            var o = deserializer.Invoke(null, new object[] { args[1] });

            methodInfo.Invoke(instance, new[] { o });
        }
    }
}
