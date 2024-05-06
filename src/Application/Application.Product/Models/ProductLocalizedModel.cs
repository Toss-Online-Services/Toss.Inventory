using Application.Common.Interfaces;

namespace Application.Product.Models;
public record ProductLocalizedModel : ILocalizedLocaleModel
{
    public int LanguageId { get; set; }

    public string Name { get; set; }

    public string ShortDescription { get; set; }

    public string FullDescription { get; set; }

    public string MetaKeywords { get; set; }

    public string MetaDescription { get; set; }

    public string MetaTitle { get; set; }

    public string SeName { get; set; }

}
