using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Customer;

public partial record GdprToolsModel : BaseNopModel
{
    public string Result { get; set; }
}