using Domain.Infrastructure;

namespace Domain.Entities.Product;
public class Inventory : ValueObject
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

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ManageInventoryMethodId;
        yield return WarehouseId;
        yield return StockQuantity;
        yield return MinStockQuantity;
        yield return LowStockActivityId;
        yield return NotifyAdminForQuantityBelow;
        yield return BackorderModeId;
        yield return AllowedQuantities;
        yield return AllowAddingOnlyExistingAttributeCombinations;
        yield return OrderMinimumQuantity;
        yield return OrderMaximumQuantity;
        yield return AllowedQuantities;
        yield return BackorderModeId;
        yield return AllowedQuantities;
        yield return AllowAddingOnlyExistingAttributeCombinations;
        yield return DisplayAttributeCombinationImagesOnly;

    }
}

