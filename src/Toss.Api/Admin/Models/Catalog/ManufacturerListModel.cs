using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a manufacturer list model
/// </summary>
public partial record ManufacturerListModel : BasePagedListModel<ManufacturerModel>
{
}