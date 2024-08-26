namespace Toss.Inventory.Domain.Entities.Events;
public record ProductRecurringProductUpdatedDomainEvent(Guid ProductId, RecurringProduct RecurringProduct) : BaseEvent;
