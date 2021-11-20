using CommandBag.Core.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandBag.Core
{
    public class CommandMetadata
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public Type PayloadType { get; set; }
        public string PayloadTypeSerialized => JsonConvert.SerializeObject(Activator.CreateInstance(PayloadType));

        public static CommandMetadata FromType(Type implType)
        {
            var attributes = ReadAttributes(implType);

            var executeMethodInfo = implType.GetMethod(nameof(IDomainCommand<object>.Execute));
            
            return new CommandMetadata
            {
                Name = implType.Name,
                Group = attributes.Group,
                Description = attributes.Description,
                PayloadType = executeMethodInfo.GetParameters().Single().ParameterType
            };
        }

        private static (string Group, string Description) ReadAttributes(Type implType)
        {
            var attributes = implType.GetCustomAttributes();
            var group = string.Empty;
            var description = string.Empty;

            foreach(var attribute in attributes)
            {
                if(attribute is CommandGroupAttribute)
                {
                    var a = (CommandGroupAttribute)attribute;
                    group = a.GroupName;
                    continue;
                }

                if (attribute is CommandDescriptionAttribute)
                {
                    var a = (CommandDescriptionAttribute)attribute;
                    description = a.Description;
                    continue;
                }
            }

            return (group, description);
        }
    }
}
