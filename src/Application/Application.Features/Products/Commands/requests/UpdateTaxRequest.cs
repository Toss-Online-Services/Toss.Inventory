namespace Domain.Entities.Product.Commands;
public record UpdateTaxRequest : IRequest<bool>
{
    public bool IsTaxExempt { get; init; }
    public int TaxCategoryId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateTaxRequest, UpdateTaxCommand>();
        }
    }

}
