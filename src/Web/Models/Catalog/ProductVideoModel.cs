namespace Web.Models.Catalog;

/// <summary>
/// Represents a product video model
/// </summary>
public partial record ProductVideoModel : BaseNopEntityModel
{
    #region Properties

    public int ProductId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.Videos.Fields.VideoUrl")]
    public string VideoUrl { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.Videos.Fields.DisplayOrder")]
    public int DisplayOrder { get; set; }

    #endregion
}