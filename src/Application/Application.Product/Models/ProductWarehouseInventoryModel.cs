namespace Application.Product.Models;
public record ProductWarehouseInventoryModel
{
    #region Properties

    public int WarehouseId { get; set; }

    public string WarehouseName { get; set; }

    public bool WarehouseUsed { get; set; }

    public int StockQuantity { get; set; }

    public int ReservedQuantity { get; set; }

    public int PlannedQuantity { get; set; }

    #endregion

}
