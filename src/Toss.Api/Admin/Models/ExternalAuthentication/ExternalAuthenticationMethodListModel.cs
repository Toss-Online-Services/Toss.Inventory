using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.ExternalAuthentication;

/// <summary>
/// Represents an external authentication method list model
/// </summary>
public partial record ExternalAuthenticationMethodListModel : BasePagedListModel<ExternalAuthenticationMethodModel>
{
}