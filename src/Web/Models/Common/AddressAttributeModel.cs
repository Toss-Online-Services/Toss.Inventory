using Domain.Entities.Catalog;

namespace Web.Models.Common;

public partial record AddressAttributeModel : BaseNopEntityModel
{
    public AddressAttributeModel()
    {
        Values = new List<AddressAttributeValueModel>();
    }

    public string ControlId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public bool IsRequired { get; set; }

    /// <summary>
    /// Default value for textboxes
    /// </summary>
    public string DefaultValue { get; set; } = string.Empty;

    public AttributeControlType AttributeControlType { get; set; }

    public IList<AddressAttributeValueModel> Values { get; set; }
}

public partial record AddressAttributeValueModel : BaseNopEntityModel
{
    public string Name { get; set; } = string.Empty;

    public bool IsPreSelected { get; set; }
}
