﻿namespace Application.Products.Models.Media;

public partial record PictureModel
{
    public string ImageUrl { get; set; }

    public string ThumbImageUrl { get; set; }

    public string FullSizeImageUrl { get; set; }

    public string Title { get; set; }

    public string AlternateText { get; set; }
}
