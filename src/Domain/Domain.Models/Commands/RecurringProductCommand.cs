

namespace Domain.Models.Commands;
public record RecurringProductCommand
{
    public bool IsRecurring { get; init; }
    public int RecurringCycleLength { get; init; }
    public int RecurringCyclePeriodId { get; init; }
    public int RecurringTotalCycles { get; init; }
}

