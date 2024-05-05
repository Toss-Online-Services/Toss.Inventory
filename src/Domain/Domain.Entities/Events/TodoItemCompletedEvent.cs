using Toss.Inventory.Catalog.Domain.Common;
using Toss.Inventory.Catalog.Domain.Entities;

namespace Toss.Inventory.Catalog.Domain.Events;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
