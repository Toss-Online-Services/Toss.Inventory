using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Newsletter;

public partial record SubscriptionActivationModel : BaseNopModel
{
    public string Result { get; set; }
}