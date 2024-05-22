using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class PhysicalAttributesConfiguration : IEntityTypeConfiguration<PhysicalAttributes>
{
    public void Configure(EntityTypeBuilder<PhysicalAttributes> builder)
    {
        builder.ToTable("PhysicalAttributes");

        builder.HasKey("Id"); // shadow Identity

        builder.Property(pa => pa.Weight).HasColumnType("decimal(18,2)");
        builder.Property(pa => pa.Length).HasColumnType("decimal(18,2)");
        builder.Property(pa => pa.Width).HasColumnType("decimal(18,2)");
        builder.Property(pa => pa.Height).HasColumnType("decimal(18,2)");
        builder.Property(pa => pa.Color).HasMaxLength(100);
        builder.Property(pa => pa.Material).HasMaxLength(100);
        builder.Property(pa => pa.Size).HasMaxLength(50);
        builder.Property(pa => pa.PackagingType).HasMaxLength(100);
    }
}

