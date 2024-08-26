namespace Domain.Entities.Product;
public record UpdatePhysicalAttributesRequest : PhysicalAttributesCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdatePhysicalAttributesRequest, UpdatePhysicalAttributesCommand>();
        }
    }
}

