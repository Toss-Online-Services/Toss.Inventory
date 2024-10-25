using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a specification attribute group list model
/// </summary>
public partial record SpecificationAttributeGroupListModel : BasePagedListModel<SpecificationAttributeGroupModel>
{
}