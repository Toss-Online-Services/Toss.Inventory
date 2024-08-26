<<<<<<< HEAD
﻿using Toss.Inventory.Application.TodoItems.Commands.CreateTodoItem;
using Toss.Inventory.Application.TodoItems.Commands.DeleteTodoItem;
using Toss.Inventory.Application.TodoLists.Commands.CreateTodoList;
using Toss.Inventory.Domain.Entities;

namespace Toss.Inventory.Application.FunctionalTests.TodoItems.Commands;
=======
﻿using Application.Todo.TodoItems.Commands.CreateTodoItem;
using Application.Todo.TodoItems.Commands.DeleteTodoItem;
using Application.Todo.TodoLists.Commands.CreateTodoList;

namespace Toss.Inventory.Catalog.Application.FunctionalTests.TodoItems.Commands;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
