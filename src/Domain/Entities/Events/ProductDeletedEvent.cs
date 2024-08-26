namespace Toss.Inventory.Domain.Entities.Events;

public record class ProductDeletedEvent(Product product) : BaseEvent;
