using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class PriceConfiguration : IEntityTypeConfiguration<Price>
{
    public void Configure(EntityTypeBuilder<Price> builder)
    {
        builder.ToTable("Prices");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.CurrentPrice).IsRequired().HasColumnType("decimal(18,2)");
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
        builder.Property(p => p.CallForPrice).IsRequired();
    }
}

