namespace Web.Models.Catalog;

/// <summary>
/// Represents an add specification attribute localized model
/// </summary>
public partial record AddSpecificationAttributeLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.CustomValue")]
    public string ValueRaw { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.SpecificationAttributes.Fields.CustomValue")]
    public string Value { get; set; }
}