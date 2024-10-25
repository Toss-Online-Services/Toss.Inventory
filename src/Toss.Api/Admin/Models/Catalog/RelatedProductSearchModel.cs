using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a related product search model
/// </summary>
public partial record RelatedProductSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}