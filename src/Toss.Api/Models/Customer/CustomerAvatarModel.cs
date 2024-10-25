using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Customer;

public partial record CustomerAvatarModel : BaseNopModel
{
    public string AvatarUrl { get; set; }
}