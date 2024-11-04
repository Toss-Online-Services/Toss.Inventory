using Nop.Core.Domain.Catalog;
using Nop.Web.Framework.Models;
using Toss.Api.Models.Media;

namespace Toss.Api.Models.Catalog;

public partial record ProductDetailsModel : BaseNopEntityModel
{
    public ProductDetailsModel()
    {
        DefaultPictureModel = new PictureModel();
        PictureModels = new List<PictureModel>();
        VideoModels = new List<VideoModel>();
        GiftCard = new GiftCardModel();
        ProductPrice = new ProductPriceModel();
        AddToCart = new AddToCartModel();
        ProductAttributes = new List<ProductAttributeModel>();
        AssociatedProducts = new List<ProductDetailsModel>();
        VendorModel = new VendorBriefInfoModel();
        Breadcrumb = new ProductBreadcrumbModel();
        ProductTags = new List<ProductTagModel>();
        ProductSpecificationModel = new ProductSpecificationModel();
        ProductManufacturers = new List<ManufacturerBriefInfoModel>();
        ProductReviewOverview = new ProductReviewOverviewModel();
        ProductReviews = new ProductReviewsModel();
        TierPrices = new List<TierPriceModel>();
        ProductEstimateShipping = new ProductEstimateShippingModel();
    }

    //picture(s)
    public bool DefaultPictureZoomEnabled { get; set; }
    public PictureModel DefaultPictureModel { get; set; }
    public IList<PictureModel> PictureModels { get; set; }

    //videos
    public IList<VideoModel> VideoModels { get; set; }

    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public string JsonLd { get; set; }
    public string MetaKeywords { get; set; }
    public string MetaDescription { get; set; }
    public string MetaTitle { get; set; }
    public string SeName { get; set; }
    public bool VisibleIndividually { get; set; }

    public ProductType ProductType { get; set; }

    public bool ShowSku { get; set; }
    public string Sku { get; set; }

    public bool ShowManufacturerPartNumber { get; set; }
    public string ManufacturerPartNumber { get; set; }

    public bool ShowGtin { get; set; }
    public string Gtin { get; set; }

    public bool ShowVendor { get; set; }
    public VendorBriefInfoModel VendorModel { get; set; }

    public bool HasSampleDownload { get; set; }

    public GiftCardModel GiftCard { get; set; }

    public bool IsShipEnabled { get; set; }
    public bool IsFreeShipping { get; set; }
    public bool FreeShippingNotificationEnabled { get; set; }
    public string DeliveryDate { get; set; }

    public bool IsRental { get; set; }
    public DateTime? RentalStartDate { get; set; }
    public DateTime? RentalEndDate { get; set; }

    public DateTime? AvailableEndDate { get; set; }

    public ManageInventoryMethod ManageInventoryMethod { get; set; }

    public string StockAvailability { get; set; }

    public bool DisplayBackInStockSubscription { get; set; }

    public bool DisplayAttributeCombinationImagesOnly { get; set; }

    public bool EmailAFriendEnabled { get; set; }
    public bool CompareProductsEnabled { get; set; }

    public string PageShareCode { get; set; }

    public ProductPriceModel ProductPrice { get; set; }

    public AddToCartModel AddToCart { get; set; }

    public ProductBreadcrumbModel Breadcrumb { get; set; }

    public IList<ProductTagModel> ProductTags { get; set; }

    public IList<ProductAttributeModel> ProductAttributes { get; set; }

    public ProductSpecificationModel ProductSpecificationModel { get; set; }

    public IList<ManufacturerBriefInfoModel> ProductManufacturers { get; set; }

    public ProductReviewOverviewModel ProductReviewOverview { get; set; }

    public ProductReviewsModel ProductReviews { get; set; }

    public ProductEstimateShippingModel ProductEstimateShipping { get; set; }

    public IList<TierPriceModel> TierPrices { get; set; }

    //a list of associated products. For example, "Grouped" products could have several child "simple" products
    public IList<ProductDetailsModel> AssociatedProducts { get; set; }

    public bool DisplayDiscontinuedMessage { get; set; }

    public string CurrentStoreName { get; set; }

    public bool InStock { get; set; }

    public bool AllowAddingOnlyExistingAttributeCombinations { get; set; }

}
