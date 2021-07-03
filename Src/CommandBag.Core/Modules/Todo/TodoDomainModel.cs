using CommandBag.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Modules.Todo
{
    public class TodoDomainModel
    {
        public string Name { get; set; }
        public TodoStatusEnum Status { get; set; }
    }
}
