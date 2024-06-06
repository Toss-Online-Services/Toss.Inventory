namespace Domain.Entities.Product.Commands;

public record UpdateShippingRequest : ShippingCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {            
            CreateMap<UpdateShippingRequest, UpdateShippingCommand>();
        }
    }
}

