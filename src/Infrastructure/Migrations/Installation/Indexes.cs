using FluentMigrator;
using FluentMigrator.SqlServer;
using Infrastructure.Mapping;
using Domain.Logging;

namespace Infrastructure.Migrations.Installation;

[NopSchemaMigration("2020/03/13 09:36:08:9037677", "Infrastructure base indexes", MigrationProcessType.Installation)]
public class Indexes : ForwardOnlyMigration
{
    #region Methods

    public override void Up()
    {
        Create.Index("IX_UrlRecord_Slug")
            .OnTable(nameof(UrlRecord))
            .OnColumn(nameof(UrlRecord.Slug))
            .Ascending()
            .WithOptions()
            .NonClustered();

        Create.Index("IX_UrlRecord_Custom_1").OnTable(nameof(UrlRecord))
            .OnColumn(nameof(UrlRecord.EntityId)).Ascending()
            .OnColumn(nameof(UrlRecord.EntityName)).Ascending()
            .OnColumn(nameof(UrlRecord.LanguageId)).Ascending()
            .OnColumn(nameof(UrlRecord.IsActive)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_StoreMapping_EntityId_EntityName").OnTable(nameof(StoreMapping))
            .OnColumn(nameof(StoreMapping.EntityId)).Ascending()
            .OnColumn(nameof(StoreMapping.EntityName)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_RelatedProduct_ProductId1").OnTable(nameof(RelatedProduct))
            .OnColumn(nameof(RelatedProduct.ProductId1)).Ascending()
            .WithOptions().NonClustered();        

     
        Create.Index("IX_PSAM_SpecificationAttributeOptionId_AllowFiltering").OnTable(typeof(ProductSpecificationAttribute).Name)
            .OnColumn(nameof(ProductSpecificationAttribute.SpecificationAttributeOptionId)).Ascending()
            .OnColumn(nameof(ProductSpecificationAttribute.AllowFiltering)).Ascending()
            .WithOptions().NonClustered()
            .Include(nameof(ProductSpecificationAttribute.ProductId));

        Create.Index("IX_PSAM_AllowFiltering").OnTable(typeof(ProductSpecificationAttribute).Name)
            .OnColumn(nameof(ProductSpecificationAttribute.AllowFiltering)).Ascending()
            .WithOptions().NonClustered()
            .Include(nameof(ProductSpecificationAttribute.ProductId))
            .Include(nameof(ProductSpecificationAttribute.SpecificationAttributeOptionId));

        Create.Index("IX_Product_VisibleIndividually_Published_Deleted_Extended").OnTable(nameof(Product))
            .OnColumn(nameof(Product.VisibleIndividually)).Ascending()
            .OnColumn(nameof(Product.Published)).Ascending()
            .OnColumn(nameof(Product.Deleted)).Ascending()
            .WithOptions().NonClustered()
            .Include(nameof(Product.Id))
            .Include(nameof(Product.AvailableStartDateTimeUtc))
            .Include(nameof(Product.AvailableEndDateTimeUtc));

        Create.Index("IX_Product_VisibleIndividually").OnTable(nameof(Product))
            .OnColumn(nameof(Product.VisibleIndividually)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_ProductTag_Name").OnTable(nameof(ProductTag))
            .OnColumn(nameof(ProductTag.Name)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_Name").OnTable(nameof(Product))
            .OnColumn(nameof(Product.Name)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_SubjectToAcl").OnTable(nameof(Product))
            .OnColumn(nameof(Product.SubjectToAcl)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_ShowOnHomepage").OnTable(nameof(Product))
            .OnColumn(nameof(Product.ShowOnHomepage)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_Published").OnTable(nameof(Product))
            .OnColumn(nameof(Product.Published)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_ProductAttribute_Mapping_ProductId_DisplayOrder").OnTable(typeof(ProductAttributeMapping).Name)
            .OnColumn(nameof(ProductAttributeMapping.ProductId)).Ascending()
            .OnColumn(nameof(ProductAttributeMapping.DisplayOrder)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_PriceDatesEtc").OnTable(nameof(Product))
            .OnColumn(nameof(Product.Price)).Ascending()
            .OnColumn(nameof(Product.AvailableStartDateTimeUtc)).Ascending()
            .OnColumn(nameof(Product.AvailableEndDateTimeUtc)).Ascending()
            .OnColumn(nameof(Product.Published)).Ascending()
            .OnColumn(nameof(Product.Deleted)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_ParentGroupedProductId").OnTable(nameof(Product))
            .OnColumn(nameof(Product.ParentGroupedProductId)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_Manufacturer_Mapping_IsFeaturedProduct")
            .OnTable(typeof(ProductManufacturer).Name)
            .OnColumn(nameof(ProductManufacturer.IsFeaturedProduct)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_LimitedToStores").OnTable(nameof(Product))
            .OnColumn(nameof(Product.LimitedToStores)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_Delete_Id").OnTable(nameof(Product))
            .OnColumn(nameof(Product.Deleted)).Ascending()
            .OnColumn(nameof(Product.Id)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_Deleted_and_Published").OnTable(nameof(Product))
            .OnColumn(nameof(Product.Published)).Ascending()
            .OnColumn(nameof(Product.Deleted)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Product_Category_Mapping_IsFeaturedProduct").OnTable(typeof(ProductCategory).Name)
            .OnColumn(nameof(ProductCategory.IsFeaturedProduct)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_ProductAttributeValue_ProductAttributeMappingId_DisplayOrder").OnTable(nameof(ProductAttributeValue))
            .OnColumn(nameof(ProductAttributeValue.ProductAttributeMappingId)).Ascending()
            .OnColumn(nameof(ProductAttributeValue.DisplayOrder)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_PMM_Product_and_Manufacturer").OnTable(typeof(ProductManufacturer).Name)
            .OnColumn(nameof(ProductManufacturer.ManufacturerId)).Ascending()
            .OnColumn(nameof(ProductManufacturer.ProductId)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_PMM_ProductId_Extended").OnTable(typeof(ProductManufacturer).Name)
            .OnColumn(nameof(ProductManufacturer.ProductId)).Ascending()
            .OnColumn(nameof(ProductManufacturer.IsFeaturedProduct)).Ascending()
            .WithOptions().NonClustered()
            .Include(nameof(ProductManufacturer.ManufacturerId));

        Create.Index("IX_PCM_ProductId_Extended").OnTable(typeof(ProductCategory).Name)
            .OnColumn(nameof(ProductCategory.ProductId)).Ascending()
            .OnColumn(nameof(ProductCategory.IsFeaturedProduct)).Ascending()
            .WithOptions().NonClustered()
            .Include(nameof(ProductCategory.CategoryId));

        Create.Index("IX_PCM_Product_and_Category").OnTable(typeof(ProductCategory).Name)
            .OnColumn(nameof(ProductCategory.CategoryId)).Ascending()
            .OnColumn(nameof(ProductCategory.ProductId)).Ascending()
            .WithOptions().NonClustered();       

        Create.Index("IX_Manufacturer_SubjectToAcl").OnTable(nameof(Manufacturer))
            .OnColumn(nameof(Manufacturer.SubjectToAcl)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Manufacturer_LimitedToStores").OnTable(nameof(Manufacturer))
            .OnColumn(nameof(Manufacturer.LimitedToStores)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Manufacturer_DisplayOrder").OnTable(nameof(Manufacturer))
            .OnColumn(nameof(Manufacturer.DisplayOrder)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Log_CreatedOnUtc").OnTable(nameof(Log))
            .OnColumn(nameof(Log.CreatedOnUtc)).Descending()
            .WithOptions().NonClustered();

        Create.Index("IX_LocaleStringResource").OnTable(nameof(LocaleStringResource))
            .OnColumn(nameof(LocaleStringResource.ResourceName)).Ascending()
            .OnColumn(nameof(LocaleStringResource.LanguageId)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Language_DisplayOrder").OnTable(nameof(Language))
            .OnColumn(nameof(Language.DisplayOrder)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_GetLowStockProducts").OnTable(nameof(Product))
            .OnColumn(nameof(Product.Deleted)).Ascending()
            .OnColumn(nameof(Product.VendorId)).Ascending()
            .OnColumn(nameof(Product.ProductTypeId)).Ascending()
            .OnColumn(nameof(Product.ManageInventoryMethodId)).Ascending()
            .OnColumn(nameof(Product.MinStockQuantity)).Ascending()
            .OnColumn(nameof(Product.UseMultipleWarehouses)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_GenericAttribute_EntityId_and_KeyGroup").OnTable(nameof(GenericAttribute))
            .OnColumn(nameof(GenericAttribute.EntityId)).Ascending()
            .OnColumn(nameof(GenericAttribute.KeyGroup)).Ascending()
            .WithOptions().NonClustered();       

        Create.Index("IX_Customer_Username").OnTable(nameof(Customer))
            .OnColumn(nameof(Customer.Username)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Customer_SystemName").OnTable(nameof(Customer))
            .OnColumn(nameof(Customer.SystemName)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Customer_Email").OnTable(nameof(Customer))
            .OnColumn(nameof(Customer.Email)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Customer_CustomerGuid").OnTable(nameof(Customer))
            .OnColumn(nameof(Customer.CustomerGuid)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Customer_CreatedOnUtc").OnTable(nameof(Customer))
            .OnColumn(nameof(Customer.CreatedOnUtc)).Descending()
            .WithOptions().NonClustered();

        Create.Index("IX_Currency_DisplayOrder").OnTable(nameof(Currency))
            .OnColumn(nameof(Currency.DisplayOrder)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Country_DisplayOrder").OnTable(nameof(Country))
            .OnColumn(nameof(Country.DisplayOrder)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Category_ParentCategoryId").OnTable(nameof(Category))
            .OnColumn(nameof(Category.ParentCategoryId)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Category_LimitedToStores").OnTable(nameof(Category))
            .OnColumn(nameof(Category.LimitedToStores)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Category_DisplayOrder").OnTable(nameof(Category))
            .OnColumn(nameof(Category.DisplayOrder)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Category_Deleted_Extended").OnTable(nameof(Category))
            .OnColumn(nameof(Category.Deleted)).Ascending()
            .WithOptions().NonClustered()
            .Include(nameof(Category.Id))
            .Include(nameof(Category.Name))
            .Include(nameof(Category.SubjectToAcl)).Include(nameof(Category.LimitedToStores))
            .Include(nameof(Category.Published));

        Create.Index("IX_Category_SubjectToAcl").OnTable(nameof(Category))
            .OnColumn(nameof(Category.SubjectToAcl)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_ActivityLog_CreatedOnUtc").OnTable(nameof(ActivityLog))
            .OnColumn(nameof(ActivityLog.CreatedOnUtc)).Descending()
            .WithOptions().NonClustered();

        Create.Index("IX_AclRecord_EntityId_EntityName").OnTable(nameof(AclRecord))
            .OnColumn(nameof(AclRecord.EntityId)).Ascending()
            .OnColumn(nameof(AclRecord.EntityName)).Ascending()
            .WithOptions().NonClustered();

        Create.Index("IX_Customer_Deleted")
            .OnTable(nameof(Customer))
            .OnColumn(nameof(Customer.Deleted)).Ascending()
            .WithOptions().NonClustered();
    }

    #endregion
}
