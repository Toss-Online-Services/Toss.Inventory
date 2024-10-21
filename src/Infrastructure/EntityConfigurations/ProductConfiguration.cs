using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

/// <summary>
/// Represents a product entity configuration
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.Property(p => p.Name)
            .HasMaxLength(400)
            .IsRequired();

        builder.Property(p => p.MetaKeywords)
            .HasMaxLength(400)
            .IsRequired(false);

        builder.Property(p => p.MetaTitle)
            .HasMaxLength(400)
            .IsRequired(false);

        builder.Property(p => p.Sku)
            .HasMaxLength(400)
            .IsRequired(false);

        builder.Property(p => p.ManufacturerPartNumber)
            .HasMaxLength(400)
            .IsRequired(false);

        builder.Property(p => p.Gtin)
            .HasMaxLength(400)
            .IsRequired(false);

        builder.Property(p => p.RequiredProductIds)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(p => p.AllowedQuantities)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(p => p.AvailableEndDateTimeUtc).IsRequired(false);
    }
}
