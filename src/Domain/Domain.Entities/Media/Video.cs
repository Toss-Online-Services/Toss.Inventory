namespace Domain.Entities.Media;

/// <summary>
/// Represents a video
/// </summary>
public partial class Video : Entity
{
    /// <summary>
    /// Gets or sets the URL of video
    /// </summary>
    public string VideoUrl { get; set; }
}