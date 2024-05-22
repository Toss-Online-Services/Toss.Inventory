using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class LifecycleConfiguration : IEntityTypeConfiguration<Lifecycle>
{
    public void Configure(EntityTypeBuilder<Lifecycle> builder)
    {
        builder.ToTable("Lifecycle");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.ManufactureDate);
        builder.Property(l => l.ExpirationDate);
        builder.Property(l => l.BatchNumber).HasMaxLength(100);
        builder.Property(l => l.SerialNumber).HasMaxLength(100);
    }
}

