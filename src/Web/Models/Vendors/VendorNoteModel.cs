namespace Web.Models.Vendors;

/// <summary>
/// Represents a vendor note model
/// </summary>
public partial record VendorNoteModel : BaseNopEntityModel
{
    #region Properties

    public int VendorId { get; set; }

    [NopResourceDisplayName("Admin.Vendors.VendorNotes.Fields.Note")]
    public string Note { get; set; }

    [NopResourceDisplayName("Admin.Vendors.VendorNotes.Fields.CreatedOn")]
    public DateTime CreatedOn { get; set; }

    #endregion
}