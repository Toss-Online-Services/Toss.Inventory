using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Customer;

public partial record ExternalAuthenticationMethodModel : BaseNopModel
{
    public Type ViewComponent { get; set; }
}