using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a predefined product attribute value list model
/// </summary>
public partial record PredefinedProductAttributeValueListModel : BasePagedListModel<PredefinedProductAttributeValueModel>
{
}