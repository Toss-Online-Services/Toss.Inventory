using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Directory;

public partial record CountryLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Countries.Fields.Name")]
    public string Name { get; set; }
}
