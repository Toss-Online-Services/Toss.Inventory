using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Ignore(b => b.DomainEvents);

            builder.Property(p => p.Id).UseHiLo("productseq"); ;

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

            // Map owned entities to separate tables
            builder.OwnsOne(p => p.Price, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductPrices");
            });

            builder.OwnsOne(p => p.Availability, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductAvailabilities");
            });

            builder.OwnsOne(p => p.Inventory, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductInventories");
            });

            builder.OwnsOne(p => p.Shipping, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductShippings");
            });

            builder.OwnsOne(p => p.Tax, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductTaxes");
            });

            builder.OwnsOne(p => p.DownloadableProduct, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductDownloadables");
            });

            builder.OwnsOne(p => p.GiftCard, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductGiftCards");
            });

            builder.OwnsOne(p => p.RecurringProduct, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductRecurrings");
            });

            builder.OwnsOne(p => p.RentalProduct, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductRentals");
            });

            builder.OwnsOne(p => p.PhysicalAttributes, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductPhysicalAttributes");
            });

            builder.OwnsOne(p => p.ComplianceAndStandards, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductCompliances");
            });

            builder.OwnsOne(p => p.Lifecycle, navigationBuilder =>
            {
                navigationBuilder.ToTable("ProductLifecycles");
            });

            builder.Property(p => p.DisplayOrder).IsRequired();
            builder.Property(p => p.Published).IsRequired();
            builder.Property(p => p.Deleted).IsRequired();
            builder.Property(p => p.Created).IsRequired();
            builder.Property(p => p.LastModified).IsRequired();
        }
    }
}
