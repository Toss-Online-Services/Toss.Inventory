using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
{
    public void Configure(EntityTypeBuilder<Shipping> builder)
    {
        builder.ToTable("Shipping");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.IsShipEnabled).IsRequired();
        builder.Property(s => s.IsFreeShipping).IsRequired();
        builder.Property(s => s.ShipSeparately).IsRequired();
        builder.Property(s => s.AdditionalShippingCharge).IsRequired().HasColumnType("decimal(18,2)");
    }
}
