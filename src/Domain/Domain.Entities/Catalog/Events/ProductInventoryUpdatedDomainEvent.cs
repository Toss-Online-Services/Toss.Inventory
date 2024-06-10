namespace Domain.Entities.Catalog.Events;
public record ProductInventoryUpdatedDomainEvent(string ProductId, Inventory Inventory) : BaseEvent;
