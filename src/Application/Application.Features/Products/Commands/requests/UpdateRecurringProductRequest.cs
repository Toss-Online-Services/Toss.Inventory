namespace Domain.Entities.Product;
public record UpdateRecurringProductRequest : RecurringProductCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateRecurringProductRequest, UpdateRecurringProductCommand>();
        }
    }
}

