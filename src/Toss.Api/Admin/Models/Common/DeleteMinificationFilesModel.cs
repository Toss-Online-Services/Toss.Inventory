using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

public partial record MaintenanceModel
{
    #region Nested classes

    public partial record DeleteMinificationFilesModel : BaseNopModel
    {
        public int? NumberOfDeletedFiles { get; set; }
    }

    #endregion
}
