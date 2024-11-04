using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Catalog;

public partial record ProductDetailsModel
{
    #region Nested Classes

    public partial record TierPriceModel : BaseNopModel
    {
        public string Price { get; set; }
        public decimal PriceValue { get; set; }

        public int Quantity { get; set; }
    }

    #endregion
}
