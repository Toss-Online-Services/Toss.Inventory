namespace Application.Products.Commands.Requests;
public record UpdateComplianceAndStandardsRequest : ComplianceAndStandardsCommand, IRequest<bool>
{
    public int Id { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateComplianceAndStandardsRequest, UpdateComplianceAndStandardsCommand>();
        }
    }
}

