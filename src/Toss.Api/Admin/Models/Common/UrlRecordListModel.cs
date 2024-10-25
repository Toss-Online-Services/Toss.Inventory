using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Common;

/// <summary>
/// Represents an URL record list model
/// </summary>
public partial record UrlRecordListModel : BasePagedListModel<UrlRecordModel>
{
}