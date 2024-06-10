using Domain.Entities.Catalog.Events;
using Domain.Enums;

namespace Domain.Entities;

public class TodoItem : BaseAuditableEntity
{
    public int ListId { get; private set; }

    public string Title { get; private set; }

    public string Note { get; private set; }

    public PriorityLevel Priority { get; private set; }

    public DateTime? Reminder { get; private set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new TodoItemCompletedEvent(this));
            }

            _done = value;
        }
    }

    public TodoList List { get; private set; } = null!;
}
