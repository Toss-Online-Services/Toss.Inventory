using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Stores;

/// <summary>
/// Represents a store list model
/// </summary>
public partial record StoreListModel : BasePagedListModel<StoreModel>
{
}