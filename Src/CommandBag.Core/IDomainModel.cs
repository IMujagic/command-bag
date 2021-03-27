using CommandBag.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core
{
    public interface IDomainModel
    {
        Result MapArgsToProperties(IDictionary<string, string> parsedArgs);
    }
}
