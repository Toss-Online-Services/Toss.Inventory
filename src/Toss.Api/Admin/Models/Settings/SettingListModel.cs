using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Settings;

/// <summary>
/// Represents a setting list model
/// </summary>
public partial record SettingListModel : BasePagedListModel<SettingModel>
{
}