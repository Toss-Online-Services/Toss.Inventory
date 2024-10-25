using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product attribute value search model
/// </summary>
public partial record ProductAttributeValueSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductAttributeMappingId { get; set; }

    #endregion
}