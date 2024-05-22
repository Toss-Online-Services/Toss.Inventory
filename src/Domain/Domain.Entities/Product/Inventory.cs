using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Inventory : Entity
{
    public int ManageInventoryMethodId { get; set; }
    public int WarehouseId { get; set; }
    public int StockQuantity { get; set; }
    public int MinStockQuantity { get; set; }
    public int LowStockActivityId { get; set; }
    public int NotifyAdminForQuantityBelow { get; set; }
    public int BackorderModeId { get; set; }
    public bool AllowBackInStockSubscriptions { get; set; }
    public int OrderMinimumQuantity { get; set; }
    public int OrderMaximumQuantity { get; set; }
    public string AllowedQuantities { get; set; }
    public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }
    public bool DisplayAttributeCombinationImagesOnly { get; set; }
}

