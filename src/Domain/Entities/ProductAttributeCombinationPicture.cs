namespace Domain.Entities;

/// <summary>
/// Represents a product attribute combination picture
/// </summary>
public class ProductAttributeCombinationPicture : Entity
{
    /// <summary>
    /// Gets or sets the product attribute combination id
    /// </summary>
    public int ProductAttributeCombinationId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of picture associated with this combination
    /// </summary>
    public int PictureId { get; set; }
}