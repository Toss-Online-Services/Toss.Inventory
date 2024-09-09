namespace Application.Products.Models.Product;
public record RecurringProductViewModel(bool IsRecurring, int RecurringCycleLength, int RecurringCyclePeriodId, int RecurringTotalCycles){
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RecurringProductViewModel, RecurringProduct>().ReverseMap();
        }
    }
}

