using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Common;

public partial record FaviconAndAppIconsModel : BaseNopModel
{
    public string HeadCode { get; set; }
}