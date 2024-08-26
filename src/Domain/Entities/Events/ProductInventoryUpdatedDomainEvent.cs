namespace Toss.Inventory.Domain.Entities.Events;
public record ProductInventoryUpdatedDomainEvent(Guid ProductId, Inventory Inventory) : BaseEvent;
