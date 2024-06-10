namespace Domain.Entities.Catalog.Events;
public record ProductRecurringProductUpdatedDomainEvent(string ProductId, RecurringProduct RecurringProduct) : BaseEvent;
