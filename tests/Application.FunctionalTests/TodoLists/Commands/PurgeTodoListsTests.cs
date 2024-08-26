<<<<<<< HEAD
﻿using Toss.Inventory.Application.Common.Exceptions;
using Toss.Inventory.Application.Common.Security;
using Toss.Inventory.Application.TodoLists.Commands.CreateTodoList;
using Toss.Inventory.Application.TodoLists.Commands.PurgeTodoLists;
using Toss.Inventory.Domain.Entities;

namespace Toss.Inventory.Application.FunctionalTests.TodoLists.Commands;
=======
﻿using Application.Common.Exceptions;
using Application.Common.Security;
using Application.Todo.TodoLists.Commands.CreateTodoList;
using Application.Todo.TodoLists.Commands.PurgeTodoLists;

namespace Toss.Inventory.Catalog.Application.FunctionalTests.TodoLists.Commands;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

using static Testing;

public class PurgeTodoListsTests : BaseTestFixture
{
    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var command = new PurgeTodoListsCommand();

        command.GetType().Should().BeDecoratedWith<AuthorizeAttribute>();

        var action = () => SendAsync(command);

        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }

    [Test]
    public async Task ShouldDenyNonAdministrator()
    {
        await RunAsDefaultUserAsync();

        var command = new PurgeTodoListsCommand();

        var action = () => SendAsync(command);

        await action.Should().ThrowAsync<ForbiddenAccessException>();
    }

    [Test]
    public async Task ShouldAllowAdministrator()
    {
        await RunAsAdministratorAsync();

        var command = new PurgeTodoListsCommand();

        var action = () => SendAsync(command);

        await action.Should().NotThrowAsync<ForbiddenAccessException>();
    }

    [Test]
    public async Task ShouldDeleteAllLists()
    {
        await RunAsAdministratorAsync();

        await SendAsync(new CreateTodoListCommand
        {
            Title = "New List #1"
        });

        await SendAsync(new CreateTodoListCommand
        {
            Title = "New List #2"
        });

        await SendAsync(new CreateTodoListCommand
        {
            Title = "New List #3"
        });

        await SendAsync(new PurgeTodoListsCommand());

        var count = await CountAsync<TodoList>();

        count.Should().Be(0);
    }
}
