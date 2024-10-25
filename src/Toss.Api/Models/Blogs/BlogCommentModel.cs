using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Blogs;

public partial record BlogCommentModel : BaseNopEntityModel
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string CustomerAvatarUrl { get; set; }

    public string CommentText { get; set; }

    public DateTime CreatedOn { get; set; }

    public bool AllowViewingProfiles { get; set; }
}