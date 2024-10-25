using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Directory;

/// <summary>
/// Represents a state and province list model
/// </summary>
public partial record StateProvinceListModel : BasePagedListModel<StateProvinceModel>
{
}