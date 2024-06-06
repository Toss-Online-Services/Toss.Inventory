using Domain.Infrastructure;

namespace Domain.Entities.Product;
public record UpdateRecurringProductRequest : IRequest<bool>
{
    public bool IsRecurring { get; init; }
    public int RecurringCycleLength { get; init; }
    public int RecurringCyclePeriodId { get; init; }
    public int RecurringTotalCycles { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRecurringProductRequest, UpdateRecurringProductCommand>();
        }
    }
}

