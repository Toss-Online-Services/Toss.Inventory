using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

/// <summary>
/// Represents an address attribute value list model
/// </summary>
public partial record AddressAttributeValueListModel : BasePagedListModel<AddressAttributeValueModel>
{
}