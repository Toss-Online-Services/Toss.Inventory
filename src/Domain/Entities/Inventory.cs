namespace Domain.Entities;
public class Inventory : ValueObject
{
    public int ManageInventoryMethodId { get; private set; }
    public int WarehouseId { get; private set; }
    public int StockQuantity { get; private set; }
    public int MinStockQuantity { get; private set; }
    public int LowStockActivityId { get; private set; }
    public int NotifyAdminForQuantityBelow { get; private set; }
    public int BackorderModeId { get; private set; }
    public bool AllowBackInStockSubscriptions { get; private set; }
    public int OrderMinimumQuantity { get; private set; }
    public int OrderMaximumQuantity { get; private set; }
    public string AllowedQuantities { get; private set; }
    public bool AllowAddingOnlyExistingAttributeCombinations { get; private set; }
    public bool DisplayAttributeCombinationImagesOnly { get; private set; }
    public bool UseMultipleWarehouses { get; private set; }
    public bool DisplayStockAvailability { get; private set; }
    public bool DisplayStockQuantity { get; private set; }

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

    internal void Apply(UpdateInventoryCommand inventory)
    {
        ManageInventoryMethodId = inventory.ManageInventoryMethodId;
        WarehouseId = inventory.WarehouseId;
        StockQuantity = inventory.StockQuantity;
        MinStockQuantity = inventory.MinStockQuantity;
        LowStockActivityId = inventory.LowStockActivityId;
        NotifyAdminForQuantityBelow = inventory.NotifyAdminForQuantityBelow;
        BackorderModeId = inventory.BackorderModeId;
        AllowBackInStockSubscriptions = inventory.AllowBackInStockSubscriptions;
        OrderMinimumQuantity = inventory.OrderMinimumQuantity;
        OrderMaximumQuantity = inventory.OrderMaximumQuantity;
        AllowedQuantities = inventory.AllowedQuantities;
        AllowAddingOnlyExistingAttributeCombinations = inventory.AllowAddingOnlyExistingAttributeCombinations;
        DisplayAttributeCombinationImagesOnly = inventory.DisplayAttributeCombinationImagesOnly;

    }
}

