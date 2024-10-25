using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a review type list model
/// </summary>
public partial record ReviewTypeListModel : BasePagedListModel<ReviewTypeModel>
{
}