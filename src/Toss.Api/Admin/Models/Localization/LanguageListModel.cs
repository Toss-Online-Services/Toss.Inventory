using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Localization;

/// <summary>
/// Represents a language list model
/// </summary>
public partial record LanguageListModel : BasePagedListModel<LanguageModel>
{
}