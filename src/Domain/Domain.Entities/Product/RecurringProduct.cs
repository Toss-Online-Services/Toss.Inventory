using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class RecurringProduct : ValueObject
{
    public bool IsRecurring { get; set; }
    public int RecurringCycleLength { get; set; }
    public int RecurringCyclePeriodId { get; set; }
    public int RecurringTotalCycles { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsRecurring;
        yield return RecurringCycleLength;
        yield return RecurringCyclePeriodId;
        yield return RecurringTotalCycles;
    }
}

