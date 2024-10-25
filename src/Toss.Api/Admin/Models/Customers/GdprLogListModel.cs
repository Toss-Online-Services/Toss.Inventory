using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Customers;

/// <summary>
/// Represents a GDPR request list model
/// </summary>
public partial record GdprLogListModel : BasePagedListModel<GdprLogModel>
{
}