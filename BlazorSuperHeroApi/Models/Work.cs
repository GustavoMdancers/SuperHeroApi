using System.Text.Json.Serialization;

namespace BlazorSuperHeroApi.Models;

public sealed class Work
{
    [JsonPropertyName("occupation")]
    public string Occupation { get; set; } = string.Empty;

    [JsonPropertyName("base")]
    public string Base { get; set; } = string.Empty;
}

