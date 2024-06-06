namespace Domain.Entities.Product;
public record UpdateComplianceAndStandardsRequest : ComplianceAndStandardsCommand, IRequest<bool>
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateComplianceAndStandardsRequest, UpdateComplianceAndStandardsCommand>();
        }
    }
}

