namespace Toss.Inventory.Domain.Entities.Events;

public record class ProductUpdatedDomainEvent(Product product) : BaseEvent;
