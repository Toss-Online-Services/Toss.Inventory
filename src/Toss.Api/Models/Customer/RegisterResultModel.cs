using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Customer;

public partial record RegisterResultModel : BaseNopModel
{
    public string Result { get; set; }

    public string ReturnUrl { get; set; }
}