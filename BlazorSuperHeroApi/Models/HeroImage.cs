using System.Text.Json.Serialization;

namespace BlazorSuperHeroApi.Models;

public sealed class HeroImage
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}

