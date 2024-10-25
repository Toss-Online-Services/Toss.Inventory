using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Messages;

public partial record TestMessageTemplateModel : BaseNopEntityModel
{
    public TestMessageTemplateModel()
    {
        Tokens = new List<string>();
    }

    public int LanguageId { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.MessageTemplates.Test.Tokens")]
    public List<string> Tokens { get; set; }

    [NopResourceDisplayName("Admin.ContentManagement.MessageTemplates.Test.SendTo")]
    public string SendTo { get; set; }
}