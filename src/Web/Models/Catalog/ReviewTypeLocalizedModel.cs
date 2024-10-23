namespace Web.Models.Catalog;

/// <summary>
/// Represents a review type localized model
/// </summary>
public partial record ReviewTypeLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Settings.ReviewType.Fields.Description")]
    public string Description { get; set; }
}