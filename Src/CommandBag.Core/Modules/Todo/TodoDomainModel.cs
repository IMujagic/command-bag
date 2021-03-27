using CommandBag.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Modules.Todo
{
    public class TodoDomainModel : IDomainModel
    {
        public string Name { get; set; }
        public TodoStatusEnum Status { get; set; }

        public Result MapArgsToProperties(IDictionary<string, string> parsedArgs)
        {
            throw new NotImplementedException();
        }
    }
}
