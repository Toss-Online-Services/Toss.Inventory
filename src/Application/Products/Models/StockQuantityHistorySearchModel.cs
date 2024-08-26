namespace Application.Products.Models;

/// <summary>
/// Represents a stock quantity history search model
/// </summary>
public record StockQuantityHistorySearchModel
{
    #region Ctor

    public StockQuantityHistorySearchModel()
    {
        AvailableWarehouses = new List<string>();
    }

    #endregion

    #region Properties

    public int ProductId { get; set; }
    public int WarehouseId { get; set; }

    public IList<string> AvailableWarehouses { get; set; }

    #endregion
}
