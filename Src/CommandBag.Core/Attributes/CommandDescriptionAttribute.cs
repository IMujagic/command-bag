using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Attributes
{
    public class CommandDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public CommandDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
