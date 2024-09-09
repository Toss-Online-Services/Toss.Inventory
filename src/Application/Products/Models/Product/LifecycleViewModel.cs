namespace Application.Products.Models.Product;
public record LifecycleViewModel(DateTime? ManufactureDate, DateTime? ExpirationDate, string BatchNumber, string SerialNumber)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<LifecycleViewModel, Lifecycle>().ReverseMap();
        }
    }
}
