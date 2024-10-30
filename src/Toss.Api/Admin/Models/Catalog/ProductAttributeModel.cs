using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product attribute model
/// </summary>
public partial record ProductAttributeModel : BaseNopEntityModel, ILocalizedModel<ProductAttributeLocalizedModel>
{
    #region Ctor

    public ProductAttributeModel()
    {
        Locales = new List<ProductAttributeLocalizedModel>();
        PredefinedProductAttributeValueSearchModel = new PredefinedProductAttributeValueSearchModel();
        ProductAttributeProductSearchModel = new ProductAttributeProductSearchModel();
    }

    #endregion

    #region Properties

    [NopResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Catalog.Attributes.ProductAttributes.Fields.Description")]
    public string Description { get; set; }

    public IList<ProductAttributeLocalizedModel> Locales { get; set; }

    public PredefinedProductAttributeValueSearchModel PredefinedProductAttributeValueSearchModel { get; set; }

    public ProductAttributeProductSearchModel ProductAttributeProductSearchModel { get; set; }

    public int ProductAttributeId { get; set; }

    public string TextPrompt { get; set; }

    public bool IsRequired { get; set; }

    public AttributeControlType AttributeControlType { get; set; }

    public IList<ProductAttributeValueModel> Values { get; set; }


    #endregion
}
