using Nop.Web.Framework.Models;
using Toss.Api.Models.Media;

namespace Toss.Api.Models.Catalog;

public partial record ProductDetailsModel
{
    #region Nested Classes

    public partial record ProductAttributeValueModel : BaseNopEntityModel
    {
        public ProductAttributeValueModel()
        {
            ImageSquaresPictureModel = new PictureModel();
        }

        public string Name { get; set; }

        public string ColorSquaresRgb { get; set; }

        //picture model is used with "image square" attribute type
        public PictureModel ImageSquaresPictureModel { get; set; }

        public string PriceAdjustment { get; set; }

        public bool PriceAdjustmentUsePercentage { get; set; }

        public decimal PriceAdjustmentValue { get; set; }

        public bool IsPreSelected { get; set; }

        //product picture ID (associated to this value)
        public int PictureId { get; set; }

        public bool CustomerEntersQty { get; set; }

        public int Quantity { get; set; }
    }

    #endregion
}
