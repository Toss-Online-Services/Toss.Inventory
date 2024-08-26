namespace Toss.Inventory.Domain.Entities.Events;
public record class ProductPublishedDomainEvent(Product product) : BaseEvent;
