namespace Application.Products.Models;
public record ProductVideoModel
{
    #region Properties

    public int ProductId { get; set; }

    public string VideoUrl { get; set; }

    public int DisplayOrder { get; set; }

    #endregion

}
