using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

/// <summary>
/// Represents an address attribute list model
/// </summary>
public partial record AddressAttributeListModel : BasePagedListModel<AddressAttributeModel>
{
}