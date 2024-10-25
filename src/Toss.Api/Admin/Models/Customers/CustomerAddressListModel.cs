using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Common;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer address list model
/// </summary>
public partial record CustomerAddressListModel : BasePagedListModel<AddressModel>
{
}