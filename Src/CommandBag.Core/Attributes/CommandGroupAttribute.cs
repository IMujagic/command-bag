using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandGroupAttribute : Attribute
    {
        public string GroupName { get; }

        public CommandGroupAttribute(string groupName)
        {
            GroupName = groupName;
        }
    }
}
