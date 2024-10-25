using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Directory;

/// <summary>
/// Represents a state and province search model
/// </summary>
public partial record StateProvinceSearchModel : BaseSearchModel
{
    #region Properties

    public int CountryId { get; set; }

    #endregion
}