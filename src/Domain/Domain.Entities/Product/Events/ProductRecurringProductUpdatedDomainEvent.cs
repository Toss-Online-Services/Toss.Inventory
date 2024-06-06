namespace Domain.Entities.Product.Events;
public record ProductRecurringProductUpdatedDomainEvent(string ProductId, RecurringProduct RecurringProduct) : BaseEvent;
