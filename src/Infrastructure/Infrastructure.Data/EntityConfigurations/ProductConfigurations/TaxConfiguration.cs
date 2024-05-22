using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class TaxConfiguration : IEntityTypeConfiguration<Tax>
{
    public void Configure(EntityTypeBuilder<Tax> builder)
    {
        builder.ToTable("Tax");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.IsTaxExempt).IsRequired();
        builder.Property(t => t.TaxCategoryId).IsRequired();
    }
}
