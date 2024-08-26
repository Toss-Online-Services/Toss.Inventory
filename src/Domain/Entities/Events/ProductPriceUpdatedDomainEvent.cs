namespace Domain.Entities.Events;
public record ProductPriceUpdatedDomainEvent(Guid ProductId, Price Price) : BaseEvent;
