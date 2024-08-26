namespace Application.Products.Commands.Requests;
public record UpdateLifecycleRequest : LifecycleCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateLifecycleRequest, UpdateLifecycleCommand>();
        }
    }

}

