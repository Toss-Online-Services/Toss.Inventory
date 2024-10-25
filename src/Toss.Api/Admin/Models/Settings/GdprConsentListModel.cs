using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Settings;

/// <summary>
/// Represents a GDPR consent list model
/// </summary>
public partial record GdprConsentListModel : BasePagedListModel<GdprConsentModel>
{
}