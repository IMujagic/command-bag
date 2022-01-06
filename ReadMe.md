### Introduction

Overal inspiration comes from my desire to have a project where I can just define a new functionality using some convention, implement it, define the input data (payload) and everything will automatically become available for execution (either using CLI or Web).

With `CommandBag` you have a possibility to write any kind of functionality that will be packed in a command object. All defined commands will be automatically listed in a web app and in a console project and will be available for execution.

The idea is to have commands isolated from each other and that each command represents only one piece of functionality. If there are some commands that operate in the same context they can be grouped, but that's only for easier navigation through the list of available commands. 

### Setup

1. Clone the repository
2. Go to `.\Src` folder and open the solution
3. There are two executable projects in this solution: `CommandBag.Console` and `CommandBag.Web`
4. Start both or the one you prefer by using either `dotnet run` cli command or standard Visual Studio options.

### How it works

All commands are automatically discoverable and available for execution by just following a simple convention during implementation.

For a command to be automatically available for execution it needs to implement the `IDomainCommand<T>` interface where the `T` represents the command payload type.
If you have a command without the payload, just implement the `IDomainCommand`. 

Here is an command example:

```csharp
[CommandGroup("Todo")]
[CommandDescription("This command will take the todo item name from payload and save it.")]
public class AddTodoCommand : IDomainCommand<AddTodoPayload>
{
    private readonly ITodoService _todoService;

    public AddTodoCommand(ITodoService todoService)
    {
        this._todoService = todoService;
    }

    public Result Execute(AddTodoPayload payload)
    {
        return Result.Ok();
    }
}
```

- `AddTodoPayload` is a command payload and it will be provided as an serialized json from the presentation layer. The Command runner will take care of deserialization and executing the `Execute` method.
- `ITodoService` is an domain service. It's not something required but it just shows that you can inject dependencies into your commands.
- `CommandGroup` and `CommandDescription` are attributes that we use to enrich our command with additional informations. `CommandGroup` is used for easier grouping and sorting of related commands and `CommandDescription` is used to provide the description for the command that will be displayed in CLI or Web client.

Presentation layer (Console and Web projects) don't need to be changed or extended when the new command is defined. Each command will be pickud up by the DI configuration during the application bootstrap and added to command collection.

Let's explain quickly the executable projects:

- CommandBag.Console
    - This is a normal .NET Console project that gives us an option to run the commands using command line.
    - If the `CommandBag.Console` is started without the target command it will just list the available commands.
- CommandBag.Web
    - This is ASP.NET Core Razor Pages project that we can use to execute the commands in a more user friendly way.
    - Available commands are listed on a home page and each can be executed by clicking on "Execute" button and providing payload.

Both presentation layer projects don't call the commands directly. They take the command name and payload serialized json and call the `CommandRunner` method `RunAndResolve`.
This method, using DI container and reflection creates the command instance, payload instance and call the command `Execute` method. This way, we can add any type of client and leave our domain layer completely client agnostic. 











