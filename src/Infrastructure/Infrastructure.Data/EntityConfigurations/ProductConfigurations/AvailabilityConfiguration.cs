using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
{
    public void Configure(EntityTypeBuilder<Availability> builder)
    {
        builder.ToTable("Availability");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.AvailableStartDateTimeUtc);
        builder.Property(a => a.AvailableEndDateTimeUtc);
        builder.Property(a => a.AvailableForPreOrder).IsRequired();
        builder.Property(a => a.PreOrderAvailabilityStartDateTimeUtc);
        builder.Property(a => a.ProductAvailabilityRangeId).IsRequired();
        builder.Property(a => a.DeliveryDateId).IsRequired();
    }
}

