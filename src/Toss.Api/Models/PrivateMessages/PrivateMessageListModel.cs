using Nop.Web.Framework.Models;
using Toss.Api.Models.Common;

namespace Toss.Api.Models.PrivateMessages;

public partial record PrivateMessageListModel : BaseNopModel
{
    public IList<PrivateMessageModel> Messages { get; set; }
    public PagerModel PagerModel { get; set; }
}