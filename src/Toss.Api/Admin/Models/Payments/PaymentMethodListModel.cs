using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Payments;

/// <summary>
/// Represents a payment method list model
/// </summary>
public partial record PaymentMethodListModel : BasePagedListModel<PaymentMethodModel>
{
}