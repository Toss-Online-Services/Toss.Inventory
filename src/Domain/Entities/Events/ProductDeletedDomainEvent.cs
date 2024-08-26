namespace Toss.Inventory.Domain.Entities.Events;
public record class ProductDeletedDomainEvent(Product product) : BaseEvent;
