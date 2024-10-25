using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Models.Blogs;

public partial record AddBlogCommentModel : BaseNopEntityModel
{
    [NopResourceDisplayName("Blog.Comments.CommentText")]
    public string CommentText { get; set; }

    public bool DisplayCaptcha { get; set; }
}