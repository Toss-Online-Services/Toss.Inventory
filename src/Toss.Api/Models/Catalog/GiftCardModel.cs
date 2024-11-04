using System.ComponentModel.DataAnnotations;
using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Toss.Api.Models.Catalog;

public partial record ProductDetailsModel
{
    #region Nested Classes

    public partial record GiftCardModel : BaseNopModel
    {
        public bool IsGiftCard { get; set; }

        [NopResourceDisplayName("Products.GiftCard.RecipientName")]
        public string RecipientName { get; set; }

        [NopResourceDisplayName("Products.GiftCard.RecipientEmail")]
        [DataType(DataType.EmailAddress)]
        public string RecipientEmail { get; set; }

        [NopResourceDisplayName("Products.GiftCard.SenderName")]
        public string SenderName { get; set; }

        [NopResourceDisplayName("Products.GiftCard.SenderEmail")]
        [DataType(DataType.EmailAddress)]
        public string SenderEmail { get; set; }

        [NopResourceDisplayName("Products.GiftCard.Message")]
        public string Message { get; set; }

        public GiftCardType GiftCardType { get; set; }
    }

    #endregion
}
