using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Common;

public partial record StoreThemeModel : BaseNopModel
{
    public string Name { get; set; }
    public string Title { get; set; }
}