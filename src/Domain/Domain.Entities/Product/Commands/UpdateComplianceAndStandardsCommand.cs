namespace Domain.Entities.Product;
public record UpdateComplianceAndStandardsCommand : ICommand<bool>
{
    public bool NotReturnable { get; init; }
    public string Certifications { get; init; }
    public string RegulatoryApprovals { get; init; }
    public string SafetyInformation { get; init; }
    public string EnvironmentalImpact { get; init; }
    public string RecyclingInformation { get; init; }
}

