using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Boards;

public partial record BoardsIndexModel : BaseNopModel
{
    public BoardsIndexModel()
    {
        ForumGroups = new List<ForumGroupModel>();
    }

    public IList<ForumGroupModel> ForumGroups { get; set; }
}