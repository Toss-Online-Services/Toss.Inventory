namespace Application.Products.Commands.Requests;

public record UpdatePriceRequest : PriceCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdatePriceRequest, UpdatePriceCommand>();
        }
    }
}
