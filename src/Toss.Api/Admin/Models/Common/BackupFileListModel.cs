using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

/// <summary>
/// Represents a backup file list model
/// </summary>
public partial record BackupFileListModel : BasePagedListModel<BackupFileModel>
{
}