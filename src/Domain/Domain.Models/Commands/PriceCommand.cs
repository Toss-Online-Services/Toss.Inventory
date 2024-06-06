namespace Domain.Models.Commands;

public record PriceCommand
{
    /// <summary>
    /// Gets or sets a value indicating whether to show "Call for Pricing" or "Call for quote" instead of price
    /// </summary>
    public bool CallForPrice { get; init; }

    /// <summary>
    /// Gets or sets the price
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Gets or sets the old price
    /// </summary>
    public decimal OldPrice { get; init; }

    /// <summary>
    /// Gets or sets the product cost
    /// </summary>
    public decimal ProductCost { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether a customer enters price
    /// </summary>
    public bool CustomerEntersPrice { get; init; }

    /// <summary>
    /// Gets or sets the minimum price entered by a customer
    /// </summary>
    public decimal MinimumCustomerEnteredPrice { get; init; }

    /// <summary>
    /// Gets or sets the maximum price entered by a customer
    /// </summary>
    public decimal MaximumCustomerEnteredPrice { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether base price (PAngV) is enabled. Used by German users.
    /// </summary>
    public bool BasepriceEnabled { get; init; }

    /// <summary>
    /// Gets or sets an amount in product for PAngV
    /// </summary>
    public decimal BasepriceAmount { get; init; }

    /// <summary>
    /// Gets or sets a unit of product for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceUnitId { get; init; }

    /// <summary>
    /// Gets or sets a reference amount for PAngV
    /// </summary>
    public decimal BasepriceBaseAmount { get; init; }

    /// <summary>
    /// Gets or sets a reference unit for PAngV (MeasureWeight entity)
    /// </summary>
    public int BasepriceBaseUnitId { get; init; }

    /// <summary>
    /// Gets or sets a value indicating whether this product is marked as new
    /// </summary>

}
