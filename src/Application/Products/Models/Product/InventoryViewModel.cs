namespace Application.Products.Models.Product;
public record InventoryViewModel(int ManageInventoryMethodId, int WarehouseId, int StockQuantity, int MinStockQuantity, int LowStockActivityId, int NotifyAdminForQuantityBelow, int BackorderModeId, bool AllowBackInStockSubscriptions, int OrderMinimumQuantity, int OrderMaximumQuantity, string AllowedQuantities, bool AllowAddingOnlyExistingAttributeCombinations, bool DisplayAttributeCombinationImagesOnly, bool UseMultipleWarehouses, bool DisplayStockAvailability, bool DisplayStockQuantity)
{
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<InventoryViewModel, Inventory>().ReverseMap();
        }
    }
}
