using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Customer;

public partial record GdprConsentModel : BaseNopEntityModel
{
    public string Message { get; set; }

    public bool IsRequired { get; set; }

    public string RequiredMessage { get; set; }

    public bool Accepted { get; set; }
}