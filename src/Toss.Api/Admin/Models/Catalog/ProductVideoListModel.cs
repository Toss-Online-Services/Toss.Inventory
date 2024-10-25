using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product video list model
/// </summary>
public partial record ProductVideoListModel : BasePagedListModel<ProductVideoModel>
{
}