using Domain.Entities.Catalog;

namespace Web.Models.Orders;

/// <summary>
/// Represents an order item model
/// </summary>
public partial record OrderItemModel : BaseNopEntityModel
{
    #region Ctor

    public OrderItemModel()
    {
        PurchasedGiftCardIds = new List<int>();
        ReturnRequests = new List<ReturnRequestBriefModel>();
    }

    #endregion

    #region Properties

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string VendorName { get; set; } = string.Empty;

    public string Sku { get; set; } = string.Empty;

    public string PictureThumbnailUrl { get; set; } = string.Empty;

    public string UnitPriceInclTax { get; set; } = string.Empty;

    public string UnitPriceExclTax { get; set; } = string.Empty;

    public decimal UnitPriceInclTaxValue { get; set; }

    public decimal UnitPriceExclTaxValue { get; set; }

    public int Quantity { get; set; }

    public string DiscountInclTax { get; set; } = string.Empty;

    public string DiscountExclTax { get; set; } = string.Empty;

    public decimal DiscountInclTaxValue { get; set; }

    public decimal DiscountExclTaxValue { get; set; }

    public string SubTotalInclTax { get; set; } = string.Empty;

    public string SubTotalExclTax { get; set; } = string.Empty;

    public decimal SubTotalInclTaxValue { get; set; }

    public decimal SubTotalExclTaxValue { get; set; }

    public string AttributeInfo { get; set; } = string.Empty;

    public string RecurringInfo { get; set; } = string.Empty;

    public string RentalInfo { get; set; } = string.Empty;

    public IList<ReturnRequestBriefModel> ReturnRequests { get; set; }

    public IList<int> PurchasedGiftCardIds { get; set; }

    public bool IsDownload { get; set; }

    public int DownloadCount { get; set; }

    public DownloadActivationType DownloadActivationType { get; set; }

    public bool IsDownloadActivated { get; set; }

    public Guid LicenseDownloadGuid { get; set; }

    #endregion

    #region Nested Classes

    public partial record ReturnRequestBriefModel : BaseNopEntityModel
    {
        public string CustomNumber { get; set; } = string.Empty;
    }

    #endregion
}
