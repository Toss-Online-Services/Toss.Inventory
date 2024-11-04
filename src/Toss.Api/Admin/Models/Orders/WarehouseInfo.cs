using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

public partial record ShipmentItemModel
{
   

    #region Nested Classes

    public partial record WarehouseInfo : BaseNopModel
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public int PlannedQuantity { get; set; }
    }

    #endregion
}
