namespace Domain.Entities.Product;
public record UpdateLifecycleRequest : IRequest<bool>
{
    public DateTime? ManufactureDate { get; init; }
    public DateTime? ExpirationDate { get; init; }
    public string BatchNumber { get; init; }
    public string SerialNumber { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateLifecycleRequest, UpdateLifecycleCommand>();
        }
    }

}

