namespace Application.Products.Models.Product;
public record PriceViewModel(decimal CurrentPrice, decimal OldPrice, decimal ProductCost, bool CustomerEntersPrice, decimal MinimumCustomerEnteredPrice, decimal MaximumCustomerEnteredPrice, bool BasepriceEnabled, decimal BasepriceAmount, int BasepriceUnitId, decimal BasepriceBaseAmount, int BasepriceBaseUnitId, bool CallForPrice)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PriceViewModel, Price>().ReverseMap();
        }
    }
}
