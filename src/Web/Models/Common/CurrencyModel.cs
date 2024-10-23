namespace Web.Models.Common;

public partial record CurrencyModel : BaseNopEntityModel
{
    public string Name { get; set; }

    public string CurrencySymbol { get; set; }
}