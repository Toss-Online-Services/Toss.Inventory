namespace Domain.Entities.Product.Commands;

public record UpdateAvailabilityRequest : AvailabilityCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateAvailabilityRequest, UpdateAvailabilityCommand>();
        }
    }

}
