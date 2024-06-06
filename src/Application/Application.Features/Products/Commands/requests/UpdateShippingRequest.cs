namespace Domain.Entities.Product.Commands;

public record UpdateShippingRequest() : IRequest<bool>
{
    public bool IsShipEnabled { get; init; }
    public bool IsFreeShipping { get; init; }
    public bool ShipSeparately { get; init; }
    public decimal AdditionalShippingCharge { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {            
            CreateMap<UpdateShippingRequest, UpdateShippingCommand>();
        }
    }
}

