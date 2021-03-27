using CommandBag.Core;
using CommandBag.Core.Modules.Todo;
using CommandBag.Commands.Todo;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CommandBag.UnitTests.Commands
{
    public class AddTodoCommandTests
    {
        [Fact]
        public void AddTodoCommand_WithEmptyPayload_ShouldThrowException()
        {
            // arrange
            var serviceMock = new Mock<ITodoService>();
            var payload = new CommandPayload();
            var addTodoCommand = new AddTodoCommand(serviceMock.Object);

            // act & assert
            Assert.Throws<Exception>(() => addTodoCommand.Execute(payload));
        }
    }
}
