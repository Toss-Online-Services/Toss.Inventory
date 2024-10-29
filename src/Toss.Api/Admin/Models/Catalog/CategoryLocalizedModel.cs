using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Catalog;

public partial record CategoryLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.Description")]
    public string Description { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.MetaKeywords")]
    public string MetaKeywords { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.MetaDescription")]
    public string MetaDescription { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.MetaTitle")]
    public string MetaTitle { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Categories.Fields.SeName")]
    public string SeName { get; set; }
}
