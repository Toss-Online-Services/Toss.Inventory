using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Common;

public partial record MaintenanceModel
{
    #region Nested classes

    public partial record DeleteExportedFilesModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.System.Maintenance.DeleteExportedFiles.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [NopResourceDisplayName("Admin.System.Maintenance.DeleteExportedFiles.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        public int? NumberOfDeletedFiles { get; set; }
    }

    #endregion
}
