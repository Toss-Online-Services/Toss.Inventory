using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Settings;

/// <summary>
/// Represents a sort option list model
/// </summary>
public partial record SortOptionListModel : BasePagedListModel<SortOptionModel>
{
}