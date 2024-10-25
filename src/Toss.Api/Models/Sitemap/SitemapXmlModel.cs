using Nop.Web.Framework.Models;

namespace Toss.Api.Models.Sitemap;

public partial record SitemapXmlModel : BaseNopModel
{
    public string SitemapXmlPath { get; set; }
}