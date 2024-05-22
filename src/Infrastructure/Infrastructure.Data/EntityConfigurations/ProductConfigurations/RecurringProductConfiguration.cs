using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class RecurringProductConfiguration : IEntityTypeConfiguration<RecurringProduct>
{
    public void Configure(EntityTypeBuilder<RecurringProduct> builder)
    {
        builder.ToTable("RecurringProducts");

        builder.HasKey(rp => rp.Id);

        builder.Property(rp => rp.IsRecurring).IsRequired();
        builder.Property(rp => rp.RecurringCycleLength).IsRequired();
        builder.Property(rp => rp.RecurringCyclePeriodId).IsRequired();
        builder.Property(rp => rp.RecurringTotalCycles).IsRequired();
    }
}

