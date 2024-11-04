using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Catalog;

public partial record ProductDetailsModel
{
    #region Nested Classes

    public partial record ProductBreadcrumbModel : BaseNopModel
    {
        public ProductBreadcrumbModel()
        {
            CategoryBreadcrumb = new List<CategorySimpleModel>();
        }

        public bool Enabled { get; set; }
        public string JsonLd { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSeName { get; set; }
        public IList<CategorySimpleModel> CategoryBreadcrumb { get; set; }
    }

    #endregion
}
