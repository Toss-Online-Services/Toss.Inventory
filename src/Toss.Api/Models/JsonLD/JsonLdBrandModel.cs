using Newtonsoft.Json;

namespace Toss.Api.Models.JsonLD;

public record JsonLdBrandModel : JsonLdModel
{
    #region Properties

    [JsonProperty("@type")]
    public static string Type => "Brand";

    [JsonProperty("name")]
    public string Name { get; set; }

    #endregion
}