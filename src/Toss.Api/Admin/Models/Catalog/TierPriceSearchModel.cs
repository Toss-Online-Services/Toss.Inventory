using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a tier price search model
/// </summary>
public partial record TierPriceSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}