using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Commands.Todo
{
    public class AddTodoPayload
    {
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}
