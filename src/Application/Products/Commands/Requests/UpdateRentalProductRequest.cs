namespace Application.Products.Commands.Requests;
public record UpdateRentalProductRequest : RentalProductCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRentalProductRequest, UpdateRentalProductCommand>();
        }
    }
}
