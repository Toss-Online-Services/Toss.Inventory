using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product attribute combination list model
/// </summary>
public partial record ProductAttributeCombinationListModel : BasePagedListModel<ProductAttributeCombinationModel>
{
}