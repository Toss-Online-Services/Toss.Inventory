using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Customers;

public partial record CustomerModel
{
   
    #region Nested classes

    public partial record SendPmModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.Customers.Customers.SendPM.Subject")]
        public string Subject { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.SendPM.Message")]
        public string Message { get; set; }
    }

    #endregion
}
