namespace Application.Products.Models.Product;
public record TaxViewModel(bool IsTaxExempt, int TaxCategoryId)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TaxViewModel, Tax>().ReverseMap();
        }
    }
}
