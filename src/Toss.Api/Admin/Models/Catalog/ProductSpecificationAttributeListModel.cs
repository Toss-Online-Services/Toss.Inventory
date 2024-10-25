using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product specification attribute list model
/// </summary>
public partial record ProductSpecificationAttributeListModel : BasePagedListModel<ProductSpecificationAttributeModel>
{
}