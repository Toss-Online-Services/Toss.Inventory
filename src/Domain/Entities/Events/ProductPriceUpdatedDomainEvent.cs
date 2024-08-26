namespace Toss.Inventory.Domain.Entities.Events;
public record ProductPriceUpdatedDomainEvent(Guid ProductId, Price Price) : BaseEvent;
