using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

/// <summary>
/// Represents a popular search term list model
/// </summary>
public partial record PopularSearchTermListModel : BasePagedListModel<PopularSearchTermModel>
{
}