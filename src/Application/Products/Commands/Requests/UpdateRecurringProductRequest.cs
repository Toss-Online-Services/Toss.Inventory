namespace Application.Products.Commands.Requests;
public record UpdateRecurringProductRequest : RecurringProductCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRecurringProductRequest, UpdateRecurringProductCommand>();
        }
    }
}

