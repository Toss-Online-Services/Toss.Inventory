using Nop.Web.Framework.Models;
using Toss.Api.Models.Common;

namespace Toss.Api.Models.Profile;

public partial record ProfilePostsModel : BaseNopModel
{
    public IList<PostsModel> Posts { get; set; }
    public PagerModel PagerModel { get; set; }
}