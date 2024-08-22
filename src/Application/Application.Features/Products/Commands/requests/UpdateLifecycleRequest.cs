namespace Domain.Entities.Product;
public record UpdateLifecycleRequest : LifecycleCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateLifecycleRequest, UpdateLifecycleCommand>();
        }
    }

}

