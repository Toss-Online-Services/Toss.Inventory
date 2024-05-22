using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class RentalProductConfiguration : IEntityTypeConfiguration<RentalProduct>
{
    public void Configure(EntityTypeBuilder<RentalProduct> builder)
    {
        builder.ToTable("RentalProducts");

        builder.HasKey(rp => rp.Id);

        builder.Property(rp => rp.IsRental).IsRequired();
        builder.Property(rp => rp.RentalPriceLength).IsRequired();
        builder.Property(rp => rp.RentalPricePeriodId).IsRequired();
    }
}
