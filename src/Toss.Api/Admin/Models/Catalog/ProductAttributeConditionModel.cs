using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Catalog;

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

    
}
