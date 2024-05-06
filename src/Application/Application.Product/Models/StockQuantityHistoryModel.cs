using System.ComponentModel.DataAnnotations;

namespace Application.Product.Models;

/// <summary>
/// Represents a stock quantity history model
/// </summary>
public record StockQuantityHistoryModel
{
    #region Properties

    public string WarehouseName { get; set; }
    public string AttributeCombination { get; set; }
    public int QuantityAdjustment { get; set; }
    public int StockQuantity { get; set; }
    public string Message { get; set; }
    [UIHint("DecimalNullable")]
    public DateTime CreatedOn { get; set; }

    #endregion
}
