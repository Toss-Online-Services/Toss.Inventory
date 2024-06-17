namespace Domain.Entities.Catalog.Events;
public record ProductPriceUpdatedDomainEvent(Guid ProductId, Price Price) : BaseEvent;
