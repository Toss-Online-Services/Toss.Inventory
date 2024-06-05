using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class RecurringProduct : ValueObject
{
    public bool IsRecurring { get; private set; }
    public int RecurringCycleLength { get; private set; }
    public int RecurringCyclePeriodId { get; private set; }
    public int RecurringTotalCycles { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsRecurring;
        yield return RecurringCycleLength;
        yield return RecurringCyclePeriodId;
        yield return RecurringTotalCycles;
    }

    internal void Apply(UpdateRecurringProductCommand recurringProduct)
    {
        IsRecurring = recurringProduct.IsRecurring;
        RecurringCycleLength = recurringProduct.RecurringCycleLength;
        RecurringCyclePeriodId = recurringProduct.RecurringCyclePeriodId;
        RecurringTotalCycles = recurringProduct.RecurringTotalCycles;
    }
}

