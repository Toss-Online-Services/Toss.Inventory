using Domain.Entities.Product.Commands;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public record UpdateComplianceAndStandardsRequest : IRequest<bool>
{
    public bool NotReturnable { get; init; }
    public string Certifications { get; init; }
    public string RegulatoryApprovals { get; init; }
    public string SafetyInformation { get; init; }
    public string EnvironmentalImpact { get; init; }
    public string RecyclingInformation { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateComplianceAndStandardsRequest, UpdateComplianceAndStandardsCommand>();
        }
    }
}

