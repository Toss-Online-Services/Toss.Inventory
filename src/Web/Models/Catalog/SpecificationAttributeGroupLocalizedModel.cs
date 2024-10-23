namespace Web.Models.Catalog;

/// <summary>
/// Represents a specification attribute group localized model
/// </summary>
public partial record SpecificationAttributeGroupLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Attributes.SpecificationAttributes.SpecificationAttributeGroup.Fields.Name")]
    public string Name { get; set; }
}