using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Tax;

/// <summary>
/// Represents a tax provider list model
/// </summary>
public partial record TaxProviderListModel : BasePagedListModel<TaxProviderModel>
{
}