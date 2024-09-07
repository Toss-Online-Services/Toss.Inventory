namespace Application.Products.Models.Media;

public partial record VideoModel
{
    public string VideoUrl { get; set; }

    public string Allow { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
}
