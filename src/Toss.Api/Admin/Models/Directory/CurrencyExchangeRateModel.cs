using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Directory;

/// <summary>
/// Represents a currency exchange rate model
/// </summary>
public partial record CurrencyExchangeRateModel : BaseNopModel
{
    #region Properties

    public string CurrencyCode { get; set; }

    public decimal Rate { get; set; }

    #endregion
}