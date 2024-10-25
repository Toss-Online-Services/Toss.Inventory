using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

/// <summary>
/// Represents an order shipment search model
/// </summary>
public partial record OrderShipmentSearchModel : BaseSearchModel
{
    #region Ctor

    public OrderShipmentSearchModel()
    {
        ShipmentItemSearchModel = new ShipmentItemSearchModel();
    }

    #endregion

    #region Properties

    public int OrderId { get; set; }

    public ShipmentItemSearchModel ShipmentItemSearchModel { get; set; }

    #endregion
}