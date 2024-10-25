using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product picture list model
/// </summary>
public partial record ProductPictureListModel : BasePagedListModel<ProductPictureModel>
{
}