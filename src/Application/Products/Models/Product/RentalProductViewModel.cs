namespace Application.Products.Models.Product;
public record RentalProductViewModel(bool IsRental, int RentalPriceLength, int RentalPricePeriodId){
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RentalProductViewModel, RentalProduct>().ReverseMap();
        }
    }
}
