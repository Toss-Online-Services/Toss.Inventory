<<<<<<< HEAD
﻿using Toss.Inventory.Application.TodoLists.Queries.GetTodos;
using Toss.Inventory.Domain.Entities;
using Toss.Inventory.Domain.ValueObjects;

namespace Toss.Inventory.Application.FunctionalTests.TodoLists.Queries;
=======
﻿using Application.Todo.TodoLists.Queries.GetTodos;
using Domain.ValueObjects;

namespace Toss.Inventory.Catalog.Application.FunctionalTests.TodoLists.Queries;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

using static Testing;

public class GetTodosTests : BaseTestFixture
{
    [Test]
    public async Task ShouldReturnPriorityLevels()
    {
        await RunAsDefaultUserAsync();

        var query = new GetTodosQuery();

        var result = await SendAsync(query);

        result.PriorityLevels.Should().NotBeEmpty();
    }

    [Test]
    public async Task ShouldReturnAllListsAndItems()
    {
        await RunAsDefaultUserAsync();

        await AddAsync(new TodoList
        {
            Title = "Shopping",
            Colour = Colour.Blue,
            Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" }
                    }
        });

        var query = new GetTodosQuery();

        var result = await SendAsync(query);

        result.Lists.Should().HaveCount(1);
        result.Lists.First().Items.Should().HaveCount(7);
    }

    [Test]
    public async Task ShouldDenyAnonymousUser()
    {
        var query = new GetTodosQuery();

        var action = () => SendAsync(query);
        
        await action.Should().ThrowAsync<UnauthorizedAccessException>();
    }
}
