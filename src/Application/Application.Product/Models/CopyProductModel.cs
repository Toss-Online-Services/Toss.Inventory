namespace Application.Product.Models;

/// <summary>
/// Represents a copy product model
/// </summary>
public record CopyProductModel
{
    #region Properties

    public string Name { get; set; }


    public bool CopyMultimedia { get; set; }


    public bool Published { get; set; }

    #endregion
}
