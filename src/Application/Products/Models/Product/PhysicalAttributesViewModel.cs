namespace Application.Products.Models.Product;
public record PhysicalAttributesViewModel(decimal Weight, decimal Length, decimal Width, decimal Height, string Color, string Material, string Size, string PackagingType)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PhysicalAttributesViewModel, PhysicalAttributes>().ReverseMap();
        }
    }
}

