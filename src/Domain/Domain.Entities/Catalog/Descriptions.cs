namespace Domain.Entities.Catalog;
public class Descriptions
{
    // Descriptions
    public string ShortDescription { get; private set; }
    public string FullDescription { get; private set; }
    public string AdminComment { get; private set; }

    // Metadata
    public string MetaKeywords { get; private set; }
    public string MetaDescription { get; private set; }
    public string MetaTitle { get; private set; }
}
