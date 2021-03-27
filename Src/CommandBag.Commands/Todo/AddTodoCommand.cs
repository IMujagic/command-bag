using CommandBag.Common;
using CommandBag.Core;
using CommandBag.Core.Attributes;
using CommandBag.Core.Modules.Todo;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandBag.Commands.Todo
{
    [CommandGroup("Todo")]
    [CommandDescription("This command will take the todo item name from payload and save it.")]
    public class AddTodoCommand : IDomainCommand
    {
        private readonly ITodoService _todoService;

        public AddTodoCommand(ITodoService todoService)
        {
            this._todoService = todoService;
        }

        public Result Execute(CommandPayload payload)
        {
            var todoPayload = payload.ToDomainModel<TodoDomainModel>();

            _todoService.AddItem(todoPayload);

            return Result.Ok();
        }
    }
}
