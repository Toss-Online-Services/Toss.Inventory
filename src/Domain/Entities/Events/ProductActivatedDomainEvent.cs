namespace Toss.Inventory.Domain.Entities.Events;

public record ProductActivatedDomainEvent : BaseEvent
{
    public Product Product { get; }

    public ProductActivatedDomainEvent(Product product)
    {
        Product = product;
    }
}
