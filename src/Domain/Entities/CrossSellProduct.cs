namespace Domain.Entities;

/// <summary>
/// Represents a cross-sell product
/// </summary>
public class CrossSellProduct : Entity
{
    /// <summary>
    /// Gets or sets the first product identifier
    /// </summary>
    public int ProductId1 { get; set; }

    /// <summary>
    /// Gets or sets the second product identifier
    /// </summary>
    public int ProductId2 { get; set; }
}
