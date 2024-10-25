using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Directory;

/// <summary>
/// Represents a currency list model
/// </summary>
public partial record CurrencyListModel : BasePagedListModel<CurrencyModel>
{
}