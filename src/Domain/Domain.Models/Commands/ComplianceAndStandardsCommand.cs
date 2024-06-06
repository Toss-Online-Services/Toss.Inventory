

namespace Domain.Models.Commands;
public record ComplianceAndStandardsCommand
{
    public bool NotReturnable { get; init; }
    public string Certifications { get; init; }
    public string RegulatoryApprovals { get; init; }
    public string SafetyInformation { get; init; }
    public string EnvironmentalImpact { get; init; }
    public string RecyclingInformation { get; init; }
}

