using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a predefined product attribute value search model
/// </summary>
public partial record PredefinedProductAttributeValueSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductAttributeId { get; set; }

    #endregion
}