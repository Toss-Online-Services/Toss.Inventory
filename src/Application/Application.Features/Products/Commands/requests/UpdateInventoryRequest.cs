namespace Domain.Entities.Product.Commands;
public record UpdateInventoryRequest(string ProductId, int Quantity) : IRequest<bool>
{
    public int ManageInventoryMethodId { get; init; }
    public int WarehouseId { get; init; }
    public int StockQuantity { get; init; }
    public int MinStockQuantity { get; init; }
    public int LowStockActivityId { get; init; }
    public int NotifyAdminForQuantityBelow { get; init; }
    public int BackorderModeId { get; init; }
    public bool AllowBackInStockSubscriptions { get; init; }
    public int OrderMinimumQuantity { get; init; }
    public int OrderMaximumQuantity { get; init; }
    public string AllowedQuantities { get; init; }
    public bool AllowAddingOnlyExistingAttributeCombinations { get; init; }
    public bool DisplayAttributeCombinationImagesOnly { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UpdateInventoryRequest, UpdateInventoryCommand>();
        }
    }
}


