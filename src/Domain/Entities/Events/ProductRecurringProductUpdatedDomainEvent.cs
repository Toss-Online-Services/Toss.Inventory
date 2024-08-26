namespace Domain.Entities.Events;
public record ProductRecurringProductUpdatedDomainEvent(Guid ProductId, RecurringProduct RecurringProduct) : BaseEvent;
