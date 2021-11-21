using CommandBag.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core
{
    public interface IDomainCommand<T>
    {
        Result Execute(T payload);
    }

    public interface IDomainCommand
    {
        Result Execute();
    }
}
