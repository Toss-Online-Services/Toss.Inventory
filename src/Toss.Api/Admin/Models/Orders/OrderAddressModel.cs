using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Common;

namespace Toss.Api.Admin.Models.Orders;

public partial record OrderAddressModel : BaseNopModel
{
    #region Ctor

    public OrderAddressModel()
    {
        Address = new AddressModel();
    }

    #endregion

    #region Properties

    public int OrderId { get; set; }

    public AddressModel Address { get; set; }

    #endregion
}