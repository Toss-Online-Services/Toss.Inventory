<<<<<<< HEAD
﻿using Toss.Inventory.Application.Common.Models;
using Toss.Inventory.Application.TodoItems.Commands.CreateTodoItem;
using Toss.Inventory.Application.TodoItems.Commands.DeleteTodoItem;
using Toss.Inventory.Application.TodoItems.Commands.UpdateTodoItem;
using Toss.Inventory.Application.TodoItems.Commands.UpdateTodoItemDetail;
using Toss.Inventory.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Toss.Inventory.Web.Endpoints;
=======
﻿using Application.Common.Models;
using Application.Todo.TodoItems.Commands.CreateTodoItem;
using Application.Todo.TodoItems.Commands.DeleteTodoItem;
using Application.Todo.TodoItems.Commands.UpdateTodoItem;
using Application.Todo.TodoItems.Commands.UpdateTodoItemDetail;
using Application.Todo.TodoItems.Queries.GetTodoItemsWithPagination;

namespace Toss.Inventory.Catalog.Web.Endpoints;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public class TodoItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoItemsWithPagination)
            .MapPost(CreateTodoItem)
            .MapPut(UpdateTodoItem, "{id}")
            .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
            .MapDelete(DeleteTodoItem, "{id}");
    }

    public Task<PaginatedList<TodoItemBriefDto>> GetTodoItemsWithPagination(ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateTodoItem(ISender sender, int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoItem(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoItemCommand(id));
        return Results.NoContent();
    }
}
