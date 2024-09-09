namespace Application.Products.Models.Product;
public record ShippingViewModel(bool IsShipEnabled, bool IsFreeShipping, bool ShipSeparately, decimal AdditionalShippingCharge)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ShippingViewModel, Shipping>().ReverseMap();
        }
    }
}
