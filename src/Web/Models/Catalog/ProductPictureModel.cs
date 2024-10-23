using System.ComponentModel.DataAnnotations;

namespace Web.Models.Catalog;

/// <summary>
/// Represents a product picture model
/// </summary>
public partial record ProductPictureModel : BaseNopEntityModel
{
    #region Properties

    public int ProductId { get; set; }

    [UIHint("MultiPicture")]
    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.Pictures.Fields.Picture")]
    public int PictureId { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.Pictures.Fields.Picture")]
    public string PictureUrl { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.Pictures.Fields.DisplayOrder")]
    public int DisplayOrder { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.Pictures.Fields.OverrideAltAttribute")]
    public string OverrideAltAttribute { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.Multimedia.Pictures.Fields.OverrideTitleAttribute")]
    public string OverrideTitleAttribute { get; set; }

    #endregion
}