using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Tax;

/// <summary>
/// Represents a tax provider model
/// </summary>
public partial record TaxProviderModel : BaseNopModel, IPluginModel
{
    #region Properties

    [NopResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.FriendlyName")]
    public string FriendlyName { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.SystemName")]
    public string SystemName { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Tax.Providers.Fields.IsPrimaryTaxProvider")]
    public bool IsPrimaryTaxProvider { get; set; }

    [NopResourceDisplayName("Admin.Configuration.Tax.Providers.Configure")]
    public string ConfigurationUrl { get; set; }

    public string LogoUrl { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }

    #endregion
}