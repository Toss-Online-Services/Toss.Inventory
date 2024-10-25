using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a manufacturer product list model
/// </summary>
public partial record ManufacturerProductListModel : BasePagedListModel<ManufacturerProductModel>
{
}