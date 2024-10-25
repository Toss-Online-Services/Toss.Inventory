using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Messages;

/// <summary>
/// Represents a newsletter subscription list model
/// </summary>
public partial record NewsletterSubscriptionListModel : BasePagedListModel<NewsletterSubscriptionModel>
{
}