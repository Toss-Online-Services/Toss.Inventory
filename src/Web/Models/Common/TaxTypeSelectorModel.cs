using Domain.Entities.Tax;

namespace Web.Models.Common;

public partial record TaxTypeSelectorModel : BaseNopModel
{
    public TaxDisplayType CurrentTaxType { get; set; }
}
