using System.Text.Json.Serialization;

namespace BlazorSuperHeroApi.Models;

public sealed class PowerStats
{
    [JsonPropertyName("intelligence")]
    public string Intelligence { get; set; } = string.Empty;

    [JsonPropertyName("strength")]
    public string Strength { get; set; } = string.Empty;

    [JsonPropertyName("speed")]
    public string Speed { get; set; } = string.Empty;

    [JsonPropertyName("durability")]
    public string Durability { get; set; } = string.Empty;

    [JsonPropertyName("power")]
    public string Power { get; set; } = string.Empty;

    [JsonPropertyName("combat")]
    public string Combat { get; set; } = string.Empty;

    public static int ParseStat(string? value) =>
        int.TryParse(value, out var parsed) ? Math.Clamp(parsed, 0, 100) : 0;
}

