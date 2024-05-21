using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.Catalog;

namespace Infrastructure.Data.Configurations
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
            builder.Property(p => p.Name).IsRequired().HasMaxLength(256);
            builder.Property(p => p.ShortDescription).HasMaxLength(512);
            builder.Property(p => p.FullDescription).HasMaxLength(4000);
            builder.Property(p => p.AdminComment).HasMaxLength(4000);
            builder.Property(p => p.ProductTemplateId).IsRequired();
            builder.Property(p => p.VendorId).IsRequired();
            builder.Property(p => p.ShowOnHomepage).IsRequired();
            builder.Property(p => p.MetaKeywords).HasMaxLength(400);
            builder.Property(p => p.MetaDescription).HasMaxLength(400);
            builder.Property(p => p.MetaTitle).HasMaxLength(400);
            builder.Property(p => p.AllowCustomerReviews).IsRequired();
            builder.Property(p => p.ApprovedRatingSum).IsRequired();
            builder.Property(p => p.NotApprovedRatingSum).IsRequired();
            builder.Property(p => p.ApprovedTotalReviews).IsRequired();
            builder.Property(p => p.NotApprovedTotalReviews).IsRequired();
            builder.Property(p => p.SubjectToAcl).IsRequired();
            builder.Property(p => p.LimitedToStores).IsRequired();
            builder.Property(p => p.Sku).HasMaxLength(64);
            builder.Property(p => p.ManufacturerPartNumber).HasMaxLength(128);
            builder.Property(p => p.Gtin).HasMaxLength(64);
            builder.Property(p => p.IsGiftCard).IsRequired();
            builder.Property(p => p.GiftCardTypeId).IsRequired();
            builder.Property(p => p.OverriddenGiftCardAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.RequireOtherProducts).IsRequired();
            builder.Property(p => p.RequiredProductIds).HasMaxLength(1000);
            builder.Property(p => p.AutomaticallyAddRequiredProducts).IsRequired();
            builder.Property(p => p.IsDownload).IsRequired();
            builder.Property(p => p.DownloadId).IsRequired();
            builder.Property(p => p.UnlimitedDownloads).IsRequired();
            builder.Property(p => p.MaxNumberOfDownloads).IsRequired();
            builder.Property(p => p.DownloadExpirationDays).IsRequired();
            builder.Property(p => p.DownloadActivationTypeId).IsRequired();
            builder.Property(p => p.HasSampleDownload).IsRequired();
            builder.Property(p => p.SampleDownloadId).IsRequired();
            builder.Property(p => p.HasUserAgreement).IsRequired();
            builder.Property(p => p.UserAgreementText).HasMaxLength(4000);
            builder.Property(p => p.IsRecurring).IsRequired();
            builder.Property(p => p.RecurringCycleLength).IsRequired();
            builder.Property(p => p.RecurringCyclePeriodId).IsRequired();
            builder.Property(p => p.RecurringTotalCycles).IsRequired();
            builder.Property(p => p.IsRental).IsRequired();
            builder.Property(p => p.RentalPriceLength).IsRequired();
            builder.Property(p => p.RentalPricePeriodId).IsRequired();
            builder.Property(p => p.IsShipEnabled).IsRequired();
            builder.Property(p => p.IsFreeShipping).IsRequired();
            builder.Property(p => p.ShipSeparately).IsRequired();
            builder.Property(p => p.AdditionalShippingCharge).HasColumnType("decimal(18,2)");
            builder.Property(p => p.DeliveryDateId).IsRequired();
            builder.Property(p => p.IsTaxExempt).IsRequired();
            builder.Property(p => p.TaxCategoryId).IsRequired();
            builder.Property(p => p.ManageInventoryMethodId).IsRequired();
            builder.Property(p => p.ProductAvailabilityRangeId).IsRequired();
            builder.Property(p => p.UseMultipleWarehouses).IsRequired();
            builder.Property(p => p.WarehouseId).IsRequired();
            builder.Property(p => p.StockQuantity).IsRequired();
            builder.Property(p => p.DisplayStockAvailability).IsRequired();
            builder.Property(p => p.DisplayStockQuantity).IsRequired();
            builder.Property(p => p.MinStockQuantity).IsRequired();
            builder.Property(p => p.LowStockActivityId).IsRequired();
            builder.Property(p => p.NotifyAdminForQuantityBelow).IsRequired();
            builder.Property(p => p.BackorderModeId).IsRequired();
            builder.Property(p => p.AllowBackInStockSubscriptions).IsRequired();
            builder.Property(p => p.OrderMinimumQuantity).IsRequired();
            builder.Property(p => p.OrderMaximumQuantity).IsRequired();
            builder.Property(p => p.AllowedQuantities).HasMaxLength(1000);
            builder.Property(p => p.AllowAddingOnlyExistingAttributeCombinations).IsRequired();
            builder.Property(p => p.DisplayAttributeCombinationImagesOnly).IsRequired();
            builder.Property(p => p.NotReturnable).IsRequired();
            builder.Property(p => p.DisableBuyButton).IsRequired();
            builder.Property(p => p.DisableWishlistButton).IsRequired();
            builder.Property(p => p.AvailableForPreOrder).IsRequired();
            builder.Property(p => p.PreOrderAvailabilityStartDateTimeUtc).IsRequired(false);
            builder.Property(p => p.CallForPrice).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.OldPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.ProductCost).HasColumnType("decimal(18,2)");
            builder.Property(p => p.CustomerEntersPrice).IsRequired();
            builder.Property(p => p.MinimumCustomerEnteredPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MaximumCustomerEnteredPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.BasepriceEnabled).IsRequired();
            builder.Property(p => p.BasepriceAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.BasepriceUnitId).IsRequired();
            builder.Property(p => p.BasepriceBaseAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.BasepriceBaseUnitId).IsRequired();
            builder.Property(p => p.MarkAsNew).IsRequired();
            builder.Property(p => p.MarkAsNewStartDateTimeUtc).IsRequired(false);
            builder.Property(p => p.MarkAsNewEndDateTimeUtc).IsRequired(false);
            builder.Property(p => p.HasTierPrices).IsRequired();
            builder.Property(p => p.HasDiscountsApplied).IsRequired();
            builder.Property(p => p.Weight).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Length).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Width).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Height).HasColumnType("decimal(18,2)");
            builder.Property(p => p.AvailableStartDateTimeUtc).IsRequired(false);
            builder.Property(p => p.AvailableEndDateTimeUtc).IsRequired(false);
            builder.Property(p => p.DisplayOrder).IsRequired();
            builder.Property(p => p.Published).IsRequired();
            builder.Property(p => p.Deleted).IsRequired();
            builder.Property(p => p.CreatedOnUtc).IsRequired();
            builder.Property(p => p.UpdatedOnUtc).IsRequired();

            builder.HasMany(p => p.Pictures)
                .WithOne()
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Discounts)
                .WithOne()
                .HasForeignKey(dp => dp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(p => p.DomainEvents);
        }
    }
}
