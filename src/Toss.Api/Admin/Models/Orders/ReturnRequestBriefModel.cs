using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Orders;

public partial record OrderItemModel
{
   

    #region Nested Classes

    public partial record ReturnRequestBriefModel : BaseNopEntityModel
    {
        public string CustomNumber { get; set; }
    }

    #endregion
}
