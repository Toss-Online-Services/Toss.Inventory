using Domain.Entities.Catalog;

namespace Web.Models.Catalog;

public partial record ProductAttributeConditionModel : BaseNopModel
{
    public ProductAttributeConditionModel()
    {
        ProductAttributes = new List<ProductAttributeModel>();
    }

    [NopResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Condition.EnableCondition")]
    public bool EnableCondition { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Products.ProductAttributes.Attributes.Condition.Attributes")]
    public int SelectedProductAttributeId { get; set; }
    public IList<ProductAttributeModel> ProductAttributes { get; set; }

    public int ProductAttributeMappingId { get; set; }

    #region Nested classes

    public partial record ProductAttributeModel : BaseNopEntityModel
    {
        public ProductAttributeModel()
        {
            Values = new List<ProductAttributeValueModel>();
            Name = string.Empty;
            TextPrompt = string.Empty;
        }

        public int ProductAttributeId { get; set; }

        public string Name { get; set; }

        public string TextPrompt { get; set; }

        public bool IsRequired { get; set; }

        public AttributeControlType AttributeControlType { get; set; }

        public IList<ProductAttributeValueModel> Values { get; set; }
    }

    public partial record ProductAttributeValueModel : BaseNopEntityModel
    {
        public string Name { get; set; } = string.Empty;

        public bool IsPreSelected { get; set; }
    }

    #endregion
}
