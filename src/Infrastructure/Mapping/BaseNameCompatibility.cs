﻿namespace Infrastructure.Mapping;

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
        { typeof(CustomerAddressMapping), "CustomerAddresses" },
        { typeof(CustomerCustomerRoleMapping), "Customer_CustomerRole_Mapping" },
        { typeof(DiscountCategoryMapping), "Discount_AppliedToCategories" },
        { typeof(DiscountManufacturerMapping), "Discount_AppliedToManufacturers" },
        { typeof(DiscountProductMapping), "Discount_AppliedToProducts" },
        { typeof(PermissionRecordCustomerRoleMapping), "PermissionRecord_Role_Mapping" },
        { typeof(ShippingMethodCountryMapping), "ShippingMethodRestrictions" },
        { typeof(ProductCategory), "Product_Category_Mapping" },
        { typeof(ProductManufacturer), "Product_Manufacturer_Mapping" },
        { typeof(ProductPicture), "Product_Picture_Mapping" },
        { typeof(ProductSpecificationAttribute), "Product_SpecificationAttribute_Mapping" },        
    };

    public Dictionary<(Type, string), string> ColumnName => new()
    {
        { (typeof(Customer), "BillingAddressId"), "BillingAddress_Id" },
        { (typeof(Customer), "ShippingAddressId"), "ShippingAddress_Id" },
        { (typeof(CustomerCustomerRoleMapping), "CustomerId"), "Customer_Id" },
        { (typeof(CustomerCustomerRoleMapping), "CustomerRoleId"), "CustomerRole_Id" },
        { (typeof(PermissionRecordCustomerRoleMapping), "PermissionRecordId"), "PermissionRecord_Id" },
        { (typeof(PermissionRecordCustomerRoleMapping), "CustomerRoleId"), "CustomerRole_Id" },
        { (typeof(ProductProductTagMapping), "ProductId"), "Product_Id" },
        { (typeof(ProductProductTagMapping), "ProductTagId"), "ProductTag_Id" },
        { (typeof(DiscountCategoryMapping), "DiscountId"), "Discount_Id" },
        { (typeof(DiscountCategoryMapping), "EntityId"), "Category_Id" },
        { (typeof(DiscountManufacturerMapping), "DiscountId"), "Discount_Id" },
        { (typeof(DiscountManufacturerMapping), "EntityId"), "Manufacturer_Id" },
        { (typeof(DiscountProductMapping), "DiscountId"), "Discount_Id" },
        { (typeof(DiscountProductMapping), "EntityId"), "Product_Id" },
        { (typeof(CustomerAddressMapping), "AddressId"), "Address_Id" },
        { (typeof(CustomerAddressMapping), "CustomerId"), "Customer_Id" },
        { (typeof(ShippingMethodCountryMapping), "ShippingMethodId"), "ShippingMethod_Id" },
        { (typeof(ShippingMethodCountryMapping), "CountryId"), "Country_Id" },
        { (typeof(VendorAttributeValue), "AttributeId"), "VendorAttributeId" },
        { (typeof(CustomerAttributeValue), "AttributeId"), "CustomerAttributeId" },
        { (typeof(AddressAttributeValue), "AttributeId"), "AddressAttributeId" },
    };
}