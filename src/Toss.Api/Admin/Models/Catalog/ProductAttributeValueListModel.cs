using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product attribute value list model
/// </summary>
public partial record ProductAttributeValueListModel : BasePagedListModel<ProductAttributeValueModel>
{
}