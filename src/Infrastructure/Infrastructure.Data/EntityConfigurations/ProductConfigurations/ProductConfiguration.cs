using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProductTypeId).IsRequired();
            builder.Property(p => p.ParentGroupedProductId).IsRequired();
            builder.Property(p => p.VisibleIndividually).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(400);

            // Additional properties
            builder.Property(p => p.ShortDescription).HasMaxLength(1000);
            builder.Property(p => p.FullDescription);
            builder.Property(p => p.AdminComment).HasMaxLength(1000);
            builder.Property(p => p.MetaKeywords).HasMaxLength(400);
            builder.Property(p => p.MetaDescription).HasMaxLength(400);
            builder.Property(p => p.MetaTitle).HasMaxLength(400);

            // Define one-to-one or one-to-many relationships if any
            builder.OwnsOne(p => p.Price);
            builder.OwnsOne(p => p.Availability);
            builder.OwnsOne(p => p.Inventory);
            builder.OwnsOne(p => p.Shipping);
            builder.OwnsOne(p => p.Tax);
            builder.OwnsOne(p => p.DownloadableProduct);
            builder.OwnsOne(p => p.GiftCard);
            builder.OwnsOne(p => p.RecurringProduct);
            builder.OwnsOne(p => p.RentalProduct);
            builder.OwnsOne(p => p.PhysicalAttributes);
            builder.OwnsOne(p => p.ComplianceAndStandards);
            builder.OwnsOne(p => p.Lifecycle);

            builder.Property(p => p.DisplayOrder).IsRequired();
            builder.Property(p => p.Published).IsRequired();
            builder.Property(p => p.Deleted).IsRequired();
            builder.Property(p => p.CreatedOnUtc).IsRequired();
            builder.Property(p => p.UpdatedOnUtc).IsRequired();
        }
    }

}
