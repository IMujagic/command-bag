using CommandBag.Common;
using CommandBag.Core.Modules.Todo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Infrastructure.Persistence
{
    public class TodoRepository : ITodoRepository
    {
        public Result DeleteTodo(string name)
        {
            throw new NotImplementedException();
        }

        public Result GetAll()
        {
            throw new NotImplementedException();
        }

        public Result SaveTodo(string name)
        {
            throw new NotImplementedException();
        }

        public Result UpdateTodo(string name, bool status)
        {
            throw new NotImplementedException();
        }
    }
}
