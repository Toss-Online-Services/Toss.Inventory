using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Common;

public partial record MaintenanceModel
{
    #region Nested classes

    public partial record DeleteGuestsModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.System.Maintenance.DeleteGuests.StartDate")]
        [UIHint("DateNullable")]
        public DateTime? StartDate { get; set; }

        [NopResourceDisplayName("Admin.System.Maintenance.DeleteGuests.EndDate")]
        [UIHint("DateNullable")]
        public DateTime? EndDate { get; set; }

        [NopResourceDisplayName("Admin.System.Maintenance.DeleteGuests.OnlyWithoutShoppingCart")]
        public bool OnlyWithoutShoppingCart { get; set; }

        public int? NumberOfDeletedCustomers { get; set; }
    }

    #endregion
}
