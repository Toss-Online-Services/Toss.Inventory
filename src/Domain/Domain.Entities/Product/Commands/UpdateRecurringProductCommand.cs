using Domain.Infrastructure;

namespace Domain.Entities.Product;
public record UpdateRecurringProductCommand : ICommand<bool>
{
    public bool IsRecurring { get; init; }
    public int RecurringCycleLength { get; init; }
    public int RecurringCyclePeriodId { get; init; }
    public int RecurringTotalCycles { get; init; }
}

