using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Blogs;

/// <summary>
/// Represents a blog comment list model
/// </summary>
public partial record BlogCommentListModel : BasePagedListModel<BlogCommentModel>
{
}