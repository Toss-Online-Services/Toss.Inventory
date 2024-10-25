using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.MultiFactorAuthentication;

/// <summary>
/// Represents an multi-factor authentication method list model
/// </summary>
public partial record MultiFactorAuthenticationMethodListModel : BasePagedListModel<MultiFactorAuthenticationMethodModel>
{
}