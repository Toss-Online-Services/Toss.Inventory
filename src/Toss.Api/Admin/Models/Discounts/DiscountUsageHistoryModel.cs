﻿using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Discounts;

/// <summary>
/// Represents a discount usage history model
/// </summary>
public partial record DiscountUsageHistoryModel : BaseNopEntityModel
{
    #region Properties

    public int DiscountId { get; set; }

    public int OrderId { get; set; }

    [NopResourceDisplayName("Admin.Promotions.Discounts.History.CustomOrderNumber")]
    public string CustomOrderNumber { get; set; }

    [NopResourceDisplayName("Admin.Promotions.Discounts.History.OrderTotal")]
    public string OrderTotal { get; set; }

    [NopResourceDisplayName("Admin.Promotions.Discounts.History.CreatedOn")]
    public DateTime CreatedOn { get; set; }

    #endregion
}