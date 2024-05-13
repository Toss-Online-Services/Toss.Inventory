using Domain.Entities.Catalog;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Set the table name and schema if different from defaults
        builder.ToTable("Products");

        // Set the primary key
        builder.HasKey(p => p.Id);

        // Set properties configurations
        builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
        builder.Property(p => p.ShortDescription).HasMaxLength(500);
        builder.Property(p => p.FullDescription).HasColumnType("text");
        builder.Property(p => p.MetaTitle).HasMaxLength(255);
        builder.Property(p => p.MetaDescription).HasMaxLength(512);
        builder.Property(p => p.MetaKeywords).HasMaxLength(512);
        builder.Property(p => p.Sku).HasMaxLength(50);
        builder.Property(p => p.Gtin).HasMaxLength(50);
        builder.Property(p => p.ManufacturerPartNumber).HasMaxLength(50);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.OldPrice).HasColumnType("decimal(18,2)");
        builder.Property(p => p.ProductCost).HasColumnType("decimal(18,2)");
        builder.Property(p => p.MinimumCustomerEnteredPrice).HasColumnType("decimal(18,2)");
        builder.Property(p => p.MaximumCustomerEnteredPrice).HasColumnType("decimal(18,2)");
        builder.Property(p => p.BasepriceAmount).HasColumnType("decimal(18,2)");
        builder.Property(p => p.BasepriceBaseAmount).HasColumnType("decimal(18,2)");

        // Configure relationships and navigation properties
        builder.HasMany(p => p.Discounts)
               .WithOne() // Assuming there is a navigation property in the DiscountProductMapping pointing back to Product
               .HasForeignKey(d => d.EntityId)
               .IsRequired();

        builder.HasMany(p => p.Pictures)
               .WithOne() // Assuming there is a navigation property in the ProductPicture pointing back to Product
               .HasForeignKey(p => p.ProductId)
               .IsRequired();

        // Indexes for commonly queried fields
        builder.HasIndex(p => p.Sku).IsUnique();
        builder.HasIndex(p => p.Gtin).IsUnique();
        builder.HasIndex(p => p.Published);
        builder.HasIndex(p => p.Deleted);
        builder.HasIndex(p => p.CreatedOnUtc);
        builder.HasIndex(p => p.UpdatedOnUtc);

        // Optional: Configure soft delete filter if used
        builder.HasQueryFilter(p => !p.Deleted);
    }
}
