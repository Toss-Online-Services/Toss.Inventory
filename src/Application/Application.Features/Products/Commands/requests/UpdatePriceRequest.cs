namespace Domain.Entities.Product.Commands;

public record UpdatePriceRequest : PriceCommand, IRequest<bool>
{
    
    private class Mapping : Profile
    {
        public Mapping()
        {           
            CreateMap<UpdatePriceRequest, UpdatePriceCommand>();
        }
    }
}
