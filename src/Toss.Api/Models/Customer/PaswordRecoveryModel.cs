using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Models.Customer;

public partial record PasswordRecoveryModel : BaseNopModel
{
    [DataType(DataType.EmailAddress)]
    [NopResourceDisplayName("Account.PasswordRecovery.Email")]
    public string Email { get; set; }

    public bool DisplayCaptcha { get; set; }
}