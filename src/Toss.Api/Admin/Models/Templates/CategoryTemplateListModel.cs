using Nop.Web.Framework.Models;

namespace Toss.Api.Admin.Models.Templates;

/// <summary>
/// Represents a category template list model
/// </summary>
public partial record CategoryTemplateListModel : BasePagedListModel<CategoryTemplateModel>
{
}