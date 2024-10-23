using Web.Models.Common;

namespace Web.Models.Orders;

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
