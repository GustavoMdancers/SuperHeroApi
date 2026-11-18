using System.Text.Json.Serialization;

namespace BlazorSuperHeroApi.Models;

public sealed class SuperHeroSearchResponse
{
    [JsonPropertyName("response")]
    public string Response { get; set; } = string.Empty;

    [JsonPropertyName("results-for")]
    public string? ResultsFor { get; set; }

    [JsonPropertyName("results")]
    public List<SuperHero> Results { get; set; } = [];

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonIgnore]
    public bool IsSuccess => string.Equals(Response, "success", StringComparison.OrdinalIgnoreCase);
}

