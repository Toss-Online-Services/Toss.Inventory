using Nop.Web.Framework.Models;

namespace Toss.Api.Models.News;

public partial record NewsItemListModel : BaseNopModel
{
    public NewsItemListModel()
    {
        PagingFilteringContext = new NewsPagingFilteringModel();
        NewsItems = new List<NewsItemModel>();
    }

    public int WorkingLanguageId { get; set; }
    public NewsPagingFilteringModel PagingFilteringContext { get; set; }
    public IList<NewsItemModel> NewsItems { get; set; }
}