
using System.Text.Json.Serialization;

namespace CanHazFunny;

public class JokeMessage
{
    [JsonPropertyName("joke")]
    public string? Joke { get; set; }
}
