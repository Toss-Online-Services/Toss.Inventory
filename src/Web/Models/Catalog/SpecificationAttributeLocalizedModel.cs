namespace Web.Models.Catalog;

/// <summary>
/// Represents a specification attribute localized model
/// </summary>
public partial record SpecificationAttributeLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttribute.Fields.Name")]
    public string Name { get; set; }
}