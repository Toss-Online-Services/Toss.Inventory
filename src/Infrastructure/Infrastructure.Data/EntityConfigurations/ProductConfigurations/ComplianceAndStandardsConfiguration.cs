using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class ComplianceAndStandardsConfiguration : IEntityTypeConfiguration<ComplianceAndStandards>
{
    public void Configure(EntityTypeBuilder<ComplianceAndStandards> builder)
    {
        builder.ToTable("ComplianceAndStandards");

        builder.HasKey(cs => cs.Id);

        builder.Property(cs => cs.NotReturnable).IsRequired();
        builder.Property(cs => cs.Certifications).HasMaxLength(400);
        builder.Property(cs => cs.RegulatoryApprovals).HasMaxLength(400);
        builder.Property(cs => cs.SafetyInformation).HasMaxLength(400);
        builder.Property(cs => cs.EnvironmentalImpact).HasMaxLength(400);
        builder.Property(cs => cs.RecyclingInformation).HasMaxLength(400);
    }
}

