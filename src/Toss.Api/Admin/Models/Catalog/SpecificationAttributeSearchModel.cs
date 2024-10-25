using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a specification attribute search model
/// </summary>
public partial record SpecificationAttributeSearchModel : BaseSearchModel
{
    #region Properties

    public int SpecificationAttributeGroupId { get; set; }

    #endregion
}