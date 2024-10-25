using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Common;

public partial record AdminHeaderLinksModel : BaseNopModel
{
    public string ImpersonatedCustomerName { get; set; }
    public bool IsCustomerImpersonated { get; set; }
    public bool DisplayAdminLink { get; set; }
    public string EditPageUrl { get; set; }
}