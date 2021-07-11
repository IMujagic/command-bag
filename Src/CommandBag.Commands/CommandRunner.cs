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
            var commandClassInstance = _commandResolver(args[0]);

            var executeMethodInfo = commandClassInstance.GetType().GetMethod(nameof(IDomainCommand<object>.Execute));
            var payloadParameter = executeMethodInfo.GetParameters().Single();

            var deserializedPayload = DeserializePayload(args[1], payloadParameter);

            executeMethodInfo.Invoke(commandClassInstance, new[] { deserializedPayload });
        }

        private static object DeserializePayload(string payload, ParameterInfo parameter)
        {
            var JSONCovert = typeof(JsonConvert);
            var parameterTypes = new[] { typeof(string) };

            var deserializeMethod = JSONCovert.GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(i => i.Name.Equals(nameof(JsonConvert.DeserializeObject), StringComparison.InvariantCulture))
                .Where(i => i.IsGenericMethod)
                .Where(i => i.GetParameters().Select(a => a.ParameterType).SequenceEqual(parameterTypes))
                .Single();

            var deserializedPayload = deserializeMethod
                .MakeGenericMethod(parameter.ParameterType)
                .Invoke(null, new object[] { payload });

            return deserializedPayload;
        }
    }
}
