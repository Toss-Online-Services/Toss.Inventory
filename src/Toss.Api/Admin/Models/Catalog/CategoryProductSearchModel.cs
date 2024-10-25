using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a category product search model
/// </summary>
public partial record CategoryProductSearchModel : BaseSearchModel
{
    #region Properties

    public int CategoryId { get; set; }

    #endregion
}