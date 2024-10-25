using Nop.Web.Framework.Models;
using Toss.Api.Admin.Models.Localization;

namespace Toss.Api.Admin.Models.Common;

/// <summary>
/// Represents an admin language selector model
/// </summary>
public partial record LanguageSelectorModel : BaseNopModel
{
    #region Ctor

    public LanguageSelectorModel()
    {
        AvailableLanguages = new List<LanguageModel>();
    }

    #endregion

    #region Properties

    public IList<LanguageModel> AvailableLanguages { get; set; }

    public LanguageModel CurrentLanguage { get; set; }

    #endregion
}