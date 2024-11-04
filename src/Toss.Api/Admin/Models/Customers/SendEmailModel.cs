using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Customers;

public partial record CustomerModel
{
   

    #region Nested classes

    public partial record SendEmailModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.Customers.Customers.SendEmail.Subject")]
        public string Subject { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.SendEmail.Body")]
        public string Body { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.SendEmail.SendImmediately")]
        public bool SendImmediately { get; set; }

        [NopResourceDisplayName("Admin.Customers.Customers.SendEmail.DontSendBeforeDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? DontSendBeforeDate { get; set; }
    }

    #endregion
}
