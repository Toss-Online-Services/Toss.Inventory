<<<<<<< HEAD
﻿using Toss.Inventory.Application.TodoLists.Commands.CreateTodoList;
using Toss.Inventory.Application.TodoLists.Commands.DeleteTodoList;
using Toss.Inventory.Application.TodoLists.Commands.UpdateTodoList;
using Toss.Inventory.Application.TodoLists.Queries.GetTodos;

namespace Toss.Inventory.Web.Endpoints;
=======
﻿using Application.Todo.TodoLists.Queries.GetTodos;
using Application.Todo.TodoLists.Commands.CreateTodoList;
using Application.Todo.TodoLists.Commands.UpdateTodoList;
using Application.Todo.TodoLists.Commands.DeleteTodoList;

namespace Toss.Inventory.Catalog.Web.Endpoints;
>>>>>>> ae4375be3f8c93235bf3c45247357d065e2ac0e1

public class TodoLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoLists)
            .MapPost(CreateTodoList)
            .MapPut(UpdateTodoList, "{id}")
            .MapDelete(DeleteTodoList, "{id}");
    }

    public Task<TodosVm> GetTodoLists(ISender sender)
    {
        return  sender.Send(new GetTodosQuery());
    }

    public Task<int> CreateTodoList(ISender sender, CreateTodoListCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateTodoList(ISender sender, int id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoList(ISender sender, int id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }
}
