using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer attribute value list model
/// </summary>
public partial record CustomerAttributeValueListModel : BasePagedListModel<CustomerAttributeValueModel>
{
}