namespace Application.Products.Models.Product;
public record RecurringProductViewModel(bool IsRecurring, int RecurringCycleLength, int RecurringCyclePeriodId, int RecurringTotalCycles);

