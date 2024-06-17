namespace Domain.Entities.Catalog.Events;
public record ProductRecurringProductUpdatedDomainEvent(Guid ProductId, RecurringProduct RecurringProduct) : BaseEvent;
