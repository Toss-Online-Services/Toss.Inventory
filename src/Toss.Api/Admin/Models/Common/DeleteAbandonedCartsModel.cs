using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Common;

public partial record MaintenanceModel
{
    #region Nested classes

    public partial record DeleteAbandonedCartsModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.System.Maintenance.DeleteAbandonedCarts.OlderThan")]
        [UIHint("Date")]
        public DateTime OlderThan { get; set; }

        public int? NumberOfDeletedItems { get; set; }
    }

    #endregion
}
