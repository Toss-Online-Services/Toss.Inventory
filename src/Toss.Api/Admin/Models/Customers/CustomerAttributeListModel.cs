using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a customer attribute list model
/// </summary>
public partial record CustomerAttributeListModel : BasePagedListModel<CustomerAttributeModel>
{
}