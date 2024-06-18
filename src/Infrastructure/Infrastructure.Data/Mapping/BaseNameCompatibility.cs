namespace Infrastructure.Data.Mapping;

/// <summary>
/// Base instance of backward compatibility of table naming
/// </summary>
public partial class BaseNameCompatibility : INameCompatibility
{
    public Dictionary<Type, string> TableNames => new()
    {
        { typeof(ProductAttributeMapping), "Product_ProductAttribute_Mapping" },
        { typeof(ProductProductTagMapping), "Product_ProductTag_Mapping" },
        { typeof(ProductReviewReviewTypeMapping), "ProductReview_ReviewType_Mapping" },
        { typeof(ProductCategory), "Product_Category_Mapping" },
        { typeof(ProductManufacturer), "Product_Manufacturer_Mapping" },
        { typeof(ProductPicture), "Product_Picture_Mapping" },
        { typeof(ProductSpecificationAttribute), "Product_SpecificationAttribute_Mapping" }
    };

    public Dictionary<(Type, string), string> ColumnName => new()
    {
        { (typeof(ProductProductTagMapping), "ProductId"), "Product_Id" },
        { (typeof(ProductProductTagMapping), "ProductTagId"), "ProductTag_Id" },
    };
}
