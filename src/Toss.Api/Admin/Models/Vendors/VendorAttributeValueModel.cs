using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Admin.Models.Vendors;

/// <summary>
/// Represents a vendor attribute value model
/// </summary>
public partial record VendorAttributeValueModel : BaseNopEntityModel, ILocalizedModel<VendorAttributeValueLocalizedModel>
{
    #region Ctor

    public VendorAttributeValueModel()
    {
        Locales = new List<VendorAttributeValueLocalizedModel>();
    }

    #endregion

    #region Properties

    public int AttributeId { get; set; }

    [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.IsPreSelected")]
    public bool IsPreSelected { get; set; }

    [NopResourceDisplayName("Admin.Vendors.VendorAttributes.Values.Fields.DisplayOrder")]
    public int DisplayOrder { get; set; }

    public IList<VendorAttributeValueLocalizedModel> Locales { get; set; }

    #endregion
}
