namespace Application.Products.Commands.Requests;
public record UpdateTaxRequest : TaxCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateTaxRequest, UpdateTaxCommand>();
        }
    }

}
