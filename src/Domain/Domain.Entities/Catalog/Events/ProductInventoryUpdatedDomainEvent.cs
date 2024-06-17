namespace Domain.Entities.Catalog.Events;
public record ProductInventoryUpdatedDomainEvent(Guid ProductId, Inventory Inventory) : BaseEvent;
