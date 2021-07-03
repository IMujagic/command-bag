using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandPayloadTypeAttribute : Attribute
    {
        public Type Type { get; }

        public CommandPayloadTypeAttribute(Type type)
        {
            Type = type;
        }
    }
}
