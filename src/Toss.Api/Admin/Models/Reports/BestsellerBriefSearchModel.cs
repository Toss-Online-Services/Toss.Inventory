using Nop.Services.Orders;
using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Reports;

/// <summary>
/// Represents a bestseller brief search model
/// </summary>
public partial record BestsellerBriefSearchModel : BaseSearchModel
{
    #region Properties

    public OrderByEnum OrderBy { get; set; }

    #endregion
}