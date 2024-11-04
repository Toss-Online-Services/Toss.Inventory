using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core.Domain.Orders;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Models.Catalog;

public partial record ProductDetailsModel
{
    #region Nested Classes

    public partial record AddToCartModel : BaseNopModel
    {
        public AddToCartModel()
        {
            AllowedQuantities = new List<SelectListItem>();
        }
        public int ProductId { get; set; }

        //qty
        [NopResourceDisplayName("Products.Qty")]
        public int EnteredQuantity { get; set; }
        public string MinimumQuantityNotification { get; set; }
        public List<SelectListItem> AllowedQuantities { get; set; }

        //price entered by customers
        [NopResourceDisplayName("Products.EnterProductPrice")]
        public bool CustomerEntersPrice { get; set; }
        [NopResourceDisplayName("Products.EnterProductPrice")]
        public decimal CustomerEnteredPrice { get; set; }
        public string CustomerEnteredPriceRange { get; set; }

        public bool DisableBuyButton { get; set; }
        public bool DisableWishlistButton { get; set; }

        //rental
        public bool IsRental { get; set; }

        //pre-order
        public bool AvailableForPreOrder { get; set; }
        public DateTime? PreOrderAvailabilityStartDateTimeUtc { get; set; }
        public string PreOrderAvailabilityStartDateTimeUserTime { get; set; }

        //updating existing shopping cart or wishlist item?
        public int UpdatedShoppingCartItemId { get; set; }
        public ShoppingCartType? UpdateShoppingCartItemType { get; set; }
    }

    #endregion
}
