<<<<<<< HEAD
﻿using Toss.Inventory.Application.TodoLists.Commands.CreateTodoList;
using Toss.Inventory.Application.TodoLists.Commands.DeleteTodoList;
using Toss.Inventory.Domain.Entities;

namespace Toss.Inventory.Application.FunctionalTests.TodoLists.Commands;
=======
﻿using Application.Todo.TodoLists.Commands.CreateTodoList;
using Application.Todo.TodoLists.Commands.DeleteTodoList;

namespace Toss.Inventory.Catalog.Application.FunctionalTests.TodoLists.Commands;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

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
