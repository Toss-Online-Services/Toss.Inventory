using Domain.ValueObjects;

namespace Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string Title { get; private set; }

    public Colour Colour { get; private set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
