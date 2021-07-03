using CommandBag.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommandBag.Core
{
    public class CommandMetadata
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }

        public static CommandMetadata FromType(Type implType)
        {
            var attributes = ReadAttributes(implType);

            return new CommandMetadata
            {
                Name = implType.Name,
                Group = attributes.Group,
                Description = attributes.Description
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
