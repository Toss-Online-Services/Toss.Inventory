using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product attribute mapping list model
/// </summary>
public partial record ProductAttributeMappingListModel : BasePagedListModel<ProductAttributeMappingModel>
{
}