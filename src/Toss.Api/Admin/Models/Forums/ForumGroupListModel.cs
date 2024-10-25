using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Forums;

/// <summary>
/// Represents a forum group list model
/// </summary>
public partial record ForumGroupListModel : BasePagedListModel<ForumGroupModel>
{
}