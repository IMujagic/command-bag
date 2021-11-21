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

        public void ResolveAndRun(string commandName, string payload)
        {
            var commandClassInstance = _commandResolver(commandName);

            if(!string.IsNullOrWhiteSpace(payload))
            {
                var executeMethodInfo = commandClassInstance.GetType().GetMethod(nameof(IDomainCommand<object>.Execute));
                var payloadParameter = executeMethodInfo.GetParameters().Single();

                var deserializedPayload = DeserializePayload(payload, payloadParameter);

                executeMethodInfo.Invoke(commandClassInstance, new[] { deserializedPayload });
            }
            else
            {
                var executeMethodInfo = commandClassInstance.GetType().GetMethod(nameof(IDomainCommand.Execute));
                executeMethodInfo.Invoke(commandClassInstance, null);
            }
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
