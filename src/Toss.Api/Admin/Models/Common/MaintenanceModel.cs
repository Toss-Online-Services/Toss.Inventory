using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

public partial record MaintenanceModel : BaseNopModel
{
    public MaintenanceModel()
    {
        DeleteGuests = new();
        DeleteAbandonedCarts = new();
        DeleteExportedFiles = new();
        BackupFileSearchModel = new();
        DeleteAlreadySentQueuedEmails = new();
        DeleteMinificationFiles = new();
    }

    public DeleteGuestsModel DeleteGuests { get; set; }

    public DeleteAbandonedCartsModel DeleteAbandonedCarts { get; set; }

    public DeleteExportedFilesModel DeleteExportedFiles { get; set; }

    public BackupFileSearchModel BackupFileSearchModel { get; set; }

    public DeleteAlreadySentQueuedEmailsModel DeleteAlreadySentQueuedEmails { get; set; }

    public DeleteMinificationFilesModel DeleteMinificationFiles { get; set; }

    public bool BackupSupported { get; set; }
}
