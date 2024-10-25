using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Catalog;

/// <summary>
/// Represents a product picture search model
/// </summary>
public partial record ProductPictureSearchModel : BaseSearchModel
{
    #region Properties

    public int ProductId { get; set; }

    #endregion
}