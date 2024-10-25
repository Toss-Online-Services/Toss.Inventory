using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product attribute list model
/// </summary>
public partial record ProductAttributeListModel : BasePagedListModel<ProductAttributeModel>
{
}