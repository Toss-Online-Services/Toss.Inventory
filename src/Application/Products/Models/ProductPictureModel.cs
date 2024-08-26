using System.ComponentModel.DataAnnotations;

namespace Application.Products.Models;
public record ProductPictureModel
{
    public int ProductId { get; set; }

    [UIHint("MultiPicture")]
    public int PictureId { get; set; }

    public string PictureUrl { get; set; }

    public int DisplayOrder { get; set; }

    public string OverrideAltAttribute { get; set; }

    public string OverrideTitleAttribute { get; set; }

}
