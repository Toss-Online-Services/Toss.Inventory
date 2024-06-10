namespace Domain.Entities.Catalog.Events;
public record ProductPriceUpdatedDomainEvent(string ProductId, Price Price) : BaseEvent;
