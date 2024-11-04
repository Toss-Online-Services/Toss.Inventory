using Toss.Api.Models.ShoppingCart;

namespace Toss.Api.Models.Catalog;

public partial record ProductDetailsModel
{
    #region Nested Classes

    public partial record ProductEstimateShippingModel : EstimateShippingModel
    {
        public int ProductId { get; set; }
    }

    #endregion
}
