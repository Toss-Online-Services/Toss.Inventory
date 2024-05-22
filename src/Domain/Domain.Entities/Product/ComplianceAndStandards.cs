using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class ComplianceAndStandards : ValueObject
{
    public bool NotReturnable { get; set; }
    public string Certifications { get; set; }
    public string RegulatoryApprovals { get; set; }
    public string SafetyInformation { get; set; }
    public string EnvironmentalImpact { get; set; }
    public string RecyclingInformation { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return NotReturnable;
        yield return Certifications;
        yield return RegulatoryApprovals;
        yield return SafetyInformation;
        yield return EnvironmentalImpact;
        yield return RecyclingInformation;
    }
}

