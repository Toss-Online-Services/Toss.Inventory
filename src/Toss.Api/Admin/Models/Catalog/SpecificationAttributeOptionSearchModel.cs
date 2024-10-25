using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a specification attribute option search model
/// </summary>
public partial record SpecificationAttributeOptionSearchModel : BaseSearchModel
{
    #region Properties

    public int SpecificationAttributeId { get; set; }

    #endregion
}