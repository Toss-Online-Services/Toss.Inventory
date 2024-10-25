using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a list model of products that use the specification attribute
/// </summary>
public partial record SpecificationAttributeProductListModel : BasePagedListModel<SpecificationAttributeProductModel>
{
}