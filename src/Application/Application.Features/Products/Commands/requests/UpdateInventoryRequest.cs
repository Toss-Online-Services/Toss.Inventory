namespace Domain.Entities.Product.Commands;
public record UpdateInventoryRequest : InventoryCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateInventoryRequest, UpdateInventoryCommand>();
        }
    }
}


