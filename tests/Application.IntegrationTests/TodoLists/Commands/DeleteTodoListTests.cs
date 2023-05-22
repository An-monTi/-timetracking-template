using zeitag_grid_init.Application.Common.Exceptions;
using zeitag_grid_init.Application.TodoLists.Commands.CreateTodoList;
using zeitag_grid_init.Application.TodoLists.Commands.DeleteTodoList;
using zeitag_grid_init.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace zeitag_grid_init.Application.IntegrationTests.TodoLists.Commands;

using static Testing;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.Should().BeNull();
    }
}
