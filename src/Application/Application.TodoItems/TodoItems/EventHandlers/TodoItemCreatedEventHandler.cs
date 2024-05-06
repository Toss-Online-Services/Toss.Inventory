using Microsoft.Extensions.Logging;
using Toss.Inventory.Catalog.Domain.Events;

namespace Application.Todo.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Toss.Inventory.Catalog Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
