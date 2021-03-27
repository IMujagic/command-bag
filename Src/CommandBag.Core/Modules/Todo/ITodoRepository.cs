using CommandBag.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Core.Modules.Todo
{
    public interface ITodoRepository
    {
        Result SaveTodo(string name);
        Result DeleteTodo(string name);
        Result UpdateTodo(string name, bool status);
        Result GetAll();
    }
}
