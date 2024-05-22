using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class DownloadableProductConfiguration : IEntityTypeConfiguration<DownloadableProduct>
{
    public void Configure(EntityTypeBuilder<DownloadableProduct> builder)
    {
        builder.ToTable("DownloadableProducts");

        builder.HasKey(dp => dp.Id);

        builder.Property(dp => dp.IsDownload).IsRequired();
        builder.Property(dp => dp.DownloadId).IsRequired();
        builder.Property(dp => dp.UnlimitedDownloads).IsRequired();
        builder.Property(dp => dp.MaxNumberOfDownloads).IsRequired();
        builder.Property(dp => dp.DownloadExpirationDays);
        builder.Property(dp => dp.DownloadActivationTypeId).IsRequired();
        builder.Property(dp => dp.HasSampleDownload).IsRequired();
        builder.Property(dp => dp.SampleDownloadId).IsRequired();
        builder.Property(dp => dp.HasUserAgreement).IsRequired();
        builder.Property(dp => dp.UserAgreementText).HasMaxLength(1000);
    }
}
