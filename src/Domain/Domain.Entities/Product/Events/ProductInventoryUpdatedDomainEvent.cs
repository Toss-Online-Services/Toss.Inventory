namespace Domain.Entities.Product.Events;
public record ProductInventoryUpdatedDomainEvent(string ProductId, Inventory Inventory) : BaseEvent;
