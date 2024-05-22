using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class GiftCardConfiguration : IEntityTypeConfiguration<GiftCard>
{
    public void Configure(EntityTypeBuilder<GiftCard> builder)
    {
        builder.ToTable("GiftCards");

        builder.HasKey(gc => gc.Id);

        builder.Property(gc => gc.IsGiftCard).IsRequired();
        builder.Property(gc => gc.GiftCardTypeId).IsRequired();
        builder.Property(gc => gc.OverriddenGiftCardAmount).HasColumnType("decimal(18,2)");
    }
}

