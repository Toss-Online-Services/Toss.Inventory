namespace Toss.Inventory.Domain.Entities.Events;
public record class ProductUnpublishedDomainEvent(Product product) : BaseEvent;
