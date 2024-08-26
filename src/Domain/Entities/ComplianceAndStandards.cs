namespace Toss.Inventory.Domain.Entities;
public class ComplianceAndStandards : ValueObject
{
    public bool NotReturnable { get; private set; }
    public string Certifications { get; private set; }
    public string RegulatoryApprovals { get; private set; }
    public string SafetyInformation { get; private set; }
    public string EnvironmentalImpact { get; private set; }
    public string RecyclingInformation { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return NotReturnable;
        yield return Certifications;
        yield return RegulatoryApprovals;
        yield return SafetyInformation;
        yield return EnvironmentalImpact;
        yield return RecyclingInformation;
    }

    internal void Apply(UpdateComplianceAndStandardsCommand complianceAndStandards)
    {
        NotReturnable = complianceAndStandards.NotReturnable;
        Certifications = complianceAndStandards.Certifications;
        RegulatoryApprovals = complianceAndStandards.RegulatoryApprovals;
        SafetyInformation = complianceAndStandards.SafetyInformation;
        EnvironmentalImpact = complianceAndStandards.EnvironmentalImpact;
        RecyclingInformation = complianceAndStandards.RecyclingInformation;
    }
}

