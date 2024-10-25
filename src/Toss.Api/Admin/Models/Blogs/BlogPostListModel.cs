using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Blogs;

/// <summary>
/// Represents a blog post list model
/// </summary>
public partial record BlogPostListModel : BasePagedListModel<BlogPostModel>
{
}