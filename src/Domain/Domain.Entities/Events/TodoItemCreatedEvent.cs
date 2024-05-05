using Toss.Inventory.Catalog.Domain.Common;
using Toss.Inventory.Catalog.Domain.Entities;

namespace Toss.Inventory.Catalog.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
