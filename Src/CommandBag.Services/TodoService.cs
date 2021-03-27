using CommandBag.Common;
using CommandBag.Core.Modules.Todo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Services
{
    public class TodoService : ITodoService
    {
        public Result AddItem(TodoDomainModel model)
        {
            //TODO: validate model and save it to db
            throw new NotImplementedException();
        }
    }
}
