namespace Application.Products.Models.Product;
public record AvailabilityViewModel(DateTime? AvailableStartDateTimeUtc, DateTime? AvailableEndDateTimeUtc, bool AvailableForPreOrder, DateTime? PreOrderAvailabilityStartDateTimeUtc, int ProductAvailabilityRangeId, int DeliveryDateId)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AvailabilityViewModel, Availability>().ReverseMap();
        }
    }
}
