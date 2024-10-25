using Newtonsoft.Json;

namespace Toss.Api.Models.JsonLD;

public record JsonLdAggregateRatingModel : JsonLdModel
{
    #region Properties

    [JsonProperty("@type")]
    public static string Type => "AggregateRating";

    [JsonProperty("ratingValue")]
    public string RatingValue { get; set; }

    [JsonProperty("reviewCount")]
    public int ReviewCount { get; set; }

    #endregion
}