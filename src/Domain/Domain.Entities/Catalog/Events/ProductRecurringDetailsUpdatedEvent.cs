namespace Domain.Entities.Catalog.Events;
using Catalog;
public record ProductRecurringDetailsUpdatedEvent(Product Product, int OldCycleLength, int NewCycleLength, int OldCyclePeriodId, int NewCyclePeriodId, int OldTotalCycles, int NewTotalCycles) : BaseEvent;
