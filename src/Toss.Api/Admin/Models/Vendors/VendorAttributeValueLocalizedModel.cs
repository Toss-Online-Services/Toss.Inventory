using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Vendors;

public partial record VendorAttributeValueLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.Name")]
    public string Name { get; set; }
}
