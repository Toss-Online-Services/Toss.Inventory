using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

/// <summary>
/// Represents an address attribute value search model
/// </summary>
public partial record AddressAttributeValueSearchModel : BaseSearchModel
{
    #region Properties

    public int AddressAttributeId { get; set; }

    #endregion
}