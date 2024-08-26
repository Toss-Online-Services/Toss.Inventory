namespace Application.Products.Commands.Requests;

public record UpdateAvailabilityRequest : AvailabilityCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateAvailabilityRequest, UpdateAvailabilityCommand>();
        }
    }

}
