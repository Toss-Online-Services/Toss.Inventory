namespace Application.Products.Commands.Requests;
public record UpdatePhysicalAttributesRequest : PhysicalAttributesCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdatePhysicalAttributesRequest, UpdatePhysicalAttributesCommand>();
        }
    }
}

