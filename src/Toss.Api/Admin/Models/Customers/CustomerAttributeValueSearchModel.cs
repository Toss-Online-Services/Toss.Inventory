using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer attribute value search model
/// </summary>
public partial record CustomerAttributeValueSearchModel : BaseSearchModel
{
    #region Properties

    public int CustomerAttributeId { get; set; }

    #endregion
}