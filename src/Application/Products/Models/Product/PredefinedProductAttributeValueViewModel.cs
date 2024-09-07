namespace Application.Products.Models.Product;








/// <summary>
/// Represents a predefined (default) product attribute value
/// </summary>
/// <param name="ProductAttributeId"> Gets or sets the product attribute identifier </param>
/// <param name="Name"> Gets or sets the product attribute name </param>
/// <param name="PriceAdjustment"> Gets or sets the price adjustment </param>
/// <param name="PriceAdjustmentUsePercentage"> Gets or sets a value indicating whether "price adjustment" is specified as percentage </param>
/// <param name="WeightAdjustment"> Gets or sets the weight adjustment </param>
/// <param name="Cost"> Gets or sets the attribute value cost </param>
/// <param name="IsPreSelected"> Gets or sets a value indicating whether the value is pre-selected </param>
/// <param name="DisplayOrder"> Gets or sets the display order </param>
public record PredefinedProductAttributeValueViewModel(int ProductAttributeId, string Name, decimal PriceAdjustment, bool PriceAdjustmentUsePercentage, decimal WeightAdjustment, decimal Cost, bool IsPreSelected, int DisplayOrder);
