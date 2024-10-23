using System.ComponentModel.DataAnnotations;

namespace Web.Models.Orders;

/// <summary>
/// Represents an upload license model
/// </summary>
public partial record UploadLicenseModel : BaseNopModel
{
    #region Properties

    public int OrderId { get; set; }

    public int OrderItemId { get; set; }

    [UIHint("Download")]
    public int LicenseDownloadId { get; set; }

    #endregion
}