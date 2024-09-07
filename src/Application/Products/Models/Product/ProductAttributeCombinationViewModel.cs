using System.ComponentModel;

namespace Application.Products.Models.Product;











/// <summary>
/// Represents a product attribute combination
/// </summary>
/// <param name="ProductId"> Gets or sets the product identifier </param>
/// <param name="AttributesXml"> Gets or sets the attributes </param>
/// <param name="StockQuantity"> Gets or sets the stock quantity </param>
/// <param name="AllowOutOfStockOrders"> Gets or sets a value indicating whether to allow orders when out of stock </param>
/// <param name="Sku"> Gets or sets the SKU </param>
/// <param name="ManufacturerPartNumber"> Gets or sets the manufacturer part number </param>
/// <param name="Gtin"> Gets or sets the Global Trade Item Number (GTIN). These identifiers include UPC (in North America), EAN (in Europe), JAN (in Japan), and ISBN (for books). </param>
/// <param name="OverriddenPrice"> Gets or sets the attribute combination price. This way a store owner can override the default product price when this attribute combination is added to the cart. For example, you can give a discount this way. </param>
/// <param name="NotifyAdminForQuantityBelow"> Gets or sets the quantity when admin should be notified </param>
/// <param name="MinStockQuantity"> Gets or sets the minimum stock quantity </param>
/// <param name="PictureId"> The field is not used since 4.70 and is left only for the update process
/// use the <see cref="ProductAttributeCombinationPictureViewModel"/> instead </param>
public record ProductAttributeCombinationViewModel(int ProductId, string AttributesXml, int StockQuantity, bool AllowOutOfStockOrders, string Sku, string ManufacturerPartNumber, string Gtin, decimal? OverriddenPrice, int NotifyAdminForQuantityBelow, int MinStockQuantity, [property: EditorBrowsable(EditorBrowsableState.Never)][property: Browsable(false)][property: Obsolete("The field is not used since 4.70 and is left only for the update process use the ProductAttributeCombinationPicture instead")] int? PictureId);
