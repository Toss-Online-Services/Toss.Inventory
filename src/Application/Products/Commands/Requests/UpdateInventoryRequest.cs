namespace Application.Products.Commands.Requests;
public record UpdateInventoryRequest : InventoryCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateInventoryRequest, UpdateInventoryCommand>();
        }
    }
}


