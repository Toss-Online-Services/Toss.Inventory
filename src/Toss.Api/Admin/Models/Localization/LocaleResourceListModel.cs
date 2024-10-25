using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Localization;

/// <summary>
/// Represents a locale resource list model
/// </summary>
public partial record LocaleResourceListModel : BasePagedListModel<LocaleResourceModel>
{
}