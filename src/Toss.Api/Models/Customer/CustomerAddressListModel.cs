using Nop.Web.Framework.Models;
using Toss.Api.Models.Common;

namespace Toss.Api.Models.Customer;

public partial record CustomerAddressListModel : BaseNopModel
{
    public CustomerAddressListModel()
    {
        Addresses = new List<AddressModel>();
    }

    public IList<AddressModel> Addresses { get; set; }
}