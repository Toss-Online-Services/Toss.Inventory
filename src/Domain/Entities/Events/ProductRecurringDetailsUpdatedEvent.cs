namespace Toss.Inventory.Domain.Entities.Events;
using Catalog;
using Toss.Inventory.Domain.Entities;

public record ProductRecurringDetailsUpdatedEvent(Product Product, int OldCycleLength, int NewCycleLength, int OldCyclePeriodId, int NewCyclePeriodId, int OldTotalCycles, int NewTotalCycles) : BaseEvent;
