using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Product;

namespace Infrastructure.Data.EntityConfigurations.ProductConfigurations;
public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventory");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.ManageInventoryMethodId).IsRequired();
        builder.Property(i => i.WarehouseId).IsRequired();
        builder.Property(i => i.StockQuantity).IsRequired();
        builder.Property(i => i.MinStockQuantity).IsRequired();
        builder.Property(i => i.LowStockActivityId).IsRequired();
        builder.Property(i => i.NotifyAdminForQuantityBelow).IsRequired();
        builder.Property(i => i.BackorderModeId).IsRequired();
        builder.Property(i => i.AllowBackInStockSubscriptions).IsRequired();
        builder.Property(i => i.OrderMinimumQuantity).IsRequired();
        builder.Property(i => i.OrderMaximumQuantity).IsRequired();
        builder.Property(i => i.AllowedQuantities);
        builder.Property(i => i.AllowAddingOnlyExistingAttributeCombinations).IsRequired();
        builder.Property(i => i.DisplayAttributeCombinationImagesOnly).IsRequired();
    }
}

