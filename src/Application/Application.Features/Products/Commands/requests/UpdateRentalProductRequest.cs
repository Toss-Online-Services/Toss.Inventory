namespace Domain.Entities.Product;
public record UpdateRentalProductRequest : RentalProductCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRentalProductRequest, UpdateRentalProductCommand>();
        }
    }
}
