using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Blogs;

public partial record BlogPostTagModel : BaseNopModel
{
    public string Name { get; set; }

    public int BlogPostCount { get; set; }
}