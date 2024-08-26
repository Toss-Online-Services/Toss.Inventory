namespace Domain.Entities.Product.Commands;
public record UpdateTaxRequest : TaxCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateTaxRequest, UpdateTaxCommand>();
        }
    }

}
