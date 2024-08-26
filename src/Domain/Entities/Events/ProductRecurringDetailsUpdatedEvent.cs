namespace Domain.Entities.Events;
public record ProductRecurringDetailsUpdatedEvent(Product Product, int OldCycleLength, int NewCycleLength, int OldCyclePeriodId, int NewCyclePeriodId, int OldTotalCycles, int NewTotalCycles) : BaseEvent;
