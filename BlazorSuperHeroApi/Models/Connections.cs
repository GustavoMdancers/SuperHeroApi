using System.Text.Json.Serialization;

namespace BlazorSuperHeroApi.Models;

public sealed class Connections
{
    [JsonPropertyName("group-affiliation")]
    public string GroupAffiliation { get; set; } = string.Empty;

    [JsonPropertyName("relatives")]
    public string Relatives { get; set; } = string.Empty;
}

