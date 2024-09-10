namespace Application.Products.Commands.Requests;

public record UpdateShippingRequest : ShippingCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateShippingRequest, UpdateShippingCommand>();
        }
    }
}
