using CommandBag.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Modules.Todo
{
    public interface ITodoService
    {
        Result AddItem(TodoDomainModel model);
    }
}
