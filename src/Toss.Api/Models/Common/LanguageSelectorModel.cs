using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Common;

public partial record LanguageSelectorModel : BaseNopModel
{
    public LanguageSelectorModel()
    {
        AvailableLanguages = new List<LanguageModel>();
    }

    public IList<LanguageModel> AvailableLanguages { get; set; }

    public int CurrentLanguageId { get; set; }

    public bool UseImages { get; set; }
}