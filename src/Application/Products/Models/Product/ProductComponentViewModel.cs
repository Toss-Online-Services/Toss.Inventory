using Domain.Entities;

namespace Application.Products.Models.Product;
public sealed record ProductComponentViewModel(ProductViewModel Component, decimal Quantity)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductComponentViewModel, ProductComponent>().ReverseMap();
        }
    }
}

