using Nop.Web.Framework.Models;
using Toss.Api.Models.Common;

namespace Toss.Api.Models.Customer;

public partial record CustomerAddressEditModel : BaseNopModel
{
    public CustomerAddressEditModel()
    {
        Address = new AddressModel();
    }

    public AddressModel Address { get; set; }
}